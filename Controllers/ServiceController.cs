using APILucasSantosPortfolio.Context;
using APILucasSantosPortfolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace APILucasSantosPortfolio.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ServiceController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        // Get all Services stored in the Database;
        [HttpGet]
        public ActionResult<IEnumerable<Service>> Get()
        {
            try
            {

                var services = _context.Services.ToList();
                if (services is null)
                {
                    throw new Exception("Not found the sercies requested");
                }
                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, "We didn't found any data try it again!");
            }
        }
        // Register an new service in the database;
        [HttpPost]
        public ActionResult<Service> Post(Service service)
        {
            try
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return new CreatedAtRouteResult("client", new { id = service.ClientId }, service);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Try to verify if the data that you've submited is corretly provided!");
            }

        }
        // Get a unique service by id
        [HttpGet("{id:int}", Name = "service")]
        public ActionResult<Service> Get(int id)
        {
            try
            {
                var service = _context.Services.FirstOrDefault(s => s.ServiceId == id);
                if (service == null) throw new Exception();
                return Ok(service);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, "We've not found the service requested");
            }
        }
    }
}
