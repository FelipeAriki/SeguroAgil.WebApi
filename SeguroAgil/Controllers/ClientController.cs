using Microsoft.AspNetCore.Mvc;
using SeguroAgil.Dal;
using SeguroAgil.Models;

namespace SeguroAgil.Controllers
{
    public class ClientController : Controller
    {
        private readonly RepositorioCliente _repository;

        public ClientController(RepositorioCliente repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Client>> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        [HttpPost]
        public ActionResult Inserir(Client exemplo)
        {
            _repository.Inserir(exemplo);
            return Ok();
        }
    }
}
