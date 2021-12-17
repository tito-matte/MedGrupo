using Apl.ERP.API.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apl.ERP.API.Repositories
{
    public interface IContatoRepository
    {
        Task<List<Contato>> ListarContatos();
        Task<int> CriarContato(Contato contato);
        Task<Contato> VisualizarContato(int contatoID);
        Task<bool> DesativarContato(int contatoID);
        Task<bool> ExcluirContato(int contatoID);
    }
}
