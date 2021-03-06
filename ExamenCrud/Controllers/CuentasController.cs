using DatosCrud.Models;
using ExamenCrud.Data;
using ExamenCrud.Models;
using ExamenCrud.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCrud.Controllers
{
    [Authorize]
    public class CuentasController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public CuentasController (ApplicationDbContext applicationDbContext )
        {
            _applicationDbContext = applicationDbContext;
        }

        private void Combox()
        {
            ViewData["CodigoSocio"] = new SelectList(_applicationDbContext.Socios.Select(s => new SocioCuenta
            {
                CedulaSocio = s.Cedula,
                NombreSocio = $"{s.Nombre } {s.Apellido }",
                Estado = s.Estado

            }).Where(c => c.Estado == 1).ToList(), "CedulaSocio", "NombreSocio");
        }
        [Authorize(Roles = "Boss,Persona")]
        // GET: CuentasController
        public ActionResult Index()
        {
            List<SocioCuenta> listcuenta = new List<SocioCuenta>();
            listcuenta = _applicationDbContext.Cuenta.Select(s => new SocioCuenta
            {
                NumCuenta=s.Numero,
                Saldo=s.SaldoTotal,
                NombreSocio = $"{s.CodigoSocioNavigation.Nombre } {s.CodigoSocioNavigation.Apellido }",
                Estado = s.Estado

            }).ToList();

            return View(listcuenta);
        }
        [Authorize(Roles = "Boss,Persona")]
        // GET: CuentasController/Details/5
        public ActionResult Details(string id)
        {
            Cuenta cuenta = _applicationDbContext.Cuenta.Where(c => c.Numero == id).FirstOrDefault();

            return View(cuenta);
        }

        [Authorize(Roles = "Boss")]
        // GET: CuentasController/Create
        public ActionResult Create()
        {
            Combox();
            return View();
        }

        [Authorize(Roles = "Boss")]
        // POST: CuentasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cuenta cuenta)
        {
            try
            {
                cuenta.Estado = 1; 
                _applicationDbContext.Add(cuenta);
                _applicationDbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(cuenta);
            }
        }

        [Authorize(Roles = "Boss")]
        // GET: CuentasController/Edit/5
        public ActionResult Edit(string id)
        {
            Combox();
            Cuenta cuenta = _applicationDbContext.Cuenta.Where(c => c.Numero == id).FirstOrDefault();
          

            return View(cuenta);
        }

        [Authorize(Roles = "Boss")]
        // POST: CuentasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Cuenta cuenta)
        {
            if (id != cuenta.CodigoSocio)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _applicationDbContext.Update(cuenta);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Combox();
                return View(cuenta);
            }
        }

        [Authorize(Roles = "Boss")]
        // GET: CuentasController/Delete/5
        public ActionResult Activar(string id)
        {
            Cuenta cuenta = _applicationDbContext.Cuenta.Where(c => c.Numero == id).FirstOrDefault();
            cuenta.Estado = 1;
            _applicationDbContext.Update(cuenta);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Boss")]
        public ActionResult Desactivar(string id)
        {
            Cuenta cuenta = _applicationDbContext.Cuenta.Where(c => c.Numero == id).FirstOrDefault();
            cuenta.Estado = 0;
            _applicationDbContext.Update(cuenta);
            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");      
        }
    }
}
