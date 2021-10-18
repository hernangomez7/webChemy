using Lib_clases;
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

        public ActionResult Index()
        {
            ViewBag.articulos = new Articulo().LeerTodos();
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
        public ActionResult Create([Bind(Include = "Id_articulo,Nnombre_articulo,Descripcion,Cantidad_disponible,Estado_articulo,Precio,Url_imagen")]  Articulo articulo)
        {

            try
            {
                if (!ModelState.IsValid) return View(articulo);
                if (articulo.Guardar()) TempData["mensaje"] = "Guardado Correctamente.";
                else TempData["mensaje"] = "No se pudo Guardar.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "";
                return View(articulo);
            }
        }
        
        public ActionResult Edit(int id)
        {
            Articulo p = new Articulo().Buscar(id);

            if (p == null)
            {
                TempData["mensaje"] = "Elemento inexistente.";
                return RedirectToAction("Index");
            }
            return View(p);
        }
        
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id_articulo,Nnombre_articulo,Descripcion,Cantidad_disponible,Estado_articulo,Precio,Url_imagen")] Articulo articulo)
        {
            try
            {
                articulo.Actualizar();
                TempData["mensaje"] = "Modificado Correctamente.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(articulo);
            }
        }
        
        public ActionResult Delete(int id)
        {

            if (new Articulo().Buscar(id) == null)
            {
                TempData["mensaje"] = "No se ha encontrado el elemento.";
                return RedirectToAction("Index");
            }

            if (new Articulo().Borrar(id))
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    
    }
}
