using Lib_Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lib_clases
{
    public class Usuario
    {
        #region Variables
        //esto se llama DataAnnotations y nos permiten describir las reglas que queremos aplicar a nuestras propiedades del modelo,
        [DisplayName("Id")]
        public int Id_usuario { get; set; }
        
        [ MinLength(3, ErrorMessage ="* Se requiere al menos {1} caracteres."), MaxLength(30, ErrorMessage = "* No se permite mas de {1} caracteres.")]
        [ Required(ErrorMessage = "* El campo {0} es requerido.") ]
        [ DisplayName("Usuario") ]
        public string Nombre_usuario { get; set; }

        [MinLength(3, ErrorMessage = "* Se requiere al menos {1} caracteres."), MaxLength(30, ErrorMessage = "* No se permite mas de {1} caracteres.")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        [DisplayName("Contraseña")]
        public string Clave { get; set; }

        [MinLength(3, ErrorMessage = "* Se requiere al menos {1} caracteres."), MaxLength(30, ErrorMessage = "* No se permite mas de {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$", ErrorMessage = "* Debe utilizar solo letras")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [MinLength(3, ErrorMessage = "* Se requiere al menos {1} caracteres."), MaxLength(30, ErrorMessage = "* No se permite mas de {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$", ErrorMessage = "* Debe utilizar solo letras")]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        [DisplayName("Apellido")]
        public string Apellido { get; set; }
        
        [ Range(18,99, ErrorMessage = "* El rango de edad es 18 a 99 años.") ]
        [Required(ErrorMessage = "* El campo {0} es requerido")]
        [DisplayName("Edad")]
        public int Edad { get; set; }

        [DisplayName("Tipo_usuario de Usuario")]
        public string Tipo_usuario { get; set; }

        [DisplayName("Estado del Usuario")]
        public string Estado_usuario { get; set; }

        #endregion

        public enum e_estado_usuario { activo, suspendido, baja }
        public enum e_tipo_usuario { administrador, cliente, trabajador }
    }
}
