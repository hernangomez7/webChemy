using Lib_clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib_negocio;
using pagina_chemistry.Filtro;

namespace pagina_chemistry.Controllers
{
    public class UsuarioController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.usuarios = UsuarioN.LeerTodos();
            
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

                if (UsuarioN.Guardar( usuario ) ) TempData["mensaje"] = "Guardado Correctamente.";
                else TempData["mensaje"] = "No se pudo Guardar.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "";
                return View(usuario);
            }
        }

        [AutorizacionUsuario(modulo: "usuario", operacion: "modificarPost")]
        [Authorize]
        public ActionResult Edit(int id)
        {
            Usuario p = UsuarioN.Buscar(id);

            if (p == null)
            {
                TempData["mensaje"] = "Elemento inexistente.";
                return RedirectToAction("Index");
            }

            return View(p);
        }

        [AutorizacionUsuario(modulo: "usuario", operacion: "modificar")]
        [HttpPost, Authorize]
        public ActionResult Edit([Bind(Include = "Id_usuario,Nombre_usuario,Clave,Nombre,Apellido,Edad,Tipo_usuario,Estado_usuario")] Usuario usuario)
        {
            if (!ModelState.IsValid) return View(usuario);
            try
            {
                if (UsuarioN.Actualizar(usuario))
                {
                    TempData["mensaje"] = "Modificado Correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["mensaje"] = "Error al modificar.";
                    return View(usuario);
                }
            }
            catch
            {
                return View(usuario);
            }
        }

        [AutorizacionUsuario(modulo: "usuario", operacion: "borrar")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            if ( UsuarioN.Buscar(id) == null )
            {
                TempData["mensaje"] = "No se ha encontrado el elemento.";
                return RedirectToAction("Index");
            }

            if ( UsuarioN.Borrar(id) )
            {
                TempData["mensaje"] = "Borrado Exitosamente.";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "No se a podido borrar!";
            return RedirectToAction("Index");
        }

        [AutorizacionUsuario(modulo: "usuario", operacion: "borrar")]
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
