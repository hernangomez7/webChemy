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
    public class Articulo_pedidoPedidoController : Controller
    {
        [AutorizacionUsuario(modulo: "artped", operacion: "inicio")]
        public ActionResult Index()
        {
            ViewBag.articulo_pedidos = Articulo_pedidoN.LeerTodos();
            return View();
        }

        [AutorizacionUsuario(modulo: "artped", operacion: "listar")]
        public ActionResult Details(int id)
        {
            return View();
        }

        [AutorizacionUsuario(modulo: "artped", operacion: "crear")]
        public ActionResult Create()
        {
            return View();
        }

        [AutorizacionUsuario(modulo: "artped", operacion: "crearPost")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id_artped,Id_pedido,Id_articulo,Cantidad_solicitada")]  Articulo_pedido articulo_pedido)
        {
            try
            {
                if (!ModelState.IsValid) return View(articulo_pedido);
                if (Articulo_pedidoN.Guardar( articulo_pedido )) TempData["mensaje"] = "Guardado Correctamente.";
                else TempData["mensaje"] = "No se pudo Guardar.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "";
                return View(articulo_pedido);
            }
        }

        [AutorizacionUsuario(modulo: "artped", operacion: "modificar")]
        public ActionResult Edit(int id)
        {
            Articulo_pedido p = Articulo_pedidoN.Buscar(id);

            if (p == null)
            {
                TempData["mensaje"] = "Elemento inexistente.";
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [AutorizacionUsuario(modulo: "artped", operacion: "modificarPost")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id_artped,Id_pedido,Id_articulo,Cantidad_solicitada")] Articulo_pedido articulo_pedido)
        {
            try
            {
                Articulo_pedidoN.Actualizar( articulo_pedido );
                TempData["mensaje"] = "Modificado Correctamente.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(articulo_pedido);
            }
        }

        [AutorizacionUsuario(modulo: "artped", operacion: "borrar")]
        public ActionResult Delete(int id)
        {
            if (Articulo_pedidoN.Buscar(id) == null)
            {
                TempData["mensaje"] = "No se ha encontrado el elemento.";
                return RedirectToAction("Index");
            }

            if (Articulo_pedidoN.Borrar(id))
            {
                TempData["mensaje"] = "Borrado Exitosamente.";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "No se a podido borrar!";
            return RedirectToAction("Index");
        }

        [AutorizacionUsuario(modulo: "artped", operacion: "borrarPost")]
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
