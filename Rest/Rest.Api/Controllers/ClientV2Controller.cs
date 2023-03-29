using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Rest.Api.Mappers;
using Rest.Api.Validation;
using Rest.Data.Sql;
using Rest.IServices.Client;
using Microsoft.AspNetCore.Mvc;

namespace Rest.Api.Controllers
{
    [ApiVersion( "2.0" )]
    [Route( "api/v{version:apiVersion}/client" )]
    public class ClientV2Controller: Controller
    {
        private readonly RestDbContext _context;
        private readonly IClientService _clientService;

        /// <inheritdoc />
        public ClientV2Controller(RestDbContext context, IClientService clientService)
        {
            _context = context;
            _clientService = clientService;
        } 
        
        [HttpGet("allClients", Name = "GetAllClients")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: Entry[Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceCacheKey,System.Object][]; size: 1623MB")]
        public async Task<IActionResult> GetClients()
        {
            var clients = _context.Client.Where(x => x.ClientId != 0);
            return Ok(clients);
        }

        [HttpGet("{clientId:min(1)}", Name = "GetClientById")]
        public async Task<IActionResult> GetClientById(int clientId)
        { 
           
            var client = await _clientService.GetClientByClientId(clientId);
            if (client != null)
            {
                return Ok(ClientToClientViewModelMapper.ClientToClientViewModel(client));
            }
            return NotFound();
        }
           
        
        [HttpGet("name/{clientName}", Name = "GetClientByClientName")]
        public async Task<IActionResult> GetClientByClientName(string clientName)
        {
            var client = await _clientService.GetClientByClientName(clientName);
            if (client != null)
            {
                return Ok(ClientToClientViewModelMapper.ClientToClientViewModel(client));
            }
            return NotFound();
        }
        
        [ValidateModel]
        [HttpPost("Add", Name = "AddClient")]
        public async Task<IActionResult> Post([FromBody] IServices.Requests.CreateClient createClient)
        {
            var client = await _clientService.CreateClient(createClient);
            
            return Created(client.ClientId.ToString(),ClientToClientViewModelMapper.ClientToClientViewModel(client)) ;
        }
        
        
        [ValidateModel]
        [HttpPatch("edit/{clientId:min(1)}", Name = "EditClient")]
//        public async Task<IActionResult> EditClient([FromBody] EditClient editClient,[FromQuery] int clientId)
        public async Task<IActionResult> EditClient(int clientId, [FromBody] IServices.Requests.EditClient editClient)
        {
            await _clientService.EditClient( clientId, editClient);
            return NoContent();
        }
    
        [HttpDelete("remove/{clientId:min(1)}", Name = "RemoveClient")]
        public async Task<IActionResult> RemoveClient(int clientId)
        {
            await _clientService.RemoveClient(clientId);
            return NoContent();
        }
    }
}