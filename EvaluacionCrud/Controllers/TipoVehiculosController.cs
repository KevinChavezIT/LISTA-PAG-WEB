using DatosVehiculo.Model;
using DatosVehiculo.ModelosNuevos;
using DatosVehiculo.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionCrud.Controllers
{
    public class TipoVehiculosController : Controller
    {
        private readonly EjercicioEvaluacionContext _context;

        public TipoVehiculosController(EjercicioEvaluacionContext context)
        {
            _context = context;
        }

        public void Combox()
        {
            ViewData["CodigoVehiculo"] = new SelectList(_context.Vehiculo.Select(v => new ViewModelTipoVehiculo 
            {
                Codigo= v.Codigo,
                Nombres= $"{v.Nombre}",
                Estado=v.Estado

            }).Where(v => v.Estado ==1) .ToList(), "Codigo","Nombres");
        }

        // GET: VehiculosController
        public ActionResult Index()
        {
            // List<TipoVehiculo> listipo = _context.TipoVehiculo.ToList();
            List<ViewModelTipoVehiculo> listipo = _context.TipoVehiculo.Select(v => new ViewModelTipoVehiculo
            {
                Nombres = $"{v.CodigoVehiculoNavigation.Nombre}",
                DescripcionVehiculo =v.Descripcion,                            
                Estado = v.Estado

            }).ToList();
            return View(listipo);
        }

        // GET: VehiculosController/Details/5
        public ActionResult Details(int id)
        {
            TipoVehiculo tipoVehiculo = _context.TipoVehiculo.Where(v => v.Codigo == id).FirstOrDefault();

            return View(tipoVehiculo);
        }

        // GET: VehiculosController/Create
        public ActionResult Create()
        {
            Combox();
            return View();
        }

        // POST: VehiculosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoVehiculo tipoVehiculo)
        {
            try
            {
                tipoVehiculo.Estado = 1;
                _context.Add(tipoVehiculo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                Combox();
                return View(tipoVehiculo);
            }
        }

        // GET: VehiculosController/Edit/5
        public ActionResult Edit(int id)
        {
            Combox();
            TipoVehiculo tipoVehiculo = _context.TipoVehiculo.Where(v => v.Codigo == id).FirstOrDefault();

            return View(tipoVehiculo);
        }

        // POST: VehiculosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoVehiculo tipoVehiculo)
        {
            if (id != tipoVehiculo.Codigo)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _context.Update(tipoVehiculo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                Combox();
                return View();
            }
        }

        // GET: VehiculosController/Delete/5
        public ActionResult Desactivar(int id)
        {
            TipoVehiculo tipoVehiculo = _context.TipoVehiculo.Where(v => v.Codigo == id).FirstOrDefault();
            tipoVehiculo.Estado = 0;
            _context.Update(tipoVehiculo);
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
