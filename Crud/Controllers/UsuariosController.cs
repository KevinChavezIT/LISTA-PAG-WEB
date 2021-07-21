using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public UsuariosController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }
        public IActionResult Index()
        {
            List<Persona> usarios = new List<Persona>();
            usarios = _applicationDbContext.Persona.ToList();

            return View(usarios);
        }
        public IActionResult Details(int id)
        {
            if (id== 0)
                return RedirectToAction("Index");

            Persona persona = _applicationDbContext.Persona.Where(p => p.Codigo == id).FirstOrDefault();
            if (persona==null)
                return RedirectToAction("Index");

            return View(persona);
        }
        public IActionResult Create()
        {     
            return View();
        }
        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            try
            {
                persona.Estado = 1;

             _applicationDbContext.Add(persona);
            _applicationDbContext.SaveChanges();
            }
            catch(Exception)
            {
                return View(persona);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Index");
            }

            Persona persona = _applicationDbContext.Persona.Where(p => p.Codigo == id).FirstOrDefault();
            
            if(persona==null)
                return RedirectToAction("Index");

            return View(persona);
        }
        [HttpPost]
        public IActionResult Edit(int id, Persona persona)
        {
            if (id != persona.Codigo)
                return RedirectToAction("Index");

            try
            {               
                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return View(persona);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            Persona persona = _applicationDbContext.Persona.Where(p => p.Codigo == id).FirstOrDefault();

            try
            {
                _applicationDbContext.Remove(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        public IActionResult Desactivar(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            Persona persona = _applicationDbContext.Persona.Where(p => p.Codigo == id).FirstOrDefault();

            try
            {
                persona.Estado = 0;

                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        public IActionResult Activar(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            Persona persona = _applicationDbContext.Persona.Where(p => p.Codigo == id).FirstOrDefault();

            try
            {
                persona.Estado = 1;

                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
