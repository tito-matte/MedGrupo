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
            int contatoID = 0;

            try
            {
                if (contato.Idade < 21)
                    throw new Exception("Contato menor de edade.");

                using (SqlConnection cnn = new SqlConnection(connection.MED))
                {
                    cnn.Open();

                    contatoID = cnn.ExecuteScalar<int>(sql, new { contato.Nome, contato.Nascimento, contato.Sexo, contato.Status });

                    cnn.Close();
                }

                return await Task.FromResult(contatoID);
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

            using (SqlConnection cnn = new(connection.MED))
            {
                cnn.Open();

                empresas = cnn.Query<Contato>(sql).ToList();

                cnn.Close();
            }

            return await Task.FromResult(empresas);
        }

        public async Task<Contato> VisualizarContato(int contatoID)
        {
            sql = $@"Select * from tbContatos
         where ContatoID = @contatoID";

            Contato contato = null;

            using (SqlConnection cnn = new SqlConnection(connection.MED))
            {


                cnn.Open();

                contato = cnn.Query<Contato>(sql, new { contatoID }).FirstOrDefault();

                cnn.Close();

            }
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
                using (SqlConnection cnn = new SqlConnection(connection.MED))
                {
                    cnn.Open();

                    cnn.ExecuteScalar(sql, new { contatoID });

                    cnn.Close();

                    return await Task.FromResult(true);
                }
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
                using (SqlConnection cnn = new SqlConnection(connection.MED))
                {
                    cnn.Open();

                    cnn.ExecuteScalar(sql, new { contatoID });

                    cnn.Close();

                    return await Task.FromResult(true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
