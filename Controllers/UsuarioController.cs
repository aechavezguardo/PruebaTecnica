using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaTecnica.Context;
using PruebaTecnica.Models;
using PruebaTecnica.Secutiry;
using PruebaTecnica.Utils;

namespace PruebaTecnica.Controllers
{
    public class UsuarioController : Controller
    {
        private PruebaTecnicaContext db = new PruebaTecnicaContext();
        private readonly IPasswordEncripter _passwordEncripter = new PasswordEncripter();

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

            return View(db.Usuarios.ToList());
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hash = new List<byte[]>();
                    usuario.Pass = this._passwordEncripter.Encript(usuario.Pass, out hash);
                    usuario.HashKey = hash[0];
                    usuario.HashIV = hash[1];

                    db.Usuarios.Add(usuario);
                    db.SaveChanges();

                    return RedirectToAction("Index", new { message = "Usuario creado correctamente.", isError = false });
                }
                else
                {
                    return RedirectToAction("Create", "Usuarios");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { message = "Ocurrió un error registrando la información del usuario: \" + ex.ToString()", isError = true });
            }
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario usuario = db.Usuarios.Find(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
                if (!string.IsNullOrEmpty(usuario.NuevaContrasena))
                {
                    usuario.Pass = _passwordEncripter.Encript(usuario.NuevaContrasena, new List<byte[]>()
                  .AddHash(usuario.HashKey)
                  .AddHash(usuario.HashIV));
                }

                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { message = "Usuario actualizado correctamente.", isError = false });
            }
            catch
            {
                return RedirectToAction("Index", new { message = "Ocurrió un error actualizando la información del usuario: \" + ex.ToString()", isError = true });
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int identificador)
        {
            try
            {
                Usuario usuario = db.Usuarios.Find(identificador);
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
                return RedirectToAction("Index", new { message = "Usuario eliminado correctamente.", isError = true });
            }
            catch
            {
                return View();
            }
        }
    }
}
