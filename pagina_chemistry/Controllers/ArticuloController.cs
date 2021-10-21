using Lib_clases;
using Lib_negocio;
using pagina_chemistry.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pagina_chemistry.Controllers
{
    [Authorize]
    public class ArticuloController : Controller
    {
        [AutorizacionUsuario(modulo: "articulo", operacion: "inicio")]
        public ActionResult Index()
        {
            ViewBag.articulos = ArticuloN.LeerTodos();
            return View();
        }

        [AutorizacionUsuario(modulo: "articulo", operacion: "listar")]
        public ActionResult Details(int id)
        {
            return View();
        }

        [AutorizacionUsuario(modulo: "articulo", operacion: "crear")]
        public ActionResult Create()
        {
            return View();
        }

        [AutorizacionUsuario(modulo: "articulo", operacion: "crearPost")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id_articulo,Nnombre_articulo,Descripcion,Cantidad_disponible,Estado_articulo,Precio,Url_imagen")]  Articulo articulo)
        {

            try
            {
                if (!ModelState.IsValid) return View(articulo);
                if ( ArticuloN.Guardar( articulo ) ) TempData["mensaje"] = "Guardado Correctamente.";
                else TempData["mensaje"] = "No se pudo Guardar.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "";
                return View(articulo);
            }
        }

        [AutorizacionUsuario(modulo: "articulo", operacion: "modificar")]
        public ActionResult Edit(int id)
        {
            Articulo p = ArticuloN.Buscar(id);

            if (p == null)
            {
                TempData["mensaje"] = "Elemento inexistente.";
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [AutorizacionUsuario(modulo: "articulo", operacion: "modificarPost")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id_articulo,Nnombre_articulo,Descripcion,Cantidad_disponible,Estado_articulo,Precio,Url_imagen")] Articulo articulo)
        {
            try
            {
                ArticuloN.Actualizar(articulo);
                TempData["mensaje"] = "Modificado Correctamente.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(articulo);
            }
        }

        [AutorizacionUsuario(modulo: "articulo", operacion: "borrar")]
        public ActionResult Delete(int id)
        {

            if (ArticuloN.Buscar(id) == null)
            {
                TempData["mensaje"] = "No se ha encontrado el elemento.";
                return RedirectToAction("Index");
            }

            if (ArticuloN.Borrar(id))
            {
                TempData["mensaje"] = "Borrado Exitosamente.";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "No se a podido borrar!";
            return RedirectToAction("Index");
        }

        [AutorizacionUsuario(modulo: "articulo", operacion: "borrarPost")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    
    }
}
