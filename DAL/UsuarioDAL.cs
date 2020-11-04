using DAL;
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
        public List<UsuarioENT> ObtenerUsuarios()
        {
            List<UsuarioENT> ListaUsuarios = new List<UsuarioENT>();
            try
            {
                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from usuario");
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    UsuarioENT usuario = new UsuarioENT(Int32.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["correo"].ToString(), fila["tipo"].ToString(), fila["contraseña"].ToString());
                    ListaUsuarios.Add(usuario);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ListaUsuarios;
        }
    }
}
