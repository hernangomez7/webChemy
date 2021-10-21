using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lib_clases;
using Lib_Conexion;

namespace Lib_negocio
{
    public class PedidoN
    {


        #region CRUD

        /// <summary>
        /// Guarda un Pedido en la base datos a travez de sus datos.
        /// </summary>
        public static bool Guardar( Pedido pedidoData )
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                try
                {
                    var Pedido = new pedido()
                    {
                        id_pedido = pedidoData.Id_pedido,
                        id_usuario = pedidoData.Id_usuario,
                        estado_pedido = pedidoData.Estado_pedido,
                        fecha_solicitud = pedidoData.Fecha_solicitud,
                        fecha_entrega = pedidoData.Fecha_entrega
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
        }

        /// <summary>
        /// Devuelve todos los Pedidos de la base de datos.
        /// </summary>
        public static List<Pedido> LeerTodos()
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                return db.pedido.Select(p => new Pedido()
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
                }).ToList();
            }
        }

        /// <summary>
        /// Permite buscar un pedido a traves de un id.
        /// </summary>
        public static Pedido Buscar(int id)
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                return db.pedido.Select(p => new Pedido()
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
                }).Where(p => p.Id_pedido == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Actualiza la informacion en la base de datos.
        /// </summary>
        public static bool Actualizar( Pedido pedidoData )
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                try
                {
                    var pedidoEnviar = db.pedido.Find(pedidoData.Id_pedido);
                    pedidoEnviar.id_usuario = pedidoData.Id_usuario;
                    pedidoEnviar.estado_pedido = pedidoData.Estado_pedido;
                    pedidoEnviar.fecha_solicitud = pedidoData.Fecha_solicitud;
                    pedidoEnviar.fecha_entrega = pedidoData.Fecha_entrega;

                    db.Entry(pedidoEnviar).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina un elemento en la base de dato a travez de un id.
        /// </summary>
        public static bool Borrar(int id)
        {
            using ( chemistryEntities db = new chemistryEntities() )
            {
                try
                {
                    var pedido = db.pedido.Find(id);
                    db.pedido.Remove(pedido);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        #endregion


    }
}
