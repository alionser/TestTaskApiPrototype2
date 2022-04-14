using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskApiPrototype2.Models;
using System.Threading.Tasks;
using System.Collections.Generic; //TODO: SORR USINGS DIRECTIVES


namespace TestTaskApiPrototype2.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController
    {
        private readonly ApplicationContext _context;

        public ClientsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

    }
}