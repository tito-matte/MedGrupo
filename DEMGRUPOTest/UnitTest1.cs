using Apl.ERP.API.Models;
using Apl.ERP.API.Repositories;

using NUnit.Framework;

using System.Data.SqlClient;

namespace DEMGRUPOTest
{
    public class Tests
    {
        private readonly string strConnection = "data source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=C:\\Projetos\\MedGrupo\\SQL\\MEDGRUPO.mdf;initial catalog=MEDGRUPO;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        private ContatoRepository repository;
        private SqlConnection cnn;

        [SetUp]
        public void Setup()
        {
            cnn = new SqlConnection(strConnection);
        }

        [Test]
        public void TestCriarContato()
        {
            repository = new ContatoRepository(cnn);

            Contato contato = new Contato
            {
                Nascimento = new System.DateTime(1960, 05, 03),
                Nome = "Domingo Matte Hiriart",
                Sexo = "M",
                Status = System.StatusEN.Ativo
            };

            _ = repository.CriarContato(contato);

            Assert.IsTrue(contato.ContatoID > 0);
        }
    }
}
