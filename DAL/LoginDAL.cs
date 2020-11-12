using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPlanillas.DAL
{
    class LoginDAL
    {
        public UsuarioENT IniciarSesion(string pCorreo, string pContrasena)
        {
            UsuarioENT usuario = new UsuarioENT(0, "", "", "", "", DateTime.Now, "", DateTime.Now, "", false);
            int cantidad = 0;
           
            try
            {
                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select count(*) from usuario where correo = '" + pCorreo + "'" + "and contraseña = MD5('" + pContrasena + "')");
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    
                    cantidad = int.Parse(fila["count"].ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            if (cantidad <= 0)
            {
                return usuario;
            }
            else
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from usuario where correo = '" + pCorreo + "' and contraseña = " + "MD5('" + pContrasena + "')");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        
                        int id = int.Parse(fila["id"].ToString());
                        string nombre = fila["nombre"].ToString();
                        string correo = fila["correo"].ToString();
                        string tipo = fila["tipo"].ToString();
                        string contrasena = fila["contraseña"].ToString();
                        DateTime fecha_creacion = DateTime.Parse(fila["fecha_creacion"].ToString());
                        string creado_por = fila["creado_por"].ToString();
                        DateTime fecha_modificacion = DateTime.Parse(fila["fecha_modificacion"].ToString());
                        string modificado_por = fila["modificado_por"].ToString();
                        Boolean activo = Boolean.Parse(fila["activo"].ToString());
                        
                        usuario = new UsuarioENT(id,nombre,correo,tipo,contrasena,fecha_creacion,creado_por,fecha_modificacion,modificado_por,activo);
                        
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                
            }
            return usuario;
        }
    }
}
