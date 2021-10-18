using Lib_Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel;

namespace Lib_clases
{
    public enum e_estado_usuario
    {
        activo,
        suspendido,
        baja
    }

    public enum e_tipo_usuario
    {
        administrador,
        cliente,
        trabajador
    }


    public class Usuario
    {
        #region Variables

        [DisplayName("Id")]
        public int Id_usuario { get; set; }
        [DisplayName("Usuario")]
        public string Nombre_usuario { get; set; }
        [DisplayName("Contraseña")]
        public string Clave { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Apellido")]
        public string Apellido { get; set; }
        [DisplayName("Edad")]
        public int Edad { get; set; }
        [DisplayName("Tipo_usuario de Usuario")]
        public string Tipo_usuario { get; set; }
        [DisplayName("Estado del Usuario")]
        public string Estado_usuario { get; set; }

        readonly chemistryEntities db = new chemistryEntities();

        #endregion

        /// <summary>
        /// Verifica si el nombre de usuario y clave coinciden en la base de datos
        /// </summary>
        public bool Autenticar()
        {
            return db.usuario.Where( u => u.nombre_usuario == this.Nombre_usuario && u.clave == this.Clave )
               .FirstOrDefault() != null;
        }

        #region CRUD

        /// <summary>
        /// Guarda un Elemento en la base datos a travez de sus datos.
        /// </summary>
        public bool Guardar()
        {
            try
            {
                var usuarioEnviar = new usuario()
                {
                    id_usuario = this.Id_usuario,
                    nombre_usuario = this.Nombre_usuario,
                    clave = this.Clave,
                    nombre = this.Nombre,
                    apellido = this.Apellido,
                    edad = this.Edad,
                    tipo_usuario = this.Tipo_usuario,
                    estado_usuario = this.Estado_usuario
                };
                db.usuario.Add(usuarioEnviar);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve todos los Elementos de la base de datos.
        /// </summary>
        public List<Usuario> LeerTodos()
        {
            return this.db.usuario.Select(p => new Usuario()
            {
                Id_usuario = p.id_usuario,
                Nombre_usuario = p.nombre_usuario,
                Clave = p.clave,
                Nombre = p.nombre,
                Apellido = p.apellido,
                Edad = p.edad,
                Tipo_usuario = p.tipo_usuario,
                Estado_usuario = p.estado_usuario

            }).ToList();
        }

        /// <summary>
        /// Permite buscar un Elemento a traves de un id.
        /// </summary>
        public Usuario Buscar(int id)
        {
            return this.db.usuario.Select(p => new Usuario()
            {
                Id_usuario = p.id_usuario,
                Nombre_usuario = p.nombre_usuario,
                Clave = p.clave,
                Nombre = p.nombre,
                Apellido = p.apellido,
                Edad = p.edad,
                Tipo_usuario = p.tipo_usuario,
                Estado_usuario = p.estado_usuario
            }).Where(p => p.Id_usuario == id).FirstOrDefault();
        }

        /// <summary>
        /// Actualiza la informacion del Elemento en la base de datos.
        /// </summary>
        public bool Actualizar()
        {
            try
            {
                var usuarioEnviar = db.usuario.Find(this.Id_usuario);
                usuarioEnviar.nombre_usuario = this.Nombre_usuario;
                usuarioEnviar.clave = this.Clave;
                usuarioEnviar.nombre = this.Nombre;
                usuarioEnviar.apellido = this.Apellido;
                usuarioEnviar.edad = this.Edad;
                usuarioEnviar.tipo_usuario = this.Tipo_usuario;
                usuarioEnviar.estado_usuario = this.Estado_usuario;
                db.Entry(usuarioEnviar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un elemento en la base de dato a travez de un id.
        /// </summary>
        public bool Borrar(int id)
        {
            try
            {
                var usuario = db.usuario.Find(id);
                db.usuario.Remove(usuario);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna el id mas alto de la base de dato.
        /// </summary>
        public int UltimoRegistro()
        {
            try
            {
                return db.usuario.Max(u => u.id_usuario);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Busca un usuario a travez de su nombre_usuario y devuelve todos sus datos
        /// </summary>
        /// <returns></returns>
        public Usuario Identificarse(string nombre_usuario)
        {
            Usuario user = this.db.usuario.Select(p => new Usuario()
            {
                Id_usuario = p.id_usuario,
                Nombre_usuario = p.nombre_usuario,
                Clave = p.clave,
                Nombre = p.nombre,
                Apellido = p.apellido,
                Edad = p.edad,
                Tipo_usuario = p.tipo_usuario,
                Estado_usuario = p.estado_usuario
            }).Where(p => p.Nombre_usuario == nombre_usuario ).FirstOrDefault();

            return user;
            //Session["tipoUsuario"] = user.Tipo_usuario;
        }


        #endregion


    }
}
