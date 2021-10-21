using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_Conexion;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lib_clases
{
    public class Pedido
    {
        #region Variables

        [DisplayName("Id") ]
        public int Id_pedido { get; set; }

        [Range(0, 999999999999, ErrorMessage = "* El rango minimo de 1, maximo 999.999.999.999 .")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        [ DisplayName("Usuario") ]
        public int Id_usuario { get; set; }

        [MinLength(3, ErrorMessage = "* Se requiere al menos {1} caracteres."), MaxLength(30, ErrorMessage = "* No se permite mas de {1} caracteres.")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        [DisplayName("Estado de Pedido")]
        public string Estado_pedido { get; set; }

        [DisplayName("Fecha Solicitud")]
        public Nullable<System.DateTime> Fecha_solicitud { get; set; }

        [DisplayName("Fecha Entrega")]
        public Nullable<System.DateTime> Fecha_entrega { get; set; }

        public Usuario Usuario { get; set; }

        #endregion

        public enum e_estado_pedido { solicitado, rechazado, cancelado, completo }
    }
}
