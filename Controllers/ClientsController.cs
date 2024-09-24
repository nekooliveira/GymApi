using GymProject1.Models;
using GymProject1.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
//namespace GymProject1.Controllers

public class ClientsController : ControllerBase
{
    private readonly ClientService _clientService;

    public ClientsController(GymContext context)
    {
        _clientService = new ClientService(context);
    }
    [HttpGet]
    public ActionResult<List<Client>> GetClients()
    {
        return _clientService.ListClients();

    }

    [HttpGet("{id}")]
    public ActionResult<Client> GetClient(int id)
    {
        var client = _clientService.SearchPerId(id);
        if (client == null) return NotFound();
        return client;
    }

    [HttpPost]

    public IActionResult PostClient(Client client)
    {
        _clientService.AddClient(client);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult PutClient(int id, Client client)
    {
        _clientService.ChangeClient(id, client);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteClient(int id)
    {
        _clientService.DeleteClient(id);
        return Ok();
    }
    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        var client = _clientService.Authenticate(username, password);
        if (client == null) return Unauthorized();
        return Ok(client);
    }
}
