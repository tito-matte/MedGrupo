using Apl.ERP.API.Infra;

using System.Data.SqlClient;

namespace Apl.ERP.API.Repositories
{
    public class RepositoryGeral
    {
        protected ConnectionString connection;
        protected string sql;
        protected SqlConnection cnn;
        protected readonly bool closeConnection = true;

        public RepositoryGeral(ConnectionString connection) => this.connection = connection;
        public RepositoryGeral(SqlConnection cnn) => this.cnn = cnn;
    }
}
