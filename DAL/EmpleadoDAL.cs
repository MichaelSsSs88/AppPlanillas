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
        public List<EmpleadoENT> ObtenerEmpleados(string pFiltro, string pTexto)
        {
            List<EmpleadoENT> ListaEmpleados = new List<EmpleadoENT>();
            Console.WriteLine(pFiltro + " " +1);
            if (pFiltro == "Todos")
            {
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
            }

            else if(pFiltro== "Cédula")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from empleado where cast(id AS TEXT) like '" + pTexto + "%'");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        EmpleadoENT empleado = new EmpleadoENT(Int32.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["apellido_uno"].ToString(), fila["apellido_dos"].ToString(), DateTime.Parse(fila["fecha_nacimiento"].ToString()), Int32.Parse(fila["id_puesto"].ToString()), (Byte[])fila["imagen"], Double.Parse(fila["salario_hora"].ToString()), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaEmpleados.Add(empleado);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            else if (pFiltro == "Nombre Completo")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from empleado em where (select(nombre || ' ' || apellido_uno || ' ' || apellido_dos) from empleado emp where em.id=emp.id) like '" + pTexto + "%'");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        EmpleadoENT empleado = new EmpleadoENT(Int32.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["apellido_uno"].ToString(), fila["apellido_dos"].ToString(), DateTime.Parse(fila["fecha_nacimiento"].ToString()), Int32.Parse(fila["id_puesto"].ToString()), (Byte[])fila["imagen"], Double.Parse(fila["salario_hora"].ToString()), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaEmpleados.Add(empleado);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

            
            return ListaEmpleados;
        }

        public void AgregarEmpleado(EmpleadoENT pEmpleado)
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

        public void EditarEmpleado(EmpleadoENT pEmpleado)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "UPDATE empleado SET nombre =@nombre, apellido_uno = @apellido_uno, apellido_dos =@apellido_dos, fecha_nacimiento =@fecha_nacimiento, id_puesto =@id_puesto, salario_hora =@salario_hora, imagen =@imagen, fecha_modificacion =@fecha_modificacion, modificado_por =@modificado_por, activo =@activo where id= " + pEmpleado.Id;
                parametros.AgregarParametro("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, pEmpleado.Nombre);
                parametros.AgregarParametro("@apellido_uno", NpgsqlTypes.NpgsqlDbType.Varchar, pEmpleado.Apellido_Uno);
                parametros.AgregarParametro("@apellido_dos", NpgsqlTypes.NpgsqlDbType.Varchar, pEmpleado.Apellido_Dos);
                parametros.AgregarParametro("@fecha_nacimiento", NpgsqlTypes.NpgsqlDbType.Date, pEmpleado.fechaNacimiento);
                parametros.AgregarParametro("@id_puesto", NpgsqlTypes.NpgsqlDbType.Integer, pEmpleado.Id_Puesto);
                parametros.AgregarParametro("@salario_hora", NpgsqlTypes.NpgsqlDbType.Double, pEmpleado.Salario_Hora);
                parametros.AgregarParametro("@imagen", NpgsqlTypes.NpgsqlDbType.Bytea, pEmpleado.Imagen);
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

        public Double SalarioEmpleado(int pEmpleado)
        {
            double salarioHora = 0;
            Parametro parametros = new Parametro();
            AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
            parametros.AgregarParametro("@id", NpgsqlTypes.NpgsqlDbType.Integer, pEmpleado);
            string sentenciaSQL = "select salario_hora from empleado where id=@id";
            
            DataSet dsetClientes= conexion.EjecutarConsultaSQL(sentenciaSQL, parametros.ObtenerParametros());
            foreach (DataRow fila in dsetClientes.Tables[0].Rows)
            {
                salarioHora = Double.Parse(fila["salario_hora"].ToString());
            }
            return salarioHora;
        }

        public void EliminarEmpleado(/*UsuarioENT*/int pEmpleado)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "DELETE FROM empleado WHERE id = @id";
                parametros.AgregarParametro("@id", NpgsqlTypes.NpgsqlDbType.Integer, pEmpleado);


                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
