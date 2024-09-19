using Keycloak.Net.Models.Clients;
using Keycloak.Net.Models.Groups;
using Keycloak.Net.Models.Users;

namespace Keycloak.Net.Models.RealmsAdmin;

public class PartialImport
{
	public IEnumerable<Client> Clients { get; set; }
	public IEnumerable<Group> Groups { get; set; }
	public IEnumerable<IdentityProvider> IdentityProviders { get; set; }
	public string IfResourceExists { get; set; }
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public Policies Policy { get; set; }
	public Roles Roles { get; set; }
	public IEnumerable<User> Users { get; set; }
}