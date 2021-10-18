using Lib_Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_clases
{
    public class Articulo_pedido
    {
        #region Variable

        public int Id_artped { get; set; }
        public int Id_pedido { get; set; }
        public int Id_articulo { get; set; }
        public int Cantidad_solicitada { get; set; }

        public Articulo Articulo { get; set; }
        public Pedido Pedido { get; set; }

        readonly chemistryEntities db = new chemistryEntities();

        #endregion

        #region CRUD

        /// <summary>
        /// Guarda un Elemento en la base datos a travez de sus datos.
        /// </summary>
        public bool Guardar()
        {
            try
            {
                var Articulo_pedido = new articulo_pedido()
                {
                    id_artped = this.Id_artped,
                    id_articulo = this.Id_articulo,
                    id_pedido = this.Id_pedido,
                    cantidad_solicitada = this.Cantidad_solicitada
                };
                db.articulo_pedido.Add(Articulo_pedido);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve todos los Elemento de la base de datos.
        /// </summary>
        public List<Articulo_pedido> LeerTodos()
        {
            return this.db.articulo_pedido.Select(p => new Articulo_pedido()
            {
                Id_artped = p.id_artped,
                Id_articulo = p.id_articulo,
                Id_pedido = p.id_pedido,
                Cantidad_solicitada = p.cantidad_solicitada,
                Articulo = new Articulo()
                {
                    Id_articulo = p.articulo.id_articulo,
                    Nnombre_articulo = p.articulo.nombre_articulo,
                    Descripcion = p.articulo.descripcion,
                    Cantidad_disponible = p.articulo.cantidad_disponible,
                    Estado_articulo = p.articulo.estado_articulo,
                    Precio = p.articulo.precio,
                    Url_imagen = p.articulo.url_imagen
                },
                Pedido = new Pedido()
                {
                    Id_pedido = p.id_pedido,
                    Id_usuario = p.pedido.id_usuario,
                    Estado_pedido = p.pedido.estado_pedido,
                    Fecha_solicitud = p.pedido.fecha_solicitud,
                    Fecha_entrega = p.pedido.fecha_entrega
                }

            }).ToList();
        }

        /// <summary>
        /// Permite buscar un Elemento a traves de un id.
        /// </summary>
        public Articulo_pedido Buscar(int id)
        {
            return this.db.articulo_pedido.Select(p => new Articulo_pedido()
            {
                Id_artped = p.id_artped,
                Id_articulo = p.id_articulo,
                Id_pedido = p.id_pedido,
                Cantidad_solicitada = p.cantidad_solicitada,
                Articulo = new Articulo()
                {
                    Id_articulo = p.articulo.id_articulo,
                    Nnombre_articulo = p.articulo.nombre_articulo,
                    Descripcion = p.articulo.descripcion,
                    Cantidad_disponible = p.articulo.cantidad_disponible,
                    Estado_articulo = p.articulo.estado_articulo,
                    Precio = p.articulo.precio,
                    Url_imagen = p.articulo.url_imagen
                },
                Pedido = new Pedido()
                {
                    Id_pedido = p.id_pedido,
                    Id_usuario = p.pedido.id_usuario,
                    Estado_pedido = p.pedido.estado_pedido,
                    Fecha_solicitud = p.pedido.fecha_solicitud,
                    Fecha_entrega = p.pedido.fecha_entrega
                }
            }).Where(p => p.Id_artped == id).FirstOrDefault();
        }

        /// <summary>
        /// Actualiza la informacion en la base de datos.
        /// </summary>
        public bool Actualizar()
        {
            try
            {
                var artpedEnviar = db.articulo_pedido.Find(this.Id_artped);
                artpedEnviar.id_artped = this.Id_artped;
                artpedEnviar.id_articulo = this.Id_articulo;
                artpedEnviar.id_pedido = this.Id_pedido;
                artpedEnviar.cantidad_solicitada = this.Cantidad_solicitada;

                db.Entry(artpedEnviar).State = System.Data.Entity.EntityState.Modified;
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
                var articulo_pedido = db.articulo_pedido.Find(id);
                db.articulo_pedido.Remove(articulo_pedido);
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
                return db.articulo_pedido.Max( u => u.id_artped );
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion


    }
}
