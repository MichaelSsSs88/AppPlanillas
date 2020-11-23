using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AppPlanillas.ENT;
using DAL;

namespace AppPlanillas.DAL
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
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from usuario where nombre like '" + pTexto +"%'");
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
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from usuario where correo like '" + pTexto + "%'");
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
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from usuario where tipo like'" + pTexto+"%'");
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
               // MD5.Create("asdasdas");
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "INSERT INTO usuario (nombre, correo, tipo, contraseña, fecha_creacion, creado_por, fecha_modificacion, modificado_por, activo)" +
                                      "VALUES (@nombre, @correo, @tipo, MD5('"+pUsuario.Contrasena+"'), @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por, @activo)";
                parametros.AgregarParametro("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Nombre);
                parametros.AgregarParametro("@correo", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Correo);
                parametros.AgregarParametro("@tipo", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Tipo);
                //parametros.AgregarParametro("@contraseña", NpgsqlTypes.NpgsqlDbType.Varchar, MD5.Create(pUsuario.Contrasena));
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pUsuario.getFechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.getCreador);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pUsuario.getFechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.getModificador);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pUsuario.getActivo);

                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
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
                string sentenciaSQL = "";
                if (pUsuario.Contrasena=="")
                    sentenciaSQL = "UPDATE usuario SET nombre =@nombre, correo =@correo, tipo =@tipo, fecha_modificacion =@fecha_modificacion, modificado_por =@modificado_por, activo=@activo  WHERE id= " + pUsuario.Id;
                else
                    sentenciaSQL = "UPDATE usuario SET nombre =@nombre, correo =@correo, tipo =@tipo, contraseña =  MD5('" + pUsuario.Contrasena + "'), fecha_modificacion =@fecha_modificacion, modificado_por =@modificado_por, activo=@activo  WHERE id= " + pUsuario.Id;

                parametros.AgregarParametro("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Nombre);
                parametros.AgregarParametro("@correo", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Correo);
                parametros.AgregarParametro("@tipo", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Tipo);
                //parametros.AgregarParametro("@contraseña", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.Contrasena);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pUsuario.getFechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pUsuario.getModificador);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pUsuario.getActivo);

                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        int z;
        public void EliminarUsuario(/*UsuarioENT*/int pUsuario)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "DELETE FROM usuario WHERE id = @id";
                parametros.AgregarParametro("@id", NpgsqlTypes.NpgsqlDbType.Integer, pUsuario);


                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
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
