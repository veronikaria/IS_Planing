using ISPlaning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ISPlaning.Controllers
{
    [Authorize]
    public class FundsController: Controller
    {
        private readonly ApplicationContext db;

        public FundsController(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult Index(SortFundState sortOrder = SortFundState.Default)
        {
            List<Funds> funds = this.db.Funds.ToList();

            ViewData["NameSort"] = sortOrder == SortFundState.NameAsc ? SortFundState.NameDesc : SortFundState.NameAsc;
            ViewData["MoneySort"] = sortOrder == SortFundState.MoneyAsc ? SortFundState.MoneyDesc : SortFundState.MoneyAsc;

            funds = sortOrder switch
            {
                SortFundState.Default => funds,
                SortFundState.NameDesc => funds.OrderByDescending(f => f.Name).ToList(),
                SortFundState.NameAsc => funds.OrderBy(f => f.Name).ToList(),
                SortFundState.MoneyAsc => funds.OrderBy(f=>f.Uah).ToList(),
                SortFundState.MoneyDesc => funds.OrderByDescending(f=>f.Uah).ToList(),
                _ => funds.OrderBy(f => f.Name).ToList(),
            };
            return View(funds);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Funds fund)
        {
            if (ModelState.IsValid)
            {
                this.db.Funds.Add(fund);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fund);
        }

        public IActionResult Change(int? id)
        {
            if (id != null)
            {
                Funds fund = db.Funds.FirstOrDefault(p => p.Id == id);
                if (fund != null)
                    return View(fund);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Change(Funds fund)
        {
            db.Funds.Update(fund);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Funds fund = db.Funds.FirstOrDefault(p => p.Id == id);
                if (fund != null)
                {
                    db.Funds.Remove(fund);
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
                Funds fund = db.Funds.FirstOrDefault(p => p.Id == id);
                if (fund != null)
                    return View(fund);
            }
            return NotFound();
        }
    }
}
