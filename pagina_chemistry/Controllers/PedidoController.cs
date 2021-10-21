using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib_clases;
using Lib_negocio;
using pagina_chemistry.Filtro;

namespace pagina_chemistry.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        Usuario usuarioAct = new Usuario();

        public ActionResult Index()
        {
             ViewBag.pedidos = PedidoN.LeerTodos();
            return View();
        }
        
        public ActionResult Details(int id)
        {
            return View();
        }

        [AutorizacionUsuario(modulo: "pedido", operacion: "crear")]
        public ActionResult Create()
        {
            return View();
        }

        [AutorizacionUsuario(modulo: "pedido", operacion: "crearPost")]
        [HttpPost]
        public ActionResult Create( [Bind(Include = "Id_usuario,Estado_pedido,Fecha_solicitud,Fecha_entrega")]  Pedido pedido)
        {
            try
            {
                //verificamos si se infringe alguna validacion
                if( !ModelState.IsValid )
                {
                    return View( pedido );
                }

                if ( PedidoN.Guardar( pedido ) ) TempData["mensaje"] = "Guardado Correctamente.";
                else  TempData["mensaje"] = "No se pudo Guardar.";
                return RedirectToAction( "Index" );
            }
            catch
            {
                TempData["mensaje"] = "";
                return View( pedido );
            }
        }

        [AutorizacionUsuario(modulo: "pedido", operacion: "modificar")]
        public ActionResult Edit(int id)
        {
            Pedido p = PedidoN.Buscar( id );

            if( p == null )
            {
                TempData["mensaje"] = "Elemento inexistente.";
                return RedirectToAction("Index");
            }

            return View( p );
        }

        [AutorizacionUsuario(modulo: "pedido", operacion: "modificarPost")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id_pedido,Id_usuario,Estado_pedido,Fecha_solicitud,Fecha_entrega")] Pedido pedido  )
        {
            try
            {
                PedidoN.Actualizar( pedido );
                TempData["mensaje"] = "Modificado Correctamente.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View( pedido );
            }
        }

        [AutorizacionUsuario(modulo: "pedido", operacion: "borrar")]
        public ActionResult Delete(int id)
        {

            if(PedidoN.Buscar(id) == null )
            {
                TempData["mensaje"] = "No se ha encontrado el elemento.";
                return RedirectToAction("Index");
            }

            if( PedidoN.Borrar(id))
            {
                TempData["mensaje"] = "Borrado Exitosamente.";
                return RedirectToAction("Index");//volvemos al inicio de la lista
            }
            TempData["mensaje"] = "No se a podido borrar!";
            return RedirectToAction("Index");
        }

        [AutorizacionUsuario(modulo: "pedido", operacion: "borrarPost")]
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
