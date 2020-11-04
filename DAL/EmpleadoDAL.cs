using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIIIC
{
    class EmpleadoDAL
    {
        public List<EmpleadoENT> ObtenerEmpleados()
        {
            List<EmpleadoENT> ListaEmpleados = new List<EmpleadoENT>();
            try
            {
                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from empleado");
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    string str = fila["imagen"].ToString();
                    byte[] imagen = Encoding.ASCII.GetBytes(str);
                    EmpleadoENT empleado = new EmpleadoENT(Int32.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["apellido_uno"].ToString(), fila["apellido_dos"].ToString(), Int32.Parse(fila["edad"].ToString()), Int32.Parse(fila["id_departamento"].ToString()), imagen);
                    ListaEmpleados.Add(empleado);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ListaEmpleados;
        }
    }
}
