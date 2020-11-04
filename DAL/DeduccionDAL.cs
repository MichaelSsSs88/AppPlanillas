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
                string sentenciaSQL = "INSERT INTO deduccion (nombre, porcentaje, sistema, fecha_creacion, creado_por, fecha_modificacion, modificado_por, activo)" +
                                                              "VALUES (@nombre, @porcentaje, @sistema, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por, @activo)";
                parametros.AgregarParametro("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.Nombre);
                parametros.AgregarParametro("@porcentaje", NpgsqlTypes.NpgsqlDbType.Double, pDeduccion.Porcentaje);
                parametros.AgregarParametro("@sistema", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.Sistema);
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pDeduccion.fechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.creadoPor);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pDeduccion.fechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pDeduccion.modificadoPor);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pDeduccion.activo);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
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
                        DeduccionENT deduccion = new DeduccionENT((int)fila["id"], fila["nombre"].ToString(), (double)fila["porcentaje"], fila["sistema"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        deducciones.Add(deduccion);
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
                    DataSet dsetDeducciones = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("SELECT * FROM deduccion where id=" + id);
                    foreach (DataRow fila in dsetDeducciones.Tables[0].Rows)
                    {
                        DeduccionENT deduccion = new DeduccionENT((int)fila["id"], fila["nombre"].ToString(), (double)fila["porcentaje"], fila["sistema"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        deducciones.Add(deduccion);
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
                    DataSet dsetDeducciones = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("SELECT * FROM deduccion where nombre = " + descripcion);
                    foreach (DataRow fila in dsetDeducciones.Tables[0].Rows)
                    {
                        DeduccionENT deduccion = new DeduccionENT((int)fila["id"], fila["nombre"].ToString(), (double)fila["porcentaje"], fila["sistema"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        deducciones.Add(deduccion);
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
