using Apl.ERP.API.Repositories;
using Apl.ERP.API.Services;

using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        IContatoService contatoService;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IncluirContatoTest()
        {
            contatoService = new ContatoService(new ContatoRepository(new Apl.ERP.API.Infra.ConnectionString()));

            Assert.Pass();
        }
    }
}