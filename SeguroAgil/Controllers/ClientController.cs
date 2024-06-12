using Microsoft.AspNetCore.Mvc;
using SeguroAgil.Application.Interfaces;
using SeguroAgil.Domain.Entities;

namespace SeguroAgil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public ActionResult<List<Client>> ObterCliente()
        {
            return _clientService.GetClients();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<Client> ObterClientes(string id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
                return NotFound($"Cliente com o Id: {id}, não pode ser encontrado!");
            else
                return client;
        }

        // POST api/<ClientController>
        [HttpPost]
        public ActionResult<Client> CriarCliente([FromBody] Client client)
        {
            _clientService.CreateClient(client);

            return CreatedAtAction(nameof(ObterCliente), new { id = client.Id }, client);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public ActionResult<Client> AlterarCliente(string id, [FromBody] Client client)
        {
            var verificaSeClienteExiste = _clientService.GetClientById(id);
            var flagAtualizou = false;

            if (verificaSeClienteExiste == null)
            {
                return NotFound($"Cliente com o Id: {id}, não pode ser encontrado!");
            }
            else
            {
                flagAtualizou = _clientService.UpdateClient(id, client);
                if (flagAtualizou) 
                    return NoContent();
                else
                    return BadRequest("Oops, Cliente não pode ser atualizado! Entrar em contato com o Suporte.");

            }
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public ActionResult<Client> RemoverCliente(string id)
        {
            var verificaSeClienteExiste = _clientService.GetClientById(id);
            var flagAtualizou = false;
            if (verificaSeClienteExiste == null)
            {
                return NotFound($"Cliente com o Id: {id}, não pode ser encontrado!");
            }
            else
            {
                flagAtualizou = _clientService.DeleteClient(id);
                if (flagAtualizou)
                    return Ok($"Cliente com o Id: {id} foi removido com sucesso!");
                else
                    return BadRequest("Oops, Cliente não pode ser removido! Entrar em contato com o Suporte.");

            }
        }
    }
}
