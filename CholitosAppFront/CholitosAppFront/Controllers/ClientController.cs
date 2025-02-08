using CholitosAppFront.Core.DTOs;
using CholitosAppFront.Core.Interfaces;
using CholitosAppFront.Core.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CholitosAppFront.Controllers
{
    public class ClientController : Controller
    {
        private IClientUseCase _clientUseCase;

        public ClientController(IClientUseCase clientUeCase) { 
            _clientUseCase = clientUeCase ?? throw new ArgumentNullException(nameof(clientUeCase));
        }

        public IActionResult Index()
        {
            List<ClientDto> clients = new List<ClientDto>();

            try
            {
                clients = _clientUseCase.GetAllClients().Result.ToList();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Ocurrio un error al recuperar los clientes: " + ex.Message);
            }

            return View(
                viewName: "~/Views/Clients/Index.cshtml",
                model: clients
            );
        }
    }
}
