using ENT;
using System;
using System.Collections.Generic;
using System.Data;
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
                    "VALUES(@fecha_inicio, @fecha_fin, @descripcion, @total, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por) returning id;";
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

        public void EliminarPago(/*UsuarioENT*/int pPago)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "DELETE FROM pago WHERE id = @id";
                parametros.AgregarParametro("@id", NpgsqlTypes.NpgsqlDbType.Integer, pPago);


                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PagoENT> ObtenerPago(DateTime? fecha_inicio, DateTime? fecha_fin)
        {
            List<PagoENT> ListaPago = new List<PagoENT>();
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                parametros.AgregarParametro("@fecha_inicio", NpgsqlTypes.NpgsqlDbType.Timestamp, fecha_inicio);
                parametros.AgregarParametro("@fecha_fin", NpgsqlTypes.NpgsqlDbType.Timestamp, fecha_fin);
                string consulta = "select * from pago ";
                if (fecha_inicio != null && fecha_fin != null)
                    consulta += "where fecha_inicio>=@fecha_inicio and fecha_fin<=@fecha_fin";
                
                else if(fecha_inicio != null)
                    consulta += "where fecha_inicio>=@fecha_inicio";

                else if(fecha_fin != null)
                    consulta += "where fecha_fin<=@fecha_fin";

                try
                {

                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL(consulta, parametros.ObtenerParametros());
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        PagoENT pago = null;

                        pago = new PagoENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["fecha_inicio"].ToString()), DateTime.Parse(fila["fecha_fin"].ToString()),fila["descripcion"].ToString(), Double.Parse(fila["total"].ToString()), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString());

                        ListaPago.Add(pago);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ListaPago;
        }
    }
}
