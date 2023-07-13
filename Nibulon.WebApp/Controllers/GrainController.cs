using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nibulon.WebApp.Models;
using Nibulon.WebApp.Services;
using Nibulon.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nibulon.WebApp.Controllers
{
    public class GrainController : Controller
    {
        private readonly IGrainManipulation _grainManipulation;

        public GrainController(IGrainManipulation grainManipulation)
        {
            _grainManipulation = grainManipulation;
        }
        // GET: GrainController
        public ActionResult Index([FromQuery] DateTime start,
            [FromQuery] DateTime end)
        {
            GrainMoving grainMoving = new();
            grainMoving.Table_1 = _grainManipulation.ReadJson();
            grainMoving.Table_2 = grainMoving.Table_1
                .OrderBy(p => p.RecordDate)
                .ThenBy(p => p.CounterpartyId)
                .ThenBy(p => p.CounterpartyName)
                .ThenBy(p => p.ContactId)
                .ThenBy(p => p.Product)
                .ThenBy(p => p.Process)
                .Where(p => p.RecordDate >= start && p.RecordDate <= end)
                .ToList();
            var table_3 = from person in grainMoving.Table_2
                          group person by new
                          {
                              person.RecordDate,
                              person.CounterpartyId,
                              person.CounterpartyName,
                              person.Product,
                              person.Process
                          } into g
                          select new
                          {
                              g.Key.RecordDate,
                              g.Key.CounterpartyId,
                              g.Key.CounterpartyName,
                              g.Key.Product,
                              g.Key.Process,
                              Price = g.Average(p => p.Price),
                              Amount = g.Sum(p => p.Amount),
                              WetnessSum = g.Sum(p => p.Amount * p.Wetness),
                              GarbageSum = g.Sum(p => p.Amount * p.Garbage)
                          };


        //public class ConsolidatedChild
        //{
        //    public string School { get; set; }
        //    public string Friend { get; set; }
        //    public string FavoriteColor { get; set; }
        //    public List<Child> Children { get; set; }
        //}

        //public class Child
        //{
        //    public string School { get; set; }
        //    public string Name { get; set; }
        //    public string Address { get; set; }
        //    public string Friend { get; set; }
        //    public string Mother { get; set; }
        //    public string FavoriteColor { get; set; }
        //}

        //var consolidatedChildren =
        //children
        //    .GroupBy(c => new
        //    {
        //        c.School,
        //        c.Friend,
        //        c.FavoriteColor,
        //    })
        //    .Select(gcs => new ConsolidatedChild()
        //    {
        //        School = gcs.Key.School,
        //        Friend = gcs.Key.Friend,
        //        FavoriteColor = gcs.Key.FavoriteColor,
        //        Children = gcs.ToList(),
        //});

        grainMoving.Table_3 = new List<Grain>();
            foreach (var item in table_3)
            {
                grainMoving.Table_3.Add(
                    new Grain
                    {
                        RecordDate = item.RecordDate,
                        CounterpartyName = item.CounterpartyName,
                        Product = item.Product,
                        Process = item.Process,
                        Price = item.Price,
                        Amount = item.Amount,
                        Wetness = item.WetnessSum / item.Amount,
                        Garbage = item.GarbageSum / item.Amount
                    });
            }

            return View(grainMoving);
        }

        // GET: GrainController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GrainController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrainController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Grain grain)
        {
            try
            {
                List<Grain> Grain = new();
                Grain = _grainManipulation.ReadJson();
                grain.Wetness = (decimal)grain.Wetness;
                Grain.Add(grain);
                _grainManipulation.WriteJson(Grain);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GrainController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GrainController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GrainController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GrainController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
