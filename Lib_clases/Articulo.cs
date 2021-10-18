using Lib_Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_clases
{
    public enum e_estado_articulo
    {
        activo,
        inactivo
    }

    public class Articulo
    {
        #region Variables

        [DisplayName("Id")]
        public int Id_articulo { get; set; }
        [DisplayName("Nnombre de Articulo")]
        public string Nnombre_articulo { get; set; }
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }
        [DisplayName("Cantidad Disponible")]
        public int Cantidad_disponible { get; set; }
        [DisplayName("Estado de Articulo")]
        public string Estado_articulo { get; set; }
        [DisplayName("Precio")]
        public int Precio { get; set; }
        [DisplayName("Imagen")]
        public string Url_imagen { get; set; }

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
                var Articulo = new articulo()
                {
                    id_articulo = this.Id_articulo,
                    nombre_articulo = this.Nnombre_articulo,
                    descripcion = this.Descripcion,
                    cantidad_disponible = this.Cantidad_disponible,
                    estado_articulo = this.Estado_articulo,
                    precio = this.Precio,
                    url_imagen = this.Url_imagen
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

        /// <summary>
        /// Devuelve todos los Elementos de la base de datos.
        /// </summary>
        public List<Articulo> LeerTodos()
        {
            return this.db.articulo.Select(p => new Articulo()
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

        /// <summary>
        /// Permite buscar un Elemento a traves de un id.
        /// </summary>
        public Articulo Buscar(int id)
        {
            return this.db.articulo.Select(p => new Articulo()
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

        /// <summary>
        /// Actualiza la informacion en la base de datos.
        /// </summary>
        public bool Actualizar()
        {
            try
            {
                var articuloEnviar = db.articulo.Find(this.Id_articulo);
                articuloEnviar.nombre_articulo = this.Nnombre_articulo;
                articuloEnviar.descripcion = this.Descripcion;
                articuloEnviar.cantidad_disponible = this.Cantidad_disponible;
                articuloEnviar.estado_articulo = this.Estado_articulo;
                articuloEnviar.precio = this.Precio;
                articuloEnviar.url_imagen = this.Url_imagen;

                db.Entry(articuloEnviar).State = System.Data.Entity.EntityState.Modified;
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

        #endregion

    }
}
