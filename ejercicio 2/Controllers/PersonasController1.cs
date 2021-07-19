using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio_2.Controllers
{
    public class PersonasController1 : Controller
    {
        // GET: PersonasController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonasController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PersonasController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController1/Edit/5
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

        // GET: PersonasController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController1/Delete/5
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
