
using DatosVehiculo.Model;
using DatosVehiculo.ModelosNuevos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionCrud.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly EjercicioEvaluacionContext _context;

        public VehiculosController(EjercicioEvaluacionContext context)
        {
            _context = context;
        }

        // GET: VehiculosController
        public ActionResult Index()
        {
            List<Vehiculo> listvehi = _context.Vehiculo.ToList();

            return View(listvehi);
        }

        // GET: VehiculosController/Details/5
        public ActionResult Details(int id)
        {
            Vehiculo vehiculo = _context.Vehiculo.Where(v => v.Codigo == id).FirstOrDefault();

            return View(vehiculo);
        }

        // GET: VehiculosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiculosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehiculo vehiculo)
        {
            try
            {
                vehiculo.Estado = 1;
                _context.Add(vehiculo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(vehiculo);
            }
        }

        // GET: VehiculosController/Edit/5
        public ActionResult Edit(int id)
        {
            Vehiculo vehiculo = _context.Vehiculo.Where(v => v.Codigo == id).FirstOrDefault();

            return View(vehiculo);
        }

        // POST: VehiculosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Codigo)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _context.Update(vehiculo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculosController/Delete/5
        public ActionResult Desactivar(int id)
        {
            Vehiculo vehiculo = _context.Vehiculo.Where(v => v.Codigo == id).FirstOrDefault();
            vehiculo.Estado = 0;
            _context.Update(vehiculo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Activar(int id)
        {
            Vehiculo vehiculo = _context.Vehiculo.Where(v => v.Codigo == id).FirstOrDefault();
            vehiculo.Estado = 1;
            _context.Update(vehiculo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
