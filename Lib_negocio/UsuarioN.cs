using Lib_clases;
using Lib_Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lib_negocio
{
    public class UsuarioN
    {
        #region CRUD

        /// <summary>
        /// Guarda un Elemento en la base datos a travez de sus datos.
        /// </summary>
        public static bool Guardar( Usuario usuarioData )
        {
            if ( !EsExistente(usuarioData.Nombre_usuario) )
            {
                using (chemistryEntities db = new chemistryEntities())
                {
                    try
                    {
                        var usuarioEnviar = new usuario()
                        {
                            id_usuario = usuarioData.Id_usuario,
                            nombre_usuario = usuarioData.Nombre_usuario,
                            clave = usuarioData.Clave,
                            nombre = usuarioData.Nombre,
                            apellido = usuarioData.Apellido,
                            edad = usuarioData.Edad,
                            tipo_usuario = usuarioData.Tipo_usuario,
                            estado_usuario = usuarioData.Estado_usuario
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
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve todos los Elementos de la base de datos.
        /// </summary>
        public static List<Usuario> LeerTodos( )
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                return db.usuario.Select(p => new Usuario()
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
        }

        /// <summary>
        /// Permite buscar un Elemento a traves de un id.
        /// </summary>
        public static Usuario Buscar(int id)
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                return db.usuario.Select(p => new Usuario()
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
        }

        /// <summary>
        /// Actualiza la informacion del Elemento en la base de datos.
        /// </summary>
        public static bool Actualizar( Usuario usuarioData )
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                try
                {
                    var usuarioEnviar = db.usuario.Find(usuarioData.Id_usuario);
                    usuarioEnviar.nombre_usuario = usuarioData.Nombre_usuario;
                    usuarioEnviar.clave = usuarioData.Clave;
                    usuarioEnviar.nombre = usuarioData.Nombre;
                    usuarioEnviar.apellido = usuarioData.Apellido;
                    usuarioEnviar.edad = usuarioData.Edad;
                    usuarioEnviar.tipo_usuario = usuarioData.Tipo_usuario;
                    usuarioEnviar.estado_usuario = usuarioData.Estado_usuario;
                    db.Entry(usuarioEnviar).State = System.Data.Entity.EntityState.Modified;
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
        }

        #endregion

        /// <summary>
        /// Verifica si el nombre de usuario y clave coinciden en la base de datos
        /// </summary>
        public static bool Autenticar(Usuario usuarioData)
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                return db.usuario.Where(u => u.nombre_usuario == usuarioData.Nombre_usuario && u.clave == usuarioData.Clave)
               .FirstOrDefault() != null;
            }
        }
        
        /// <summary>
        /// Retorna el id mas alto de la base de dato.
        /// </summary>
        public static int UltimoRegistro()
        {
            using (chemistryEntities db = new chemistryEntities())
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
        }

        /// <summary>
        /// Busca un usuario a travez de su nombre_usuario y devuelve todos sus datos
        /// </summary>
        /// <returns></returns>
        public static usuario Identificarse(string nombre_usuario)
        {
            /*using (chemistryEntities db = new chemistryEntities())
            {
                return db.usuario.Select(p => new Usuario()
                {
                    Id_usuario = p.id_usuario,
                    Nombre_usuario = p.nombre_usuario,
                    Clave = p.clave,
                    Nombre = p.nombre,
                    Apellido = p.apellido,
                    Edad = p.edad,
                    Tipo_usuario = p.tipo_usuario,
                    Estado_usuario = p.estado_usuario
                }).Where(p => p.Nombre_usuario == nombre_usuario).FirstOrDefault();
            }*/

            using (chemistryEntities db = new chemistryEntities())
            {
                return (from user in db.usuario
                                where user.nombre_usuario == nombre_usuario
                                select user
                        ).FirstOrDefault();
            }
        }

        public static bool EsExistente(string nombre_usuario)
        {
            using (chemistryEntities db = new chemistryEntities())
            {
                int encontrados = (from u in db.usuario where u.nombre_usuario == nombre_usuario select u).Count();
                if (encontrados == 0) return false;
                else return true;
            }
        }

    }
}
