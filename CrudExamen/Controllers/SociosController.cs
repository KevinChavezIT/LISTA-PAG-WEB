using CrudExamen.Data;
using CrudExamen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudExamen.Controllers
{
    public class SociosController : Controller
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public SociosController(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }
        public ActionResult Index()
        {
            List<Socio> usarios = new List<Socio>();
            usarios = _ApplicationDbContext.Socio.ToList();

            return View(usarios);

        }
        public ActionResult Details(int id)
        {
            if (id==0)
                return RedirectToAction("Index");

            Socio socio = _ApplicationDbContext.Socio.Where(s => s.Cedula == id).FirstOrDefault();

            return View(socio);
        }

        
        public ActionResult Create()
        {
            return View();
        }     
        [HttpPost]       
        public ActionResult Create(Socio socio)
        {
            try
            {
                socio.Cedula = 1;
                _ApplicationDbContext.Add(socio);
                _ApplicationDbContext.SaveChanges();
            }
            catch(Exception)
            {
                return View(socio);
            }
            return RedirectToAction("Index");
        }

        
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            Socio socio = _ApplicationDbContext.Socio.Where(s => s.Cedula == id).FirstOrDefault();
            if (socio==null)
                return RedirectToAction("Index");

            return View(socio);
        }

     
        [HttpPost]       
        public ActionResult Edit(int id, Socio socio)
        {
            if (id != socio.Cedula)
                return RedirectToAction("Index");
            try
            {              
                _ApplicationDbContext.Update(socio);
                _ApplicationDbContext.SaveChanges();
                
            }
            catch(Exception)
            {
                return View(socio);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Desactivar(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            Socio socio = _ApplicationDbContext.Socio.Where(s => s.Cedula == id).FirstOrDefault();
            try
            {
                socio.Estado = 0;

                _ApplicationDbContext.Update(socio);
                _ApplicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Activar(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            Socio socio = _ApplicationDbContext.Socio.Where(s => s.Cedula == id).FirstOrDefault();

            try
            {
                socio.Estado = 1;

                _ApplicationDbContext.Update(socio);
                _ApplicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
