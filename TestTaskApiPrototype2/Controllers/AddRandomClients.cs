using System.Threading.Tasks;
using TestTaskApiPrototype2.Models;
using TestTaskApiPrototype2.Models.Responses;
using TestTaskApiPrototype2.Utils;
using Microsoft.AspNetCore.Mvc;

namespace TestTaskApiPrototype2.Controllers
{
    [Route("api/[controller]")]
    public class AddRandomClients : Controller
    {
        private readonly ApplicationContext _context;

        public AddRandomClients(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost] // или через put?
        public IActionResult PostRandomClients(int? count) //Task?
        {
            var clients = Mocker.CreateRandomClients(count ?? 5);
            _context.Clients.AddRange(clients);
            _context.SaveChanges();

            var resultJsonModel = new ClientsPaginationAll {Data = clients};
            return  new JsonResult(resultJsonModel) {StatusCode = 200};
        }

    }
}