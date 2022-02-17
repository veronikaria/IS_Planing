using ISPlaning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ISPlaning.Controllers
{
    [Authorize]
    public class ChartController : Controller
    {
        private readonly ApplicationContext db;

        public ChartController(ApplicationContext db)
        {
            this.db = db;
        }

        public IActionResult Index(SortChartState sortOrder = SortChartState.Default)
        {
            List<Chart> charts = this.db.Charts.ToList();

            ViewData["NameSort"] = sortOrder == SortChartState.NameAsc ? SortChartState.NameDesc : SortChartState.NameAsc;
            ViewData["DateSort"] = sortOrder == SortChartState.DateAsc ? SortChartState.DateDesc : SortChartState.DateAsc;

            charts = sortOrder switch
            {
                SortChartState.Default => charts,
                SortChartState.NameAsc => charts.OrderBy(c => c.Name).ToList(),
                SortChartState.NameDesc => charts.OrderByDescending(c => c.Name).ToList(),
                SortChartState.DateAsc => charts.OrderBy(c => c.Date).ToList(),
                SortChartState.DateDesc => charts.OrderByDescending(c => c.Date).ToList(),
                _ => charts.OrderBy(c => c.Name).ToList(),
            };
            return View(charts);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Chart chart)
        {
            if (ModelState.IsValid)
            {
                this.db.Charts.Add(chart);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chart);
        }
    }
}
