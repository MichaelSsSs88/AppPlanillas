using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class PagoDAL
    {
       public int AgregarPago(PagoENT pPago)
        {

            int numero = 0;
            string auxNumero = "";
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                //conexion.IniciarTransaccion();
                string sentenciaSQL = "INSERT INTO public.pago(fecha_inicio, fecha_fin, descripcion, total, fecha_creacion, creado_por, fecha_modificacion, modificado_por)" +
                    "VALUES(@fecha_inicio, @fecha_fin, @hora_regular, @hora_extra, @hora_doble, @total_regular, @total_extra, @total_doble, @total_deduccion, @id_empleado, @id_pago, @estado, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por) returning id;";
                parametros.AgregarParametro("@fecha_inicio", NpgsqlTypes.NpgsqlDbType.Timestamp, pPago.fecha_inicio);
                parametros.AgregarParametro("@fecha_fin", NpgsqlTypes.NpgsqlDbType.Timestamp, pPago.fecha_fin);
                parametros.AgregarParametro("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, pPago.descripcion);
                parametros.AgregarParametro("@total", NpgsqlTypes.NpgsqlDbType.Double, pPago.total);
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pPago.fechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pPago.creadoPor);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pPago.fechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pPago.modificadoPor);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros(), ref auxNumero);
                numero = Int32.Parse(auxNumero);
            }
            catch (Exception e)
            {
                throw e;
            }
            return numero;
        }
    }
}
