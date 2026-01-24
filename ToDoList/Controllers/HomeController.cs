using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDBContext _db = new();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateUsers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUsers(Person person)
        {
            _db.Users.Add(person);
            _db.SaveChanges();
            return RedirectToAction(
                    "taskIndex",
                    "Task",
                    new { id = person.Id }
                );
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
