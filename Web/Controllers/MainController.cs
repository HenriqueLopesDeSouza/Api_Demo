using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Web.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {

        private readonly INotifier _notifier;
        public readonly IUser AppUser;

        protected Guid UserId { get; set; }
        protected bool AuthenticatedUser { get; set; }

        protected MainController(INotifier notifier,
                                 IUser appUser)
        {
            _notifier = notifier;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UserId = appUser.GetUserId();
                AuthenticatedUser = true;
            }
        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyErrorModel(modelState);
            return CustomResponse();
        }

        protected void NotifyErrorModel(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifierErro(errorMsg);
            }
        }

        protected void NotifierErro(string mensagem)
        {
            _notifier.Handle(new Notifier(mensagem));
        }
    }
}
