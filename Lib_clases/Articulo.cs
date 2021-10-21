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
    public class Articulo
    {
        #region Variables
        
        [DisplayName("Id")]
        public int Id_articulo { get; set; }

        [MinLength(3, ErrorMessage = "* Se requiere al menos {1} caracteres."), MaxLength(30, ErrorMessage = "* No se permite mas de {1} caracteres.")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        [DisplayName("Nnombre de Articulo")]
        public string Nnombre_articulo { get; set; }
        
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        [Range(0, 999999999999, ErrorMessage = "* El rango minimo de 1, maximo 999.999.999.999 .")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        [DisplayName("Cantidad Disponible")]
        public int Cantidad_disponible { get; set; }

        [MinLength(3, ErrorMessage = "* Se requiere al menos {1} caracteres."), MaxLength(30, ErrorMessage = "* No se permite mas de {1} caracteres.")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        [DisplayName("Estado de Articulo")]
        public string Estado_articulo { get; set; }

        [Range(0, 999999999999, ErrorMessage = "* El rango minimo de 1, maximo 999.999.999.999 .")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        [DisplayName("Precio")]
        public int Precio { get; set; }

        [DisplayName("Imagen")]
        public string Url_imagen { get; set; }

        #endregion

        public enum e_estado_articulo { activo, inactivo }
    }
}
