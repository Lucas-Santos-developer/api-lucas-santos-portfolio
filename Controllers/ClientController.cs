using APILucasSantosPortfolio.Context;
using APILucasSantosPortfolio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace APILucasSantosPortfolio.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            var clients = _context.Clients.ToList();
            if (clients is null) return NotFound();
            return clients;
        }

        [HttpGet("{id:int}", Name = "client")]
        public ActionResult<Client> Get(int id)
        {
            var client = _context.Clients.FirstOrDefault(p => p.ClientId == id);
            if (client is null) return NotFound();
            return client;
        }

        [HttpPost]
        public ActionResult Post(Client client)
        {
            _context.Clients.Add(client);
            //if(newClient is null) return BadRequest();
            _context.SaveChanges();
            return new CreatedAtRouteResult("client", new { id = client.ClientId }, client);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Client client)
        {
            if (id != client.ClientId) return BadRequest();
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(client);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.ClientId == id);
            if (client is null) return NotFound();
            _context.Clients.Remove(client);
            _context.SaveChanges();
            return Ok(client);
        }
    }
}
