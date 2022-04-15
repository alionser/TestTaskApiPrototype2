using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskApiPrototype2.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TestTaskApiPrototype2.Models.Responses;
using TestTaskApiPrototype2.Utils;

namespace TestTaskApiPrototype2.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ClientsController> _log;

        public ClientsController(ApplicationContext context, ILogger logger, ILogger<ClientsController> log)
        {
            _context = context;
            _log = log;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients(string query)
        {
            var clients = _context.Clients // разобраться попродробнее
                .Include(c => c.Passport)
                .Include(c => c.Children)
                .Include(c => c.Communications)
                .Include(c => c.Documents)
                .Include(c => c.Jobs).ThenInclude(j => j.Address)
                .Include(c => c.Jobs).ThenInclude(j => j.PhoneNumbers)
                .Include(c => c.LivingAddress)
                .Include(c => c.RegAddress)
                .Include(c => c.Files);

            return await clients.ToListAsync();
        }

        [HttpPut]
        public async Task<IActionResult> PutClient()
        {
            var request = ControllerContext.HttpContext.Request;

            if (request.ContentType == "application/json")
            {
                Console.WriteLine("GOT JSON");
                var reader =
                    request.ReadFromJsonAsync<Client>(); //TODO: десериализцаия перечислений, отправленых строками
                Client client = await reader;

                await using (_context)
                {
                    _context.Clients.Add(client);
                    await _context.SaveChangesAsync();

                    return new JsonResult(client);
                }
            }
            else
            {
                Console.WriteLine("NOT JSON");
                var result = new JsonResult(new ServerError(400, "WRONG_CONTENT_TYPE", "Получен не JSON"))
                {
                    StatusCode = 400
                };
                return result;
            }
        }
    }
}