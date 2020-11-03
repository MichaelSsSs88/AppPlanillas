using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace AppPlanillas.DAL
{
    class Deduccion
    {
        public Deduccion () { }

        public void AgregarDeduccion (ENT.Deduccion pDeduccion)
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

        public List<ENT.Deduccion> ObtenerDeducciones ()
        {
            List<ENT.Deduccion> deducciones = new List<ENT.Deduccion>();
            try
            {
                DataSet dsetDeducciones = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("SELECT * FROM deduccion");
                foreach (DataRow fila in dsetDeducciones.Tables[0].Rows)
                {
                    ENT.Deduccion deduccion = new ENT.Deduccion();
                    deduccion.Id = (int)fila["id"];
                    deduccion.Nombre = fila["nombre"].ToString();
                    deduccion.Porcentaje = (double)fila["porcentaje"];
                    deduccion.Sistema = fila["sistema"].ToString();
                    deduccion.fechaCreacion = (DateTime)fila["fecha_creacion"];
                    deduccion.creadoPor = fila["creado_por"].ToString();
                    deduccion.fechaModificacion = (DateTime)fila["fecha_modificacion"];
                    deduccion.modificadoPor = fila["modificado_por"].ToString();
                    deducciones.Add(deduccion);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return deducciones;
        }

    }
}
