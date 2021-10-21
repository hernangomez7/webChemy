using Lib_Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace pagina_chemistry.Filtro
{
    //este filtro se lo damos directamente al controlador en sus metodos.

    //heredemos de AuthorizeAttribute ( este tipo de filtro verifica directamente si tiene permiso o no, tienes sesion si )
    //esta notacion [] es para que podamos verificar la autorizacion de metodos no los controller
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = false )]
    public class AutorizacionUsuario : AuthorizeAttribute
    {
        private usuario oUsuario;
        private chemistryEntities db = new chemistryEntities();
        private string operacion;
        private string modulo;

        public AutorizacionUsuario(string modulo = "", string operacion = "")
        {
            this.modulo = modulo;
            this.operacion = operacion;
        }

        //Se llama cuando un proceso solicita autorización.
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool esAutorizado = false;

            try
            {
                oUsuario = (usuario)HttpContext.Current.Session["User"];

                switch (oUsuario.tipo_usuario)
                {
                    case "administrador":
                        esAutorizado = true;
                    break;

                    case "cliente":
                        if (modulo == "pedido")
                        {
                            if (operacion == "crear") esAutorizado = true;
                        }
                        break;

                    case "trabajador":
                        if (modulo == "pedido") esAutorizado = true;
                    break;
                }
                
                if (esAutorizado == false)
                {
                    filterContext.Result = new RedirectResult("~/Error/Index?operacion=" + operacion + "&modulo=" + modulo + "&msjeErrorExcepcion=");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/Index?operacion=" + operacion + "&modulo=" + modulo + "&msjeErrorExcepcion=" + ex.Message);
            }
        }




    }
}