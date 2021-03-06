using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lib_clases;
using System.Web.Security;
using Lib_negocio;
using Lib_Conexion;

namespace pagina_chemistry.Controllers
{
    public class AuthController : Controller
    {
        /// <summary>
        /// Acceso a la vista de Login
        /// </summary>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Permite el acceder a la sesion del usuario.
        /// </summary>
        /// <param name="usuario">Usuario ingresante</param>
        /// <param name="returnUrl">Url a la que se quiere acceder, guardado para luego acceder despues de obtener un permiso</param>
        [HttpPost]
        public ActionResult Login( Usuario usuario, string returnUrl  )
        {
            if ( EsValido( usuario ) &&  !ModelState.IsValid)
            {
                //cookies
                FormsAuthentication.SetAuthCookie( usuario.Nombre_usuario, false );

                Session["User"] = UsuarioN.Identificarse( usuario.Nombre_usuario );

                if ( returnUrl != null)
                {
                    //este return va hacia donde el usuario queria ir
                    return Redirect( returnUrl );
                }
                return RedirectToAction("Index", "Home");
            }
           

            TempData["mensaje"] = "La contraseña o el usuario no es valido.";
            return View();

            // return RedirectToAction("Login", "Auth"); //View( usuario );
        }

        /// <summary>
        /// Verifica si el Usuario se encuentra en la base de datos
        /// </summary>
        public bool EsValido( Usuario usuario)
        {
            return UsuarioN.Autenticar( usuario );
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

    }
}