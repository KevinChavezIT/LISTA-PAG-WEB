using CrudExamen.Data;
using CrudExamen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudExamen.Controllers
{
    public class CuentasController : Controller
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public CuentasController(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }
        public ActionResult Index()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            cuentas = _ApplicationDbContext.Cuenta.ToList();

            return View(cuentas);

        }
        public ActionResult Details(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");

            Cuenta cuenta = _ApplicationDbContext.Cuenta.Where(s => s.Numero == id).FirstOrDefault();

            return View(cuenta);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cuenta cuenta)
        {
            try
            {
                cuenta.Numero = 1;
                _ApplicationDbContext.Add(cuenta);
                _ApplicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return View(cuenta);
            }
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            Cuenta cuenta = _ApplicationDbContext.Cuenta.Where(s => s.Numero == id).FirstOrDefault();
            if (cuenta == null)
                return RedirectToAction("Index");

            return View(cuenta);
        }

        [HttpPost]
        public ActionResult Edit(int id, Cuenta cuenta)
        {
            if (id != cuenta.Numero)
                return RedirectToAction("Index");
            try
            {
                _ApplicationDbContext.Update(cuenta);
                _ApplicationDbContext.SaveChanges();

            }
            catch (Exception)
            {
                return View(cuenta);
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

            Cuenta cuenta = _ApplicationDbContext.Cuenta.Where(s => s.Numero == id).FirstOrDefault();
            try
            {
                cuenta.Estado = 0;

                _ApplicationDbContext.Update(cuenta);
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

            Cuenta cuenta = _ApplicationDbContext.Cuenta.Where(s => s.Numero == id).FirstOrDefault();

            try
            {
                cuenta.Estado = 1;

                _ApplicationDbContext.Update(cuenta);
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
