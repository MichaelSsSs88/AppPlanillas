using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPlanillas.ENT;
using DAL;

namespace AppPlanillas.DAL
{
    class DeduccionDAL
    {
        public DeduccionDAL () { }

        public void AgregarDeduccion (ENT.DeduccionENT pDeduccion)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "INSERT INTO deduccion (nombre, sistema, valor, id_empleado, fecha_creacion, creado_por, fecha_modificacion, modificado_por, activo)" +
                                                              "VALUES (@nombre, @sistema, @valor, @id_empleado, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por, @activo)";
                parametros.AgregarParametro("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.getDescripcion);
                parametros.AgregarParametro("@sistema", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.getSistema);
                parametros.AgregarParametro("@valor", NpgsqlTypes.NpgsqlDbType.Double, pDeduccion.getValor);
                if (pDeduccion.getIdEmpleado == 0) 
                {
                    parametros.AgregarParametro("@id_empleado", NpgsqlTypes.NpgsqlDbType.Integer, null);
                }
                else
                {
                    parametros.AgregarParametro("@id_empleado", NpgsqlTypes.NpgsqlDbType.Integer, pDeduccion.getIdEmpleado);
                }
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pDeduccion.getFechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.getCreador);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pDeduccion.getFechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.getModificador);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pDeduccion.getActivo);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ActualizarDeduccion(DeduccionENT pDeduccion)
        {
            int numero = 0;
            try
            {
                Parametro parametros;
                string sentenciaSQL = "";
                parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                sentenciaSQL = "UPDATE deduccion SET nombre = @nombre, sistema = @sistema, valor = @valor, id_empleado = @id_empleado, fecha_creacion = @fecha_creacion, creado_por = @creado_por, fecha_modificacion = @fecha_modificacion, modificado_por = @modificado_por, activo = @activo WHERE id = '" + pDeduccion.getId + "'";
                parametros.AgregarParametro("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.getDescripcion);
                parametros.AgregarParametro("@sistema", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.getSistema);
                parametros.AgregarParametro("@valor", NpgsqlTypes.NpgsqlDbType.Double, pDeduccion.getValor);
                if (pDeduccion.getIdEmpleado == 0)
                {
                    parametros.AgregarParametro("@id_empleado", NpgsqlTypes.NpgsqlDbType.Integer, null);
                }
                else
                {
                    parametros.AgregarParametro("@id_empleado", NpgsqlTypes.NpgsqlDbType.Integer, pDeduccion.getIdEmpleado);
                }
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pDeduccion.getFechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.getCreador);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pDeduccion.getFechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.getModificador);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pDeduccion.getActivo);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                numero = 1;
                throw e;
            }
            return numero;
        }

        public int EliminarDeduccion(int pId)
        {
            int numero = 0;
            try
            {
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "DELETE FROM deduccion WHERE id = '" + pId + "'";
                conexion.EjecutarSQL(sentenciaSQL);
            }
            catch
            {
                numero = 1;
            }
            return numero;
        }

        public List<DeduccionENT> ObtenerDeducciones (int id, String descripcion)
        {
            List<DeduccionENT> deducciones = new List<DeduccionENT>();
            if ((id == -1) && (descripcion == ""))
            {
                try
                {
                    DataSet dsetDeducciones = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("SELECT * FROM deduccion");
                    foreach (DataRow fila in dsetDeducciones.Tables[0].Rows)
                    {
                        if (fila["id_empleado"].ToString() == "")
                        {
                            DeduccionENT deduccion = new DeduccionENT((int)fila["id"], fila["nombre"].ToString(), fila["sistema"].ToString(), (double)fila["valor"], 0, (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                            deducciones.Add(deduccion);
                        }
                        else
                        {
                            DeduccionENT deduccion = new DeduccionENT((int)fila["id"], fila["nombre"].ToString(), fila["sistema"].ToString(), (double)fila["valor"], (int)fila["id_empleado"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                            deducciones.Add(deduccion);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (id > -1)
            {
                try
                {
                    DataSet dsetDeducciones = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("SELECT * FROM deduccion where id = " + id);
                    foreach (DataRow fila in dsetDeducciones.Tables[0].Rows)
                    {
                        if (fila["id_empleado"].ToString() == "")
                        {
                            DeduccionENT deduccion = new DeduccionENT((int)fila["id"], fila["nombre"].ToString(), fila["sistema"].ToString(), (double)fila["valor"], 0, (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                            deducciones.Add(deduccion);
                        }
                        else
                        {
                            DeduccionENT deduccion = new DeduccionENT((int)fila["id"], fila["nombre"].ToString(), fila["sistema"].ToString(), (double)fila["valor"], (int)fila["id_empleado"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                            deducciones.Add(deduccion);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            else
            {
                try
                {
                    DataSet dsetDeducciones = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("SELECT * FROM deduccion WHERE nombre = '"+ descripcion + "'");
                    foreach (DataRow fila in dsetDeducciones.Tables[0].Rows)
                    {
                        if (fila["id_empleado"].ToString() == "")
                        {
                            DeduccionENT deduccion = new DeduccionENT((int)fila["id"], fila["nombre"].ToString(), fila["sistema"].ToString(), (double)fila["valor"], 0, (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                            deducciones.Add(deduccion);
                        }
                        else
                        {
                            DeduccionENT deduccion = new DeduccionENT((int)fila["id"], fila["nombre"].ToString(), fila["sistema"].ToString(), (double)fila["valor"], (int)fila["id_empleado"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                            deducciones.Add(deduccion);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            return deducciones;
        }

    }
}
