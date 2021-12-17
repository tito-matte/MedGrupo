using Apl.ERP.API.Models;
using Apl.ERP.API.ModelViews;
using Apl.ERP.API.Services;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apl.ERP.API.Controllers
{
    public class ContatoController : MainController
    {
        private readonly IContatoService service;
        private readonly IMapper mapper;

        public ContatoController(IContatoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(RetornoModelView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoModelView), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ListarContatos()
        {
            List<Contato> empresas = await service.ListarContatos();
            List<ContatoView> empresasView = new();

            empresas.ForEach(e =>
            {
                ContatoView emp = mapper.Map<ContatoView>(e);
                empresasView.Add(emp);
            });

            qtdRegistros = empresasView.Count;
            return CustomResponse(empresasView);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RetornoModelView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoModelView), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CriarContato(ContatoView contatoView)
        {
            try
            {
                Contato contato = mapper.Map<Contato>(contatoView);


                if ((contatoView.ContatoID = await service.CriarContato(contato)) == 0)
                    AddErrorMessage("Inserção do contato com erro.");
                else
                    qtdRegistros = 1;
            }
            catch (Exception ex)
            {
                AddErrorMessage("Inserção do contatoa com erro.");
                AddErrorMessage(ex.Message);
            }

            return CustomResponse(contatoView);
        }

        [HttpGet]
        [ProducesResponseType(typeof(RetornoModelView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoModelView), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ProcuraContato(int  contatoID)
        {
            ContatoView contatoView = null;

            if (contatoID == 0)
                AddErrorMessage("Não foi especificado o ID do contato.");
            else
            {
                Contato contato = await service.VisualizarContato(contatoID);
                if (contato == null)
                    AddErrorMessage($"Não foi encontrada o contato de ID {contatoID}.");
                else
                {
                    contatoView = mapper.Map<ContatoView>(contato);
                    qtdRegistros = 1;
                }
            }

            return CustomResponse(contatoView);
        }


        [HttpGet]
        [ProducesResponseType(typeof(RetornoModelView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoModelView), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DesativarContato(int contatoID)
        {
            ContatoView contatoView = null;

            if (contatoID == 0)
                AddErrorMessage("Não foi especificado o ID do contato.");
            else
            {
                if (!await service.DesativarContato(contatoID))
                    AddErrorMessage($"Não foi encontrada o contato de ID {contatoID}.");
                else
                {
                    qtdRegistros = 1;
                }
            }

            return CustomResponse(contatoView);
        }


        [HttpGet]
        [ProducesResponseType(typeof(RetornoModelView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoModelView), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ExcluirContato(int contatoID)
        {
            ContatoView contatoView = null;

            if (contatoID == 0)
                AddErrorMessage("Não foi especificado o ID do contato.");
            else
            {
                if (!await service.ExcluirContato(contatoID))
                    AddErrorMessage($"Não foi encontrada o contato de ID {contatoID}.");
                else
                {
                    qtdRegistros = 1;
                }
            }

            return CustomResponse(contatoView);
        }
    }
}
