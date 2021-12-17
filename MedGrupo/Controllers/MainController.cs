using Apl.ERP.API.ModelViews;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.Collections.Generic;
using System.Linq;

namespace Apl.ERP.API.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        protected List<string> Erros = new List<string>();
        protected int qtdRegistros;

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValid())
            {
                Erros.Add("execução efetuada com sucesso.");
                Erros.Add($"Registros encontrados: {qtdRegistros:N0}");

                return Ok(ReturnResultViewModel(1, Erros, result));
            }

            return BadRequest(ReturnResultViewModel(90, Erros, result));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            AddErrors(modelState);

            return CustomResponse(0);
        }

        protected RetornoModelView ReturnResultViewModel(int returnCode, List<string> errors, object returnObject = null) => new RetornoModelView()
        {
            ReturnCode = returnCode,
            Messages = errors,
            ReturnObject = returnObject
        };
        protected bool IsValid()
        {
            return !Erros.Any();
        }

        protected void AddErrorMessage(string erro)
        {
            Erros.Add(erro);
        }

        protected void AddErrors(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
                AddErrorMessage(erro.ErrorMessage);
        }

        protected void ClearErrors()
        {
            Erros.Clear();
        }
    }
}
