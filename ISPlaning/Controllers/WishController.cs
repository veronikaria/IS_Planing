using ISPlaning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ISPlaning.Controllers
{
    [Authorize]
    public class WishController : Controller
    {
        private readonly ApplicationContext db;

        public WishController(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Wish> wishes = this.db.Wishes.ToList();
            return View(wishes);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Wish wish)
        {
            if (ModelState.IsValid)
            {
                this.db.Wishes.Add(wish);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wish);
        }

        public IActionResult Change(int? id)
        {
            if (id != null)
            {
                Wish wish = db.Wishes.FirstOrDefault(p => p.Id == id);
                if (wish != null)
                    return View(wish);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Change(Wish wish)
        {
            db.Wishes.Update(wish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Wish wish = db.Wishes.FirstOrDefault(p => p.Id == id);
                if (wish != null)
                {
                    db.Wishes.Remove(wish);
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
                Wish wish = db.Wishes.FirstOrDefault(p => p.Id == id);
                if (wish != null)
                    return View(wish);
            }
            return NotFound();
        }
    }
}
