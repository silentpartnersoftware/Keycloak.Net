using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests;

internal sealed class KeycloakTestFixture
{
	private const string GroupClientIdValue = "keycloak-net-fixture-group-client";
	private const string UserClientIdValue = "keycloak-net-fixture-user-client";
	private const string FixtureClientIdValue = "keycloak-net-fixture-client";
	private const string GroupNameValue = "keycloak-net-fixture-group";
	private const string DefaultGroupNameValue = "keycloak-net-fixture-default-group";
	private const string UserNameValue = "keycloak-net-fixture-user";
	private const string ClientScopeNameValue = "keycloak-net-fixture-client-scope";
	private const string ProtocolMapperName = "keycloak-net-fixture-protocol-mapper";
	private const string IdentityProviderAliasValue = "keycloak-net-fixture-oidc";
	private const string IdentityProviderMapperName = "keycloak-net-fixture-idp-mapper";
	private const string RealmRoleNameValue = "keycloak-net-realm-available";
	private const string GroupClientRoleNameValue = "keycloak-net-group-mapped";
	private const string UserClientRoleNameValue = "keycloak-net-user-mapped";
	private const string GroupRealmRoleNameValue = "keycloak-net-group-realm-mapped";
	private const string UserRealmRoleNameValue = "keycloak-net-user-realm-mapped";

	private readonly KeycloakClient _client;
	private readonly Lazy<Task<string>> _groupClientUuid;
	private readonly Lazy<Task<string>> _userClientUuid;
	private readonly Lazy<Task<string>> _fixtureClientUuid;
	private readonly Lazy<Task<string>> _groupId;
	private readonly Lazy<Task<string>> _defaultGroupId;
	private readonly Lazy<Task<string>> _userId;
	private readonly Lazy<Task<string>> _clientScopeId;
	private readonly Lazy<Task<string>> _protocolMapperId;
	private readonly Lazy<Task<string>> _identityProviderMapperId;
	private readonly Lazy<Task<string>> _realmRoleId;

	public static string Realm => "keycloak-net-fixture";
	public static string IdentityProviderAlias => IdentityProviderAliasValue;
	public static string FixtureClientId => FixtureClientIdValue;
	public static string GroupClientId => GroupClientIdValue;
	public static string UserClientId => UserClientIdValue;
	public static string GroupName => GroupNameValue;
	public static string DefaultGroupPath => $"/{DefaultGroupNameValue}";
	public static string UserName => UserNameValue;
	public static string ClientScopeName => ClientScopeNameValue;
	public static string RealmRoleName => RealmRoleNameValue;
	public static string GroupClientRoleName => GroupClientRoleNameValue;
	public static string UserClientRoleName => UserClientRoleNameValue;
	public static string GroupRealmRoleName => GroupRealmRoleNameValue;
	public static string UserRealmRoleName => UserRealmRoleNameValue;

	public KeycloakTestFixture(KeycloakClient client)
	{
		_client = client;
		_groupClientUuid = new(() => ResolveClientUuidAsync(GroupClientIdValue));
		_userClientUuid = new(() => ResolveClientUuidAsync(UserClientIdValue));
		_fixtureClientUuid = new(() => ResolveClientUuidAsync(FixtureClientIdValue));
		_groupId = new(() => ResolveGroupIdAsync(GroupNameValue));
		_defaultGroupId = new(() => ResolveGroupIdAsync(DefaultGroupNameValue));
		_userId = new(() => ResolveUserIdAsync(UserNameValue));
		_clientScopeId = new(() => ResolveClientScopeIdAsync(ClientScopeNameValue));
		_protocolMapperId = new(() => ResolveProtocolMapperIdAsync());
		_identityProviderMapperId = new(() => ResolveIdentityProviderMapperIdAsync());
		_realmRoleId = new(() => ResolveRealmRoleIdAsync());
	}

	public Task<string> GroupClientUuidAsync() => _groupClientUuid.Value;

	public Task<string> UserClientUuidAsync() => _userClientUuid.Value;

	public Task<string> FixtureClientUuidAsync() => _fixtureClientUuid.Value;

	public Task<string> GroupIdAsync() => _groupId.Value;

	public Task<string> DefaultGroupIdAsync() => _defaultGroupId.Value;

	public Task<string> UserIdAsync() => _userId.Value;

	public Task<string> ClientScopeIdAsync() => _clientScopeId.Value;

	public Task<string> ProtocolMapperIdAsync() => _protocolMapperId.Value;

	public Task<string> IdentityProviderMapperIdAsync() => _identityProviderMapperId.Value;

	public Task<string> RealmRoleIdAsync() => _realmRoleId.Value;

	private async Task<string> ResolveClientUuidAsync(string clientId)
	{
		var clients = await _client.GetClientsAsync(Realm);
		var id = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;

		Assert.NotNull(id);
		return id;
	}

	private async Task<string> ResolveGroupIdAsync(string groupName)
	{
		var groups = await _client.GetGroupHierarchyAsync(Realm, search: groupName);
		var id = groups.FirstOrDefault(x => x.Name == groupName)?.Id;

		Assert.NotNull(id);
		return id;
	}

	private async Task<string> ResolveUserIdAsync(string username)
	{
		var users = await _client.GetUsersAsync(Realm, username: username, exact: true);
		var id = users.FirstOrDefault(x => x.UserName == username)?.Id;

		Assert.NotNull(id);
		return id;
	}

	private async Task<string> ResolveClientScopeIdAsync(string clientScopeName)
	{
		var clientScopes = await _client.GetClientScopesAsync(Realm);
		var id = clientScopes.FirstOrDefault(x => x.Name == clientScopeName)?.Id;

		Assert.NotNull(id);
		return id;
	}

	private async Task<string> ResolveProtocolMapperIdAsync()
	{
		var clientScopeId = await ClientScopeIdAsync();
		var protocolMappers = await _client.GetProtocolMappersAsync(Realm, clientScopeId);
		var id = protocolMappers.FirstOrDefault(x => x.Name == ProtocolMapperName)?.Id;

		Assert.NotNull(id);
		return id;
	}

	private async Task<string> ResolveRealmRoleIdAsync()
	{
		var roles = await _client.GetRolesAsync(Realm);
		var id = roles.FirstOrDefault(x => x.Name == RealmRoleNameValue)?.Id;

		Assert.NotNull(id);
		return id;
	}

	private async Task<string> ResolveIdentityProviderMapperIdAsync()
	{
		var mappers = await _client.GetIdentityProviderMappersAsync(Realm, IdentityProviderAliasValue);
		var id = mappers.FirstOrDefault(x => x.Name == IdentityProviderMapperName)?.Id;

		Assert.NotNull(id);
		return id;
	}
}
