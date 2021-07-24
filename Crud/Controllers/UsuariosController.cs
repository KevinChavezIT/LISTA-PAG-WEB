using Crud.Data;
using Crud.Models;
using Crud.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Controllers
{
     [Authorize]
    public class UsuariosController : Controller
    {   
        private readonly ApplicationDbContext _applicationDbContext;

        public UsuariosController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [Authorize(Roles = "jefe,empleado")]
        public IActionResult Index()
        {
            List<PersonaViewModel> usarios = new List<PersonaViewModel>();
            usarios = _applicationDbContext.Persona.Select(p => new PersonaViewModel
            {
                Codigo= p.Codigo,
                Nombre=p.Nombre,
                Apellido=p.Apellido,
                Estado=p.Estado,
                Direccion=p.Direccion,
                DescripcionGenero=p.CodigoGeneroNavigation.Descripcion

            }).ToList();

            return View(usarios);
        }

          [Authorize(Roles = "jefe,empleado")]
        public IActionResult Details(int id)
        {
            if (id== 0)
                return RedirectToAction("Index");

            Persona persona = _applicationDbContext.Persona.Where(p => p.Codigo == id).FirstOrDefault();
            if (persona==null)
                return RedirectToAction("Index");

           return View(persona);
        }

           [Authorize(Roles = "jefe")]
        public IActionResult Create()
        {
            ViewData["CodigoGenero"] = new SelectList(_applicationDbContext.Generos.Where(p => p.Estado == 1).ToList(),"Codigo","Descripcion");          
            return View();
        }

           [Authorize(Roles = "jefe")]
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
                ViewData["CodigoGenero"] = new SelectList(_applicationDbContext.Generos.Where(p => p.Estado == 1).ToList(), "Codigo", "Descripcion", persona.CodigoGenero);

                return View(persona);
            }
            return RedirectToAction("Index");
        }

          [Authorize(Roles = "jefe")]
        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Index");
            }

            Persona persona = _applicationDbContext.Persona.Where(p => p.Codigo == id).FirstOrDefault();
            
            if(persona==null)
                return RedirectToAction("Index");

            ViewData["CodigoGenero"] = new SelectList(_applicationDbContext.Generos.Where(p => p.Estado == 1).ToList(), "Codigo", "Descripcion", persona.CodigoGenero);

            return View(persona);
        }

        [Authorize(Roles = "jefe")]
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
                ViewData["CodigoGenero"] = new SelectList(_applicationDbContext.Generos.Where(p => p.Estado == 1).ToList(), "Codigo", "Descripcion", persona.CodigoGenero);

                return View(persona);
            }
            return RedirectToAction("Index");
        }

         [Authorize(Roles = "jefe")]
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

        [Authorize(Roles = "jefe")]
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
