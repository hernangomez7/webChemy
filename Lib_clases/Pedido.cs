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
        [ DisplayName("Usuario"), Required ]
        public int Id_usuario { get; set; }
        [DisplayName("Estado de Pedido"), Required]
        public string Estado_pedido { get; set; }
        [DisplayName("Fecha Solicitud")]
        public Nullable<System.DateTime> Fecha_solicitud { get; set; }
        [DisplayName("Fecha Entrega")]
        public Nullable<System.DateTime> Fecha_entrega { get; set; }

        public Usuario Usuario { get; set; }

        readonly chemistryEntities db = new chemistryEntities();

        #endregion

        #region CRUD

        /// <summary>
        /// Guarda un Pedido en la base datos a travez de sus datos.
        /// </summary>
        public bool Guardar()
        {
            try
            {
                var Pedido = new pedido()
                {
                    id_pedido = this.Id_pedido,
                    id_usuario = this.Id_usuario,
                    estado_pedido = this.Estado_pedido,
                    fecha_solicitud = this.Fecha_solicitud,
                    fecha_entrega = this.Fecha_entrega
                };
                db.pedido.Add(Pedido);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve todos los Pedidos de la base de datos.
        /// </summary>
        public List<Pedido> LeerTodos()
        {
            return this.db.pedido.Select(p => new Pedido() {
                Id_pedido = p.id_pedido,
                Id_usuario = p.id_usuario,
                Estado_pedido = p.estado_pedido,
                Fecha_solicitud = p.fecha_solicitud,
                Fecha_entrega = p.fecha_entrega,
                Usuario = new Usuario()
                {
                    Id_usuario = p.id_usuario,
                    Nombre_usuario = p.usuario.nombre_usuario,
                    Clave = p.usuario.clave,
                    Nombre = p.usuario.nombre,
                    Apellido = p.usuario.apellido,
                    Edad = p.usuario.edad,
                    Tipo_usuario = p.usuario.tipo_usuario,
                    Estado_usuario = p.usuario.estado_usuario
                }
            }).ToList();
        }

        /// <summary>
        /// Permite buscar un pedido a traves de un id.
        /// </summary>
        public Pedido Buscar( int id )
        {
            return this.db.pedido.Select(p => new Pedido()
            {
                Id_pedido = p.id_pedido,
                Id_usuario = p.id_usuario,
                Estado_pedido = p.estado_pedido,
                Fecha_solicitud = p.fecha_solicitud,
                Fecha_entrega = p.fecha_entrega,
                Usuario = new Usuario()
                {
                    Id_usuario = p.id_usuario,
                    Nombre_usuario = p.usuario.nombre_usuario,
                    Clave = p.usuario.clave,
                    Nombre = p.usuario.nombre,
                    Apellido = p.usuario.apellido,
                    Edad = p.usuario.edad,
                    Tipo_usuario = p.usuario.tipo_usuario,
                    Estado_usuario = p.usuario.estado_usuario
                }
            }).Where( p => p.Id_pedido == id ).FirstOrDefault();
        }

        /// <summary>
        /// Actualiza la informacion en la base de datos.
        /// </summary>
        public bool Actualizar( )
        {
            try
            {
                var pedidoEnviar = db.pedido.Find(this.Id_pedido);
                pedidoEnviar.id_usuario = this.Id_usuario;
                pedidoEnviar.estado_pedido = this.Estado_pedido;
                pedidoEnviar.fecha_solicitud = this.Fecha_solicitud;
                pedidoEnviar.fecha_entrega = this.Fecha_entrega;

                db.Entry(pedidoEnviar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un elemento en la base de dato a travez de un id.
        /// </summary>
        public bool Borrar( int id )
        {
            try
            {
                var pedido = db.pedido.Find( id );
                db.pedido.Remove(pedido);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

    }
}
