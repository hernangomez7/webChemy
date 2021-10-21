using Lib_Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_clases
{
    public class Articulo_pedido
    {
        #region Variable

        [DisplayName("Id")]
        public int Id_artped { get; set; }

        [Range(0, 999999999999, ErrorMessage = "* El rango minimo de 1, maximo 999.999.999.999 .")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        public int Id_pedido { get; set; }

        [Range(0, 999999999999, ErrorMessage = "* El rango minimo de 1, maximo 999.999.999.999 .")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        public int Id_articulo { get; set; }

        [Range(0, 999999999999, ErrorMessage = "* El rango minimo de 1, maximo 999.999.999.999 .")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        public int Cantidad_solicitada { get; set; }

        public Articulo Articulo { get; set; }
        public Pedido Pedido { get; set; }

        #endregion

    }
}
