using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace Lib_clases
{
    /// <summary>
    /// Clase de depuracion
    /// </summary>
    public static class JS
    {
        static string scriptTag = "<script type=\"\" language=\"\">{0}</script>";

        /// <summary>
        /// Imprime un mensaje en la consola del explorador
        /// </summary>
        public static void ConsoleLog(string message)
        {
            string function = "console.log('{0}');";
            string log = string.Format(GenerateCodeFromFunction(function), message);
            HttpContext.Current.Response.Write(log);
        }

        public static void Alert(string message)
        {
            string function = "alert('{0}');";
            string log = string.Format(GenerateCodeFromFunction(function), message);
            HttpContext.Current.Response.Write(log);
        }

        static string GenerateCodeFromFunction(string function)
        {
            return string.Format(scriptTag, function);
        }
        
    }
}
