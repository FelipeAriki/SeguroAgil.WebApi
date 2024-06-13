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
        [HttpGet("GetClients")]
        public async Task<ActionResult<Client>> GetClients()
        {
            var clients = await _clientService.GetClientsAsync();

            return clients == null ? BadRequest("Clients not found") : Ok(clients);
        }

        // GET api/<ClientController>/5
        [HttpGet("GetClient/{id}")]
        public async Task<ActionResult<Client>> GetClient(string id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
                return NotFound($"Cliente com o Id: {id}, não pode ser encontrado!");
            else
                return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost("CreateClient")]
        public async Task<ActionResult<Client>> CreateClient([FromBody] Client client)
        {
            await _clientService.CreateClientAsync(client);

            return Ok("Client created!");
        }

        // PUT api/<ClientController>/5
        [HttpPut("UpdateClient")]
        public async Task<ActionResult<Client>> UpdateClient([FromBody] Client client)
        {
            var searchClient = await _clientService.GetClientByIdAsync(client.Id);

            if (searchClient == null)
            {
                return NotFound($"Cliente with Id: {client.Id}, can`t be found!");
            }
            else
            {
                var clientUpdated = await _clientService.UpdateClientAsync(client);
                if (clientUpdated != null) 
                    return Ok(clientUpdated);
                else
                    return BadRequest("UpdateClientAsync Failed!");

            }
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("DeleteClient/{id}")]
        public async Task<ActionResult<bool>> DeleteClient(string id)
        {
            var searchClient = await _clientService.GetClientByIdAsync(id);
            var flag = false;

            if (searchClient == null)
            {
                return NotFound($"Cliente with Id: {id}, can`t be found!");
            }
            else
            {
                flag = await _clientService.DeleteClientAsync(id);
                if (flag)
                    return Ok($"Cliente with Id: {id} deleted!");
                else
                    return BadRequest("DeleteClientAsync Failed!");

            }
        }
    }
}
