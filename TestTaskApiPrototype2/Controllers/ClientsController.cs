using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskApiPrototype2.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TestTaskApiPrototype2.Models.Responses;


namespace TestTaskApiPrototype2.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ClientsController> _log;

        public ClientsController(ApplicationContext context,
            ILogger<ClientsController> log)
        {
            _context = context;
            _log = log;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients(
            string query = "",
            string sortBy = "createdAt",
            string sortDit = "desc",
            int page = 1,
            int limitPerPage = 10)
        {
            var request = ControllerContext.HttpContext.Request;
            _log.LogInformation($"{Request.Method} {request.Path + request.QueryString}");



            var clients = _context.Clients // разобраться попродробнее, SplitQuery
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
            _log.LogInformation($"{Request.Method} {request.Path + request.QueryString}");

            if (request.ContentType == "application/json")
            {

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
                var result = new JsonResult(new ServerError(400, "WRONG_CONTENT_TYPE", "Получен не JSON"))
                {
                    StatusCode = 400
                };
                return result;
            }
        }
    }
}