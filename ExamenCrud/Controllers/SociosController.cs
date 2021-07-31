using ExamenCrud.Data;
using ExamenCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCrud.Controllers
{
    public class SociosController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SociosController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
        }

        // GET: SociosController
        public ActionResult Index()
        {
            List<Socio> listsocios = new List<Socio>();
            listsocios = _applicationDbContext.Socios.ToList();

            return View(listsocios);
        }

        // GET: SociosController/Details/5
        public ActionResult Details(string id)
        {
            Socio socio = _applicationDbContext.Socios.Where(s => s.Cedula == id).FirstOrDefault();

            return View(socio);
        }

        // GET: SociosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SociosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Socio socio)
        {
            try
            {
                socio.Estado = 1;
                _applicationDbContext.Add(socio);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(socio);
            }
        }

        // GET: SociosController/Edit/5
        public ActionResult Edit(string id)
        {
            Socio socio = _applicationDbContext.Socios.Where(s => s.Cedula == id).FirstOrDefault();

            return View(socio);
        }

        // POST: SociosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Socio socio)
        {
            if (id != socio.Cedula)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _applicationDbContext.Update(socio);
                _applicationDbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(socio);
            }
        }
        public ActionResult Activar(string id)
        {
            Socio socio = _applicationDbContext.Socios.Where(s => s.Cedula == id).FirstOrDefault();
            socio.Estado = 1;
            _applicationDbContext.Update(socio);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Desactivar(string id)
        {
            Socio socio = _applicationDbContext.Socios.Where(s => s.Cedula == id).FirstOrDefault();
            socio.Estado = 0;
            _applicationDbContext.Update(socio);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
            
        }

    }
}
