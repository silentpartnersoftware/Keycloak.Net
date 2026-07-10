#!/usr/bin/env bash
set -euo pipefail

ROOT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"

CONTAINER_NAME="${KEYCLOAK_CONTAINER_NAME:-keycloak-net-tests}"
KEYCLOAK_VERSION="${KEYCLOAK_VERSION:-26.7.0}"
KEYCLOAK_IMAGE="${KEYCLOAK_IMAGE:-quay.io/keycloak/keycloak:${KEYCLOAK_VERSION}}"
KEYCLOAK_PORT="${KEYCLOAK_PORT:-8080}"
KEYCLOAK_ADMIN="${KEYCLOAK_ADMIN:-admin}"
KEYCLOAK_ADMIN_PASSWORD="${KEYCLOAK_ADMIN_PASSWORD:-admin}"
REALM_EXPORT="${REALM_EXPORT:-${ROOT_DIR}/test/keycloak-net-fixture-realm-export.json}"
TEST_TARGET="${TEST_TARGET:-${ROOT_DIR}/Keycloak.Net.Core.sln}"
AUTO_CLEANUP=0
RUN_TESTS=0
DOTNET_TEST_ARGS=()

usage() {
    cat <<USAGE
Usage: build/start-keycloak.sh [options] [-- dotnet-test-args]

Starts a Keycloak Docker container, imports the keycloak-net-fixture realm backup,
then waits until interrupted.

Options:
  --test               Run dotnet test after Keycloak is ready.
  --auto-cleanup       Remove the Keycloak container as soon as startup/tests complete.
  -h, --help           Show this help text.

Environment variables:
  KEYCLOAK_CONTAINER_NAME  Default: keycloak-net-tests
  KEYCLOAK_VERSION         Default: 26.7.0
  KEYCLOAK_IMAGE           Default: quay.io/keycloak/keycloak:\$KEYCLOAK_VERSION
  KEYCLOAK_PORT            Default: 8080
  KEYCLOAK_ADMIN           Default: admin
  KEYCLOAK_ADMIN_PASSWORD  Default: admin
  REALM_EXPORT             Default: test/keycloak-net-fixture-realm-export.json
  TEST_TARGET              Default: Keycloak.Net.Core.sln

Examples:
  build/start-keycloak.sh
  build/start-keycloak.sh --test
  build/start-keycloak.sh --test --auto-cleanup
  build/start-keycloak.sh --test -- --framework net8.0
USAGE
}

while (($#)); do
    case "$1" in
        --test)
            RUN_TESTS=1
            shift
            ;;
        --auto-cleanup)
            AUTO_CLEANUP=1
            shift
            ;;
        -h|--help)
            usage
            exit 0
            ;;
        --)
            shift
            DOTNET_TEST_ARGS+=("$@")
            break
            ;;
        *)
            DOTNET_TEST_ARGS+=("$1")
            shift
            ;;
    esac
done

if ! command -v docker >/dev/null 2>&1; then
    echo "Docker is required to run the Keycloak integration tests." >&2
    exit 1
fi

if [[ "$RUN_TESTS" -eq 1 ]] && ! command -v dotnet >/dev/null 2>&1; then
    echo ".NET SDK is required to run the test project." >&2
    exit 1
fi

if [[ "$RUN_TESTS" -eq 0 && "${#DOTNET_TEST_ARGS[@]}" -gt 0 ]]; then
    echo "dotnet test arguments were provided, but --test was not specified." >&2
    echo "Use: build/start-keycloak.sh --test -- ${DOTNET_TEST_ARGS[*]}" >&2
    exit 1
fi

if [[ ! -f "$REALM_EXPORT" ]]; then
    echo "Realm export not found: $REALM_EXPORT" >&2
    exit 1
fi

cleanup() {
    local exit_code=$?

    docker rm -f "$CONTAINER_NAME" >/dev/null 2>&1 || true
    exit "$exit_code"
}

wait_for_interrupt() {
    echo "Press Ctrl-C to stop Keycloak and remove the container."

    while true; do
        sleep 1
    done
}

wait_for_keycloak() {
    local url="http://localhost:${KEYCLOAK_PORT}/realms/master"
    local retries=120

    echo "Waiting for Keycloak at $url"

    for ((attempt = 1; attempt <= retries; attempt++)); do
        if curl --fail --silent --output /dev/null "$url"; then
            echo "Keycloak is ready."
            return 0
        fi

        sleep 1
    done

    echo "Keycloak did not become ready within ${retries}s." >&2
    docker logs "$CONTAINER_NAME" >&2 || true
    return 1
}

trap cleanup EXIT
trap 'exit 130' INT
trap 'exit 143' TERM

docker rm -f "$CONTAINER_NAME" >/dev/null 2>&1 || true

echo "Starting Keycloak ${KEYCLOAK_IMAGE} on port ${KEYCLOAK_PORT}"

docker run \
    --detach \
    --name "$CONTAINER_NAME" \
    --publish "${KEYCLOAK_PORT}:8080" \
    --env KEYCLOAK_ADMIN="$KEYCLOAK_ADMIN" \
    --env KEYCLOAK_ADMIN_PASSWORD="$KEYCLOAK_ADMIN_PASSWORD" \
    --volume "${REALM_EXPORT}:/opt/keycloak/data/import/keycloak-net-fixture-realm-export.json:ro" \
    "$KEYCLOAK_IMAGE" \
    start-dev --features=admin-fine-grained-authz:v1 --import-realm >/dev/null

wait_for_keycloak

echo "Keycloak is running at http://localhost:${KEYCLOAK_PORT}"

if [[ "$RUN_TESTS" -eq 1 ]]; then
    test_exit_code=0

    if ((${#DOTNET_TEST_ARGS[@]})); then
        echo "Running tests: dotnet test ${TEST_TARGET} ${DOTNET_TEST_ARGS[*]}"
        dotnet test "$TEST_TARGET" "${DOTNET_TEST_ARGS[@]}" || test_exit_code=$?
    else
        echo "Running tests: dotnet test ${TEST_TARGET}"
        dotnet test "$TEST_TARGET" || test_exit_code=$?
    fi

    if [[ "$AUTO_CLEANUP" -eq 0 ]]; then
        wait_for_interrupt
    fi

    exit "$test_exit_code"
else
    if [[ "$AUTO_CLEANUP" -eq 0 ]]; then
        wait_for_interrupt
    fi
fi
