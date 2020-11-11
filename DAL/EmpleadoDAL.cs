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
                    EmpleadoENT empleado = new EmpleadoENT(Int32.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["apellido_uno"].ToString(), fila["apellido_dos"].ToString(), DateTime.Parse(fila["fecha_nacimiento"].ToString()), Int32.Parse(fila["id_puesto"].ToString()), (Byte[])fila["imagen"], Double.Parse(fila["salario_hora"].ToString()), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                    ListaEmpleados.Add(empleado);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ListaEmpleados;
        }

        public void AgregarDepartamento(EmpleadoENT pEmpleado)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "INSERT INTO empleado (id, nombre, apellido_uno, apellido_dos, fecha_nacimiento, id_puesto, salario_hora, imagen, fecha_creacion, creado_por, fecha_modificacion, modificado_por, activo)" +
                                                              "VALUES (@id, @nombre, @apellido_uno, @apellido_dos, @fecha_nacimiento, @id_puesto, @salario_hora, @imagen, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por, @activo)";
                parametros.AgregarParametro("@id", NpgsqlTypes.NpgsqlDbType.Integer, pEmpleado.Id);
                parametros.AgregarParametro("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, pEmpleado.Nombre);
                parametros.AgregarParametro("@apellido_uno", NpgsqlTypes.NpgsqlDbType.Varchar, pEmpleado.Apellido_Uno);
                parametros.AgregarParametro("@apellido_dos", NpgsqlTypes.NpgsqlDbType.Varchar, pEmpleado.Apellido_Dos);
                parametros.AgregarParametro("@fecha_nacimiento", NpgsqlTypes.NpgsqlDbType.Date, pEmpleado.fechaNacimiento);
                parametros.AgregarParametro("@id_puesto", NpgsqlTypes.NpgsqlDbType.Integer, pEmpleado.Id_Puesto);
                parametros.AgregarParametro("@salario_hora", NpgsqlTypes.NpgsqlDbType.Double, pEmpleado.Salario_Hora);
                parametros.AgregarParametro("@imagen", NpgsqlTypes.NpgsqlDbType.Bytea, pEmpleado.Imagen);
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pEmpleado.getFechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pEmpleado.getCreador);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pEmpleado.getFechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pEmpleado.getModificador);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pEmpleado.getActivo);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
