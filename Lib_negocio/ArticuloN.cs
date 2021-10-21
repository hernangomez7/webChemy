using Lib_clases;
using Lib_Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_negocio
{
    public class ArticuloN
    {

        #region CRUD

        /// <summary>
        /// Guarda un Elemento en la base datos a travez de sus datos.
        /// </summary>
        public static bool Guardar( Articulo articuloData )
        {
            using (chemistryEntities db = new chemistryEntities() )
            {
                try
                {
                    var Articulo = new articulo()
                    {
                        id_articulo = articuloData.Id_articulo,
                        nombre_articulo = articuloData.Nnombre_articulo,
                        descripcion = articuloData.Descripcion,
                        cantidad_disponible = articuloData.Cantidad_disponible,
                        estado_articulo = articuloData.Estado_articulo,
                        precio = articuloData.Precio,
                        url_imagen = articuloData.Url_imagen
                    };
                    db.articulo.Add(Articulo);
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
        /// Devuelve todos los Elementos de la base de datos.
        /// </summary>
        public static List<Articulo> LeerTodos()
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                return db.articulo.Select(p => new Articulo()
                {
                    Id_articulo = p.id_articulo,
                    Nnombre_articulo = p.nombre_articulo,
                    Descripcion = p.descripcion,
                    Cantidad_disponible = p.cantidad_disponible,
                    Estado_articulo = p.estado_articulo,
                    Precio = p.precio,
                    Url_imagen = p.url_imagen
                }).ToList();
            }
        }

        /// <summary>
        /// Permite buscar un Elemento a traves de un id.
        /// </summary>
        public static Articulo Buscar(int id)
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                return db.articulo.Select(p => new Articulo()
                {
                    Id_articulo = p.id_articulo,
                    Nnombre_articulo = p.nombre_articulo,
                    Descripcion = p.descripcion,
                    Cantidad_disponible = p.cantidad_disponible,
                    Estado_articulo = p.estado_articulo,
                    Precio = p.precio,
                    Url_imagen = p.url_imagen
                }).Where(p => p.Id_articulo == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Actualiza la informacion en la base de datos.
        /// </summary>
        public static bool Actualizar( Articulo articuloData )
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                try
                {
                    var articuloEnviar = db.articulo.Find(articuloData.Id_articulo);
                    articuloEnviar.nombre_articulo = articuloData.Nnombre_articulo;
                    articuloEnviar.descripcion = articuloData.Descripcion;
                    articuloEnviar.cantidad_disponible = articuloData.Cantidad_disponible;
                    articuloEnviar.estado_articulo = articuloData.Estado_articulo;
                    articuloEnviar.precio = articuloData.Precio;
                    articuloEnviar.url_imagen = articuloData.Url_imagen;

                    db.Entry(articuloEnviar).State = System.Data.Entity.EntityState.Modified;
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
            using (chemistryEntities db = new chemistryEntities())
            {
                try
                {
                    var articulo = db.articulo.Find(id);
                    db.articulo.Remove(articulo);
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
