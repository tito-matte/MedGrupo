using Apl.ERP.API.Infra;
using Apl.ERP.API.Models;

using Dapper;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Apl.ERP.API.Repositories
{
    public class ContatoRepository : RepositoryGeral, IContatoRepository
    {
        public ContatoRepository(ConnectionString connection) : base(connection) => cnn = new SqlConnection(connection.MED);
        public ContatoRepository(SqlConnection cnn) : base(cnn) { }

        #region ..: Métodos públicos :..

        public async Task<int> CriarContato(Contato contato)
        {

            sql = @"
insert into dbo.tbContatos
    (Nome, Nascimento, Sexo, Status)
values
    (@nome, @nascimento, @sexo, @status)

select IDENT_CURRENT( 'dbo.tbContatos' )
";

            try
            {
                if (contato.Idade < 21)
                    throw new Exception("Contato menor de edade.");

                AbrirConnection();

                contato.ContatoID = cnn.ExecuteScalar<int>(sql, new { contato.Nome, contato.Nascimento, contato.Sexo, contato.Status });

                cnn.Close();

                return await Task.FromResult(contato.ContatoID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Contato>> ListarContatos()
        {
            sql = "Select * from dbo.tbContatos";

            List<Contato> empresas = new();

            AbrirConnection();

            empresas = cnn.Query<Contato>(sql).ToList();

            cnn.Close();

            return await Task.FromResult(empresas);
        }

        public async Task<Contato> VisualizarContato(int contatoID)
        {
            sql = $@"Select * from tbContatos
         where ContatoID = @contatoID";

            Contato contato = null;

            AbrirConnection();

            contato = cnn.Query<Contato>(sql, new { contatoID }).FirstOrDefault();

            cnn.Close();

            return await Task.FromResult(contato);
        }

        public async Task<bool> DesativarContato(int contatoID)
        {
            sql = $@"
update tbContatos set
    Status = 0
where ContatoID = @contatoID";

            try
            {
                AbrirConnection();

                cnn.ExecuteScalar(sql, new { contatoID });

                cnn.Close();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ExcluirContato(int contatoID)
        {
            sql = $@"
delete tbContatos
where ContatoID = @contatoID";

            try
            {
                AbrirConnection();

                cnn.ExecuteScalar(sql, new { contatoID });

                cnn.Close();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ..: Metodos privádos :..
        private void AbrirConnection()
        {
            if (cnn.State != System.Data.ConnectionState.Open)
                cnn.Open();
        }
        #endregion
    }
}
