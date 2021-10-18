using Lib_clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pagina_chemistry.Controllers
{
    public class UsuarioController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            Usuario usuarioAct = new Usuario();

            Usuario usr = new Usuario();
            usuarioAct = usr.Identificarse(User.Identity.Name);

            if (usuarioAct.Tipo_usuario == "administrador") ViewBag.usuarios = new Usuario().LeerTodos();
            else
            {
                List<Usuario> a = new List<Usuario>();
                a.Add(usr.Buscar(usuarioAct.Id_usuario));
                ViewBag.usuarios = a;
            }

            return View();
        }
        
        public ActionResult Details(int id)
        {
            return View();
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id_usuario,Nombre_usuario,Clave,Nombre,Apellido,Edad,Tipo_usuario,Estado_usuario")]  Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid) return View(usuario);

                if (usuario.Guardar()) TempData["mensaje"] = "Guardado Correctamente.";
                else TempData["mensaje"] = "No se pudo Guardar.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "";
                return View(usuario);
            }
        }
        
        [Authorize]
        public ActionResult Edit(int id)
        {
            Usuario p = new Usuario().Buscar(id);

            if (p == null)
            {
                TempData["mensaje"] = "Elemento inexistente.";
                return RedirectToAction("Index");
            }

            return View(p);
        }
        
        [HttpPost, Authorize]
        public ActionResult Edit([Bind(Include = "Id_usuario,Nombre_usuario,Clave,Nombre,Apellido,Edad,Tipo_usuario,Estado_usuario")] Usuario usuario)
        {
            try
            {
                usuario.Actualizar();
                TempData["mensaje"] = "Modificado Correctamente.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            if (new Usuario().Buscar(id) == null)
            {
                TempData["mensaje"] = "No se ha encontrado el elemento.";
                return RedirectToAction("Index");
            }

            if (new Usuario().Borrar(id))
            {
                TempData["mensaje"] = "Borrado Exitosamente.";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "No se a podido borrar!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
