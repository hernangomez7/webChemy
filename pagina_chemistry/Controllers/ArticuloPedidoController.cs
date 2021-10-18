using Lib_clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pagina_chemistry.Controllers
{
    public class Articulo_pedidoPedidoController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.articulo_pedidos = new Articulo_pedido().LeerTodos();
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
        public ActionResult Create([Bind(Include = "Id_artped,Id_pedido,Id_articulo,Cantidad_solicitada")]  Articulo_pedido articulo_pedido)
        {
            try
            {
                if (!ModelState.IsValid) return View(articulo_pedido);
                if (articulo_pedido.Guardar()) TempData["mensaje"] = "Guardado Correctamente.";
                else TempData["mensaje"] = "No se pudo Guardar.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "";
                return View(articulo_pedido);
            }
        }

        public ActionResult Edit(int id)
        {
            Articulo_pedido p = new Articulo_pedido().Buscar(id);

            if (p == null)
            {
                TempData["mensaje"] = "Elemento inexistente.";
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id_artped,Id_pedido,Id_articulo,Cantidad_solicitada")] Articulo_pedido articulo_pedido)
        {
            try
            {
                articulo_pedido.Actualizar();
                TempData["mensaje"] = "Modificado Correctamente.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(articulo_pedido);
            }
        }

        public ActionResult Delete(int id)
        {
            if (new Articulo_pedido().Buscar(id) == null)
            {
                TempData["mensaje"] = "No se ha encontrado el elemento.";
                return RedirectToAction("Index");
            }

            if (new Articulo_pedido().Borrar(id))
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
