using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccess;
using ToDoList.Models;
using ToDoList.ViewModel;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private ApplicationDBContext _db = new();
        

        public IActionResult taskIndex(int id)
        {
            var missions = _db.Tasks
                .Where(m => m.PersonId == id)
                .ToList();

            var person = _db.Users.FirstOrDefault(p => p.Id == id);
            if (person == null) return NotFound();

            return View(new PersonMissionVM
            {
                Person = person,
                missions = missions
            });
        }

        [HttpGet]
        public IActionResult Create(int personId)
        {
            var person = _db.Users.Find(personId);
            if (person == null) return NotFound();

            var mission = new Mission
            {
                PersonId = personId,
                CreatedAt = DateTime.Now
            };

            return View(mission);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mission mission, IFormFile? file)
        {
            if (!ModelState.IsValid) return View(mission);

            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                mission.FilePath = "/uploads/" + uniqueFileName; 
            }

            _db.Tasks.Add(mission);
            _db.SaveChanges();

            return RedirectToAction("taskIndex", new { id = mission.PersonId });
        }

        // ✅ GET Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var mission = _db.Tasks.Find(id);
            if (mission == null) return NotFound();

            return View(mission);
        }

        // ✅ POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Mission mission)
        {
            if (!ModelState.IsValid) return View(mission);

            _db.Tasks.Update(mission);
            _db.SaveChanges();

            return RedirectToAction("taskIndex", new { id = mission.PersonId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var mission = _db.Tasks.Find(id);
            if (mission == null) return NotFound();

            int personId = mission.PersonId;
            _db.Tasks.Remove(mission);
            _db.SaveChanges();

            return RedirectToAction("taskIndex", new { id = personId });
        }


        // ✅ Details
        public IActionResult Details(int id)
        {
            var mission = _db.Tasks
                .Include(m => m.Person)
                .FirstOrDefault(m => m.Id == id);

            if (mission == null) return NotFound();
            return View(mission);
        }
    }
}
