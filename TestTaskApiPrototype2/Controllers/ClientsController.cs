using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskApiPrototype2.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TestTaskApiPrototype2.Models.Responses;

namespace TestTaskApiPrototype2.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly ApplicationContext _context;

        public ClientsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            Console.WriteLine(ControllerContext.HttpContext.Request.Path);
            return await _context.Clients.ToListAsync();
        }

        [HttpPut]
        public async Task<IActionResult> PutClient()
        {
            var request = ControllerContext.HttpContext.Request;
            if (request.ContentType == "application/json")
            {
                Console.WriteLine("GOT JSON");
                Client client = new Client();

                _context.Clients.Add(client);
                client.TypeEducation = EducationType.Higher;
                client.Status = StatusType.Lead;
                client.MaritalStatus = MaritalStatusType.Married;
                client.TypeEmp = EmpType.Owner;
                await _context.SaveChangesAsync();

                var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
                options.Converters.Add(new JsonStringEnumConverter());
                return new JsonResult(client, options);
            }
            else
            {
                Console.WriteLine("NOT JSON");
                var result = new JsonResult(new ServerError(400, "WRONG_CONTENT_TYPE", "Получен не JSON"));
                result.StatusCode = 400;
                return result;
            }
        }

    }
}