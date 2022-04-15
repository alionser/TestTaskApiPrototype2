using System.Threading.Tasks;
using TestTaskApiPrototype2.Models;
using TestTaskApiPrototype2.Models.Responses;
using TestTaskApiPrototype2.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestTaskApiPrototype2.Controllers
{
    [Route("api/[controller]")]
    public class AddRandomClientsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<AddRandomClientsController> _log;

        public AddRandomClientsController(ApplicationContext context, ILogger<AddRandomClientsController> log)
        {
            _context = context;
            _log = log;
        }

        [HttpPost] // или через put?
        public async Task<IActionResult> PostRandomClients(int? count) //Task?
        {
            _log.LogInformation("Start adding random clients");
            var clients = Mocker.CreateRandomClients(count ?? 5);
            await _context.Clients.AddRangeAsync(clients);
            await _context.SaveChangesAsync();
            _log.LogInformation($"Add {count} random clients");


            var resultJsonModel = new ClientsPaginationAll {Data = clients};
            return  new JsonResult(resultJsonModel) {StatusCode = 200};
        }

    }
}