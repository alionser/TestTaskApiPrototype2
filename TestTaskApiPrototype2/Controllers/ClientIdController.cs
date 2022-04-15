using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TestTaskApiPrototype2.Models;
using TestTaskApiPrototype2.Models.Responses;


namespace TestTaskApiPrototype2.Controllers
{
    [Route("api/{clientId}")]
    public class ClientIdController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ClientIdController> _log;

        public ClientIdController(ApplicationContext context,
            ILogger<ClientIdController> log)
        {
            _context = context;
            _log = log;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser([FromRoute] Guid clientId) //TODO: разобратсья с explode
        {
            var request = ControllerContext.HttpContext.Request;
            _log.LogInformation($"{request.Method} {request.Path + request.QueryString}");

            try
            {
                var client = _context.Clients.Where(c => c.Id == clientId)
                    .Include(c => c.Passport)
                    .Include(c => c.Children)
                    .Include(c => c.Communications)
                    .Include(c => c.Documents)
                    .Include(c => c.Jobs).ThenInclude(j => j.Address)
                    .Include(c => c.Jobs).ThenInclude(j => j.PhoneNumbers)
                    .Include(c => c.LivingAddress)
                    .Include(c => c.RegAddress)
                    .Include(c => c.Files)
                    .FirstOrDefault();

                _log.LogInformation($"{client.Id} {client.Name} was found!");
                Console.WriteLine(client.Name, Encoding.UTF8);

                return new JsonResult(client) {StatusCode = 200};
            }
            catch (Exception e) //TODO: добавить нормальные исключения
            {
                return new JsonResult(new ServerError(404, "CLIENT_WASNT_FOUND", "Client wasn't found!")) {StatusCode = 400};
            }

            return Ok();
        }
    }
}