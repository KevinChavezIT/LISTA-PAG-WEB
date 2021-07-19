using ejercicio_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio_1.Controllers
{
    public class PersonasController : Controller
    {
        
        // GET: PersonasController
        public ActionResult Index()
        {            
            List<Persona> ltspersona = new List<Persona>();

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("listapersona")))
            {
                Persona perso = new Persona();

                perso.Cedula    = "0050083080";
                perso.Nombres   = "Kevin Daniel";
                perso.Apellidos = "Chavez Tubon";
                perso.Direccion = "La Magdalena";
                perso.Genero    = "Masculino";
                for (int p = 0; p < 1; p++)
                {
                    ltspersona.Add(perso);
                }
            }
            else
            {
                ltspersona= JsonConvert.DeserializeObject<List<Persona>>(HttpContext.Session.GetString("listapersona"));
            }

            HttpContext.Session.SetString("listapersona", JsonConvert.SerializeObject(ltspersona));
            
            return View(ltspersona);
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasController/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Persona persona)
        {
            try
            {
                List<Persona> per = new List<Persona>();

                per = JsonConvert.DeserializeObject<List<Persona>>(HttpContext.Session.GetString("listapersona"));
                per.Add(persona);
                HttpContext.Session.SetString("listapersona", JsonConvert.SerializeObject(per));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController/Edit/5
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

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController/Delete/5
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
