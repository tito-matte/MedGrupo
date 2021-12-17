using Apl.ERP.API.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apl.ERP.API.Services
{
    public interface IContatoService : IDisposable
    {
        Task<List<Contato>> ListarContatos();
        Task<int> CriarContato(Contato contato);
        Task<Contato> VisualizarContato(int contatoID);
        Task<bool> DesativarContato(int contatoID);
        Task<bool> ExcluirContato(int contatoID);
    }
}
