using PruebaTecnica.Context;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class PersonaController : Controller
    {
        private PruebaTecnicaContext db = new PruebaTecnicaContext();

        [Authorize]
        public ActionResult Index(string message, bool isError = false)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (isError)
                {
                    ViewBag.ErrorMessage = message;
                }
                else
                {
                    ViewBag.SuccessMessage = message;
                }
            }

            return View(db.Personas.ToList());
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            var tipoIdDictionary = new Dictionary<string, string>
            {
                { "", "-- Seleccione Tipo de Id --" },
                { "CC", "Cédula de Ciudadanía" },
                { "TI", "Tarjeta de Identidad" },
                { "PSP", "Pasaporte" }
            };

            ViewBag.TipoId = new SelectList(tipoIdDictionary, "Key", "Value");
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Persona model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Personas.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { message = "Persona creada correctamente.", isError = false });
                }
                else
                {
                    return RedirectToAction("Create", "Usuarios");
                }
            }
            catch
            {
                return RedirectToAction("Index", new { message = "Ocurrió un error registrando la información de la persona: \" + ex.ToString()", isError = true });
            }
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var tipoIdDictionary = new Dictionary<string, string>
            {
                { "", "-- Seleccione Tipo de Id --" },
                { "CC", "Cédula de Ciudadanía" },
                { "TI", "Tarjeta de Identidad" },
                { "PSP", "Pasaporte" }
            };

            Persona persona = db.Personas.Find(id);

            if (persona == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipoId = new SelectList(tipoIdDictionary, "Key", "Value", persona.TipoIdentificacion);

            return View(persona);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, Persona persona)
        {
            try
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { message = "Persona actualizada correctamente.", isError = false });
            }
            catch
            {
                return RedirectToAction("Index", new { message = "Ocurrió un error actualizando la información de la persona: \" + ex.ToString()", isError = true });
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteConfirmed(int identificador)
        {
            try
            {
                Persona person = db.Personas.Find(identificador);
                db.Personas.Remove(person);
                db.SaveChanges();
                return RedirectToAction("Index", new { message = "Persona eliminada correctamente.", isError = true });
            }
            catch
            {
                return View();
            }
        }
    }
}
