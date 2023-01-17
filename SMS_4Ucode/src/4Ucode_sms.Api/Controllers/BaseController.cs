using _4Ucode_sms.Bussines.Notificacoes;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace _4Ucode_sms.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly INotificador _notificador;
        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected ActionResult CreatedResponse(string uri = "", object result = null) => IsValid() ? Created(uri, result) : BadRequestResponse();

        protected ActionResult FileResponse(byte[] fileContents, string contentType) => IsValid() ? base.File(fileContents, contentType) : BadRequestResponse();

        protected ActionResult CustomResponse(object result = null) => IsValid() ? Ok(result) : BadRequestResponse();

        protected ActionResult ErrorResponse(string message = null, string stackTrace = null)
        {
            if (message != null)
                NotificarErro(message);

            return Problem(detail: stackTrace, title: message);
        }

        private ActionResult BadRequestResponse()
        {
            var errors = _notificador.ObterNotificacoes();
            return BadRequest(new ErrorResult(errors));
        }

        protected bool IsValid() => !IsInvalid();

        protected bool IsInvalid() => _notificador.HasNotifications();

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}