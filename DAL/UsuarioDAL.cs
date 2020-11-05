using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIIIC
{
    class UsuarioDAL
    {
        public List<UsuarioENT> ObtenerUsuarios(string pFiltro, string pTexto)
        {
            List<UsuarioENT> ListaUsuarios = new List<UsuarioENT>();
            if (pFiltro == "Todos")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from usuario");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        UsuarioENT usuario = new UsuarioENT(Int32.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["correo"].ToString(), fila["tipo"].ToString(), fila["contraseña"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaUsuarios.Add(usuario);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Nombre")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from usuario where nombre = " + pTexto);
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        UsuarioENT usuario = new UsuarioENT(Int32.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["correo"].ToString(), fila["tipo"].ToString(), fila["contraseña"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaUsuarios.Add(usuario);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Correo")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from usuario where correo = " + pTexto);
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        UsuarioENT usuario = new UsuarioENT(Int32.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["correo"].ToString(), fila["tipo"].ToString(), fila["contraseña"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaUsuarios.Add(usuario);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Tipo")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from usuario where tipo = " + pTexto);
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        UsuarioENT usuario = new UsuarioENT(Int32.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["correo"].ToString(), fila["tipo"].ToString(), fila["contraseña"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaUsuarios.Add(usuario);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return ListaUsuarios;
        }

        public void AgregarUsuario(UsuarioENT pUsuario)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "INSERT INTO deduccion (nombre, correo, tipo, contraseña, fecha_creacion, creado_por, fecha_modificacion, modificado_por, activo)" +
                                      "VALUES (@nombre, @correo, @tipo, MD5( @contraseña ), @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por, @activo)";
                parametros.agregarParametro("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Nombre);
                parametros.agregarParametro("@correo", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Correo);
                parametros.agregarParametro("@tipo", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Tipo);
                parametros.agregarParametro("@contraseña", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Contrasena);
                parametros.agregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pUsuario.getFechaCreacion);
                parametros.agregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.getCreador);
                parametros.agregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pUsuario.getFechaModificacion);
                parametros.agregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.getModificador);
                parametros.agregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pUsuario.getActivo);

                conexion.EjecutarSQL(sentenciaSQL, parametros.obtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public void ActualizarUsuario(UsuarioENT pUsuario)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "UPDATE usuario SET nombre =@nombre, correo =@correo, tipo =@tipo, contraseña =MD5(@contraseña) WHERE id " + pUsuario.Id;
                parametros.agregarParametro("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Nombre);
                parametros.agregarParametro("@correo", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Correo);
                parametros.agregarParametro("@tipo", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Tipo);
                parametros.agregarParametro("@contraseña", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Contrasena);

                conexion.EjecutarSQL(sentenciaSQL, parametros.obtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void EliminarUsuario(UsuarioENT pUsuario)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "DELETE FROM usuario WHERE id = @id";
                parametros.agregarParametro("@id", NpgsqlTypes.NpgsqlDbType.Integer, pUsuario.Id);


                conexion.EjecutarSQL(sentenciaSQL, parametros.obtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean IniciarSesion(string pCorreo, string pContrasena)
        {
            
            int cantidad = 0;
            try
            {
                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select count(*) as cantidad from usuario where correo = " + pCorreo + "and contraseña = " + "MD5(" + pContrasena + ")");
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    
                    cantidad = int.Parse(fila["cantidad"].ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            if (cantidad <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
