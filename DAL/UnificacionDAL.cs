using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPlanillas.DAL
{
    class UnificacionDAL
    {
        public int AgregarUnificacion(UnificacionENT pUnificacion)
        {

            int numero = 0;
            string auxNumero = "";
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                //conexion.IniciarTransaccion();
                string sentenciaSQL = "INSERT INTO public.unificacion(fecha_inicio, fecha_fin, hora_regular, hora_extra, hora_doble, total_regular, total_extra, total_doble, total_deduccion, id_empleado, id_pago, estado, fecha_creacion, creado_por, fecha_modificacion, modificado_por)" +
                    "VALUES(@fecha_inicio, @fecha_fin, @hora_regular, @hora_extra, @hora_doble, @total_regular, @total_extra, @total_doble, @total_deduccion, @id_empleado, @id_pago, @estado, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por) returning id;";
                parametros.AgregarParametro("@fecha_inicio", NpgsqlTypes.NpgsqlDbType.Timestamp, pUnificacion.fecha_inicio);
                parametros.AgregarParametro("@fecha_fin", NpgsqlTypes.NpgsqlDbType.Timestamp, pUnificacion.fecha_fin);
                parametros.AgregarParametro("@hora_regular", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.hora_regular);
                parametros.AgregarParametro("@hora_extra", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.hora_extra);
                parametros.AgregarParametro("@hora_doble", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.hora_doble);
                parametros.AgregarParametro("@total_regular", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.total_regular);
                parametros.AgregarParametro("@total_extra", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.total_extra);
                parametros.AgregarParametro("@total_doble", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.total_doble);
                parametros.AgregarParametro("@total_deduccion", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.total_deduccion);
                parametros.AgregarParametro("@id_empleado", NpgsqlTypes.NpgsqlDbType.Integer, pUnificacion.idEmpleado);
                parametros.AgregarParametro("@id_pago", NpgsqlTypes.NpgsqlDbType.Integer, pUnificacion.IdPago);
                parametros.AgregarParametro("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, pUnificacion.estado);
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pUnificacion.fechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pUnificacion.creadoPor);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pUnificacion.fechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pUnificacion.modificadoPor);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros(), ref auxNumero);
                numero = Int32.Parse(auxNumero);
            }
            catch (Exception e)
            {
                throw e;
            }
            return numero;
        }

        public List<UnificacionENT> ObtenerUnificacion(int IdPago)
        {
            List<UnificacionENT> ListaUnificacion = new List<UnificacionENT>();
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string consulta = "select UNIFICACION.* from UNIFICACION join empleado on UNIFICACION.id_empleado = empleado.id join puesto on puesto.id = empleado.id_puesto and UNIFICACION.id_pago=@id_pago";
                parametros.AgregarParametro("@id_pago", NpgsqlTypes.NpgsqlDbType.Integer, IdPago);
                DataSet dsetClientes = conexion.EjecutarConsultaSQL(consulta, parametros.ObtenerParametros());
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    UnificacionENT unificacion = null;

                    if (fila["id_pago"] == null)
                        unificacion = new UnificacionENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["fecha_inicio"].ToString()), DateTime.Parse(fila["fecha_fin"].ToString()), Double.Parse(fila["hora_regular"].ToString()), Double.Parse(fila["hora_extra"].ToString()), Double.Parse(fila["hora_doble"].ToString()), Double.Parse(fila["total_regular"].ToString()), Double.Parse(fila["total_extra"].ToString()), Double.Parse(fila["total_doble"].ToString()), Double.Parse(fila["total_deduccion"].ToString()), Int32.Parse(fila["id_empleado"].ToString()), fila["estado"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), null);
                    else
                        unificacion = new UnificacionENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["fecha_inicio"].ToString()), DateTime.Parse(fila["fecha_fin"].ToString()), Double.Parse(fila["hora_regular"].ToString()), Double.Parse(fila["hora_extra"].ToString()), Double.Parse(fila["hora_doble"].ToString()), Double.Parse(fila["total_regular"].ToString()), Double.Parse(fila["total_extra"].ToString()), Double.Parse(fila["total_doble"].ToString()), Double.Parse(fila["total_deduccion"].ToString()), Int32.Parse(fila["id_empleado"].ToString()), fila["estado"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), Int32.Parse(fila["id_pago"].ToString()));

                    ListaUnificacion.Add(unificacion);
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return ListaUnificacion;
            }

        public List<UnificacionENT> ObtenerUnificacion(String fecha_inicio, String fecha_fin, int empleado, int departamento, string generado)
        {
            List<UnificacionENT> ListaUnificacion = new List<UnificacionENT>();
            Parametro parametros = new Parametro();
            string consulta = "select UNIFICACION.* from UNIFICACION join empleado on UNIFICACION.id_empleado = empleado.id join puesto on puesto.id = empleado.id_puesto ";
            if (fecha_inicio != "" || fecha_fin != "" || empleado > 0 || departamento > 0 || generado != "")
            {

                if (fecha_inicio != "")
                {

                   consulta += "and UNIFICACION.fecha_inicio >= @fecha_inicio";
                   parametros.AgregarParametro("@fecha_inicio", NpgsqlTypes.NpgsqlDbType.Timestamp, DateTime.Parse(fecha_inicio));

                }
                if (fecha_fin != "")
                {
                        consulta += " and UNIFICACION.fecha_fin <= @fecha_fin";
                        parametros.AgregarParametro("@fecha_fin", NpgsqlTypes.NpgsqlDbType.Timestamp, DateTime.Parse(fecha_fin));


                }
                //PENDIENTE
                if (empleado > 0)
                {

                    consulta += " and UNIFICACION.id_empleado= " + empleado;

                }
                //PENDIENTE
                if (departamento > 0)
                {
                    consulta += " and puesto.id_departamento=" + departamento;
                }
                if (generado != "")
                {

                    consulta += " and UNIFICACION.estado = '" + generado.ToLower() + "'";

                }
            }

            try
            {

                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL(consulta, parametros.ObtenerParametros());
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                        UnificacionENT unificacion = null;
                    try
                    {
                        unificacion = new UnificacionENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["fecha_inicio"].ToString()), DateTime.Parse(fila["fecha_fin"].ToString()), Double.Parse(fila["hora_regular"].ToString()), Double.Parse(fila["hora_extra"].ToString()), Double.Parse(fila["hora_doble"].ToString()), Double.Parse(fila["total_regular"].ToString()), Double.Parse(fila["total_extra"].ToString()), Double.Parse(fila["total_doble"].ToString()), Double.Parse(fila["total_deduccion"].ToString()), Int32.Parse(fila["id_empleado"].ToString()), fila["estado"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), Int32.Parse(fila["id_pago"].ToString()));


                    }
                    catch
                    {
                        unificacion = new UnificacionENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["fecha_inicio"].ToString()), DateTime.Parse(fila["fecha_fin"].ToString()), Double.Parse(fila["hora_regular"].ToString()), Double.Parse(fila["hora_extra"].ToString()), Double.Parse(fila["hora_doble"].ToString()), Double.Parse(fila["total_regular"].ToString()), Double.Parse(fila["total_extra"].ToString()), Double.Parse(fila["total_doble"].ToString()), Double.Parse(fila["total_deduccion"].ToString()), Int32.Parse(fila["id_empleado"].ToString()), fila["estado"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), /*(int?)(Object) fila["id_pago"].ToString()*/null);

                    }
                    ListaUnificacion.Add(unificacion);
                }
            }
            catch (Exception e)
            {
                throw e;
            }




            return ListaUnificacion;
        }

        public void EditarUnificacionQuitarMarca(UnificacionENT pUnificacion)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "UPDATE unificacion SET  hora_regular=@hora_regular, hora_extra=@hora_extra, hora_doble=@hora_doble, total_regular=@total_regular, total_extra=@total_extra, total_doble=@total_doble,total_deduccion=@total_deduccion,estado=@estado, fecha_modificacion=@fecha_modificacion, modificado_por=@modificado_por, id_pago=@id_pago  WHERE id= @id";

                //parametros.AgregarParametro("@fecha_inicio", NpgsqlTypes.NpgsqlDbType.Timestamp, pUnificacion.fecha_inicio);
                //parametros.AgregarParametro("@fecha_fin", NpgsqlTypes.NpgsqlDbType.Timestamp, pUnificacion.fecha_fin);
                parametros.AgregarParametro("@id", NpgsqlTypes.NpgsqlDbType.Integer, pUnificacion.idUnificacion);
                parametros.AgregarParametro("@hora_regular", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.hora_regular);
                parametros.AgregarParametro("@hora_extra", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.hora_extra);
                parametros.AgregarParametro("@hora_doble", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.hora_doble);
                parametros.AgregarParametro("@total_regular", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.total_regular);
                parametros.AgregarParametro("@total_extra", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.total_extra);
                parametros.AgregarParametro("@total_doble", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.total_doble);
                parametros.AgregarParametro("@total_deduccion", NpgsqlTypes.NpgsqlDbType.Double, pUnificacion.total_deduccion);
                //parametros.AgregarParametro("@id_empleado", NpgsqlTypes.NpgsqlDbType.Integer, pUnificacion.idEmpleado);
                parametros.AgregarParametro("@id_pago", NpgsqlTypes.NpgsqlDbType.Integer, pUnificacion.IdPago);
                parametros.AgregarParametro("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, pUnificacion.estado);
                //parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pUnificacion.fechaCreacion);
                //parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pUnificacion.creadoPor);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pUnificacion.fechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pUnificacion.modificadoPor);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
