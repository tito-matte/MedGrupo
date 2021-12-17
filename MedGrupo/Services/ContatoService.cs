using Apl.ERP.API.Models;
using Apl.ERP.API.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apl.ERP.API.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository repository;

        public ContatoService(IContatoRepository repository) => this.repository = repository;

        public void Dispose() => GC.SuppressFinalize(this);

        public async Task<List<Contato>> ListarContatos() => await repository.ListarContatos();

        public async Task<int> CriarContato(Contato contato) => await repository.CriarContato(contato);

        public async Task<Contato> VisualizarContato(int contatoID) => await repository.VisualizarContato(contatoID);

        public async Task<bool> DesativarContato(int contatoID) => await repository.DesativarContato(contatoID);

        public async Task<bool> ExcluirContato(int contatoID) => await repository.ExcluirContato(contatoID);

    }
}