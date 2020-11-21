using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReloj.DAL
{
    class MarcaDAL
    {
        public List<MarcaENT> ObtenerMarcas(string pFiltro, string pTexto)
        {
            List<MarcaENT> ListaMarcas = new List<MarcaENT>();
           // Console.WriteLine(pFiltro + " " + 1);
            if (pFiltro == "Todos")
            {
                try
                {

                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from marca");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        string str = fila["imagen"].ToString();
                        byte[] imagen = Encoding.ASCII.GetBytes(str);
                        MarcaENT marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["marca_inicio"].ToString()), DateTime.Parse(fila["marca_final"].ToString()), fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), (Byte[])fila["foto_inicio"], (Byte[])fila["foto_final"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString());
                        ListaMarcas.Add(marca);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            else if (pFiltro == "Id")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from marca where cast(id AS TEXT) like '" + pTexto + "%'");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        MarcaENT marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["marca_inicio"].ToString()), DateTime.Parse(fila["marca_final"].ToString()), fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), (Byte[])fila["foto_inicio"], (Byte[])fila["foto_final"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString());
                        ListaMarcas.Add(marca);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            /*else if (pFiltro == "Nombre Completo")
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
            */

            return ListaMarcas;
        }

        public int ObtenerMarcas(int pIdEmpleado)
        {
            List<MarcaENT> ListaMarcas = new List<MarcaENT>();
            try
            {
                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from marca where id_empleado=" + pIdEmpleado + " and marca_final is null");
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    //string str = fila["imagen"].ToString();
                   // byte[] imagen = Encoding.ASCII.GetBytes(str);
                    MarcaENT marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), (DateTime)(fila["marca_inicio"]), DateTime.Now, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), (Byte[])fila["foto_inicio"], null, (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString());
                    ListaMarcas.Add(marca);
                }
            }catch(Exception Ex)
            {
                throw Ex;
            }

            if (ListaMarcas.Count() > 0)
                return ListaMarcas[ListaMarcas.Count() - 1].idMarca;
            else
                return -1;
        }

        public void AgregarMarca(MarcaENT pMarca)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "INSERT INTO public.marca(marca_inicio, estado, id_empleado, foto_inicio, fecha_creacion, creado_por, fecha_modificacion, modificado_por)" +
                                      "VALUES(@marca_inicio, @estado, @id_empleado, @foto_inicio, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por)";
               
                parametros.AgregarParametro("@marca_inicio", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.marcar_inicio);
                
                parametros.AgregarParametro("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, pMarca.estado);
                parametros.AgregarParametro("@id_empleado", NpgsqlTypes.NpgsqlDbType.Integer, pMarca.IdEmpleado);
                parametros.AgregarParametro("@foto_inicio", NpgsqlTypes.NpgsqlDbType.Bytea, pMarca.foto_inicio);
               
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.fechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pMarca.creadoPor);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.fechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pMarca.modificadoPor);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void EditarMarca(MarcaENT pMarca)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "UPDATE marca SET marca_final=@marca_final, foto_final=@foto_final, fecha_modificacion=@fecha_modificacion, modificado_por=@modificado_por WHERE id= " + pMarca.idMarca;
                                      
                //parametros.AgregarParametro("@id", NpgsqlTypes.NpgsqlDbType.Integer, pMarca.idMarca);
                //parametros.AgregarParametro("@marca_inicio", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.marcar_inicio);
                parametros.AgregarParametro("@marca_final", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.marcar_final);
                //parametros.AgregarParametro("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, pMarca.estado);
                //parametros.AgregarParametro("@id_empleado", NpgsqlTypes.NpgsqlDbType.Integer, pMarca.IdEmpleado);
                //parametros.AgregarParametro("@foto_inicio", NpgsqlTypes.NpgsqlDbType.Bytea, pMarca.foto_inicio);
                parametros.AgregarParametro("@foto_final", NpgsqlTypes.NpgsqlDbType.Bytea, pMarca.foto_final);
                //parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.fechaCreacion);
                //parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pMarca.creadoPor);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.fechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pMarca.modificadoPor);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
