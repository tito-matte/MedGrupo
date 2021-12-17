using Microsoft.Extensions.Configuration;

namespace Apl.ERP.API.Infra
{
    public class ConnectionString
    {
        private readonly IConfiguration configuration;
        public ConnectionString(IConfiguration configuration) => this.configuration = configuration;

        public string MED => configuration.GetConnectionString("MED");
    }
}
