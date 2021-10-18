using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib_clases;

namespace pagina_chemistry.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        Usuario usuarioAct = new Usuario();

        public ActionResult Index()
        {
            
             ViewBag.pedidos = new Pedido().LeerTodos();
            
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
        public ActionResult Create( [Bind(Include = "Id_usuario,Estado_pedido,Fecha_solicitud,Fecha_entrega")]  Pedido pedido)
        {
            try
            {
                //verificamos si se infringe alguna validacion
                if( !ModelState.IsValid )
                {
                    return View( pedido );
                }

                if ( pedido.Guardar() ) TempData["mensaje"] = "Guardado Correctamente.";
                else  TempData["mensaje"] = "No se pudo Guardar.";
                return RedirectToAction( "Index" );
            }
            catch
            {
                TempData["mensaje"] = "";
                return View( pedido );
            }
        }
        
        public ActionResult Edit(int id)
        {
            Pedido p = new Pedido().Buscar( id );

            if( p == null )
            {
                TempData["mensaje"] = "Elemento inexistente.";
                return RedirectToAction("Index");
            }

            return View( p );
        }
        
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id_pedido,Id_usuario,Estado_pedido,Fecha_solicitud,Fecha_entrega")] Pedido pedido  )
        {
            try
            {
                pedido.Actualizar();
                TempData["mensaje"] = "Modificado Correctamente.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View( pedido );
            }
        }
        
        public ActionResult Delete(int id)
        {

            if(new Pedido().Buscar(id) == null )
            {
                TempData["mensaje"] = "No se ha encontrado el elemento.";
                return RedirectToAction("Index");
            }

            if(new Pedido().Borrar(id))
            {
                TempData["mensaje"] = "Borrado Exitosamente.";
                return RedirectToAction("Index");//volvemos al inicio de la lista
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
