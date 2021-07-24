using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    [Authorize]
    public class GenerosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenerosController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "jefe,empleado")]
        // GET: GenerosController
        public ActionResult Index()
        {
            List<Genero> lisgenero = _context.Generos.ToList();

            return View(lisgenero);
        }
        [Authorize(Roles = "jefe,empleado")]
        // GET: GenerosController/Details/5
        public ActionResult Details(int id)
        {
           Genero genero = _context.Generos.FirstOrDefault(p => p.Codigo== id );

            return View(genero);
        }
        [Authorize(Roles = "jefe")]
        // GET: GenerosController/Create
        public ActionResult Create()
        {
             

            return View();
        }
        [Authorize(Roles = "jefe")]
        // POST: GenerosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genero genero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     _context.Add(genero);
                     _context.SaveChanges();
                    return RedirectToAction(("Index"));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(genero);
            }
        }
        [Authorize(Roles = "jefe")]
        // GET: GenerosController/Edit/5
        public ActionResult Edit(int id)
        {
            Genero genero = _context.Generos.FirstOrDefault(p => p.Codigo == id);
            return View(genero);
        }
        [Authorize(Roles = "jefe")]
        // POST: GenerosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Genero genero)
        {
            if (id != genero.Codigo)
            {
                return RedirectToAction("Index");
            };
            try
            {
                _context.Update(genero);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(genero);
            }
        }
        [Authorize(Roles = "jefe")]
        // GET: GenerosController/Delete/5
        public IActionResult Desactivar(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            Genero persona = _context.Generos.Where(p => p.Codigo == id).FirstOrDefault();

            try
            {
                persona.Estado = 0;

                _context.Update(persona);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "jefe")]
        public IActionResult Activar(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            Genero persona = _context.Generos.Where(p => p.Codigo == id).FirstOrDefault();

            try
            {
                persona.Estado = 1;

                _context.Update(persona);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
