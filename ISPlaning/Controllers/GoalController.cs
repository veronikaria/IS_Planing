using ISPlaning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ISPlaning.Controllers
{
    [Authorize]
    public class GoalController : Controller
    {
        private readonly ApplicationContext db;

        public GoalController(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Goal> goals = this.db.Goals.ToList();
            return View(goals);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Goal goal)
        {
            if (ModelState.IsValid)
            {
                this.db.Goals.Add(goal);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goal);
        }

        public IActionResult Change(int? id)
        {
            if (id != null)
            {
                Goal goal = db.Goals.FirstOrDefault(p => p.Id == id);
                if (goal != null)
                    return View(goal);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Change(Goal goal)
        {
            db.Goals.Update(goal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Goal goal = db.Goals.FirstOrDefault(p => p.Id == id);
                if (goal != null)
                {
                    db.Goals.Remove(goal);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Goal goal = db.Goals.FirstOrDefault(p => p.Id == id);
                if (goal != null)
                    return View(goal);
            }
            return NotFound();
        }

    }
}
