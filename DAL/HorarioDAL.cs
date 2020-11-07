using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIIIC
{
    class HorarioDAL
    {
        public List<HorarioENT> ObtenerHorarios(int id, string dias)
        {
            List<HorarioENT> ListaHorarios = new List<HorarioENT>();
            if ((id == -1) && (dias== ""))
            {

                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from horario");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        HorarioENT horario = new HorarioENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["hora_inicio"].ToString()), DateTime.Parse(fila["hora_final"].ToString()), fila["dia"].ToString(), fila["descripcion"].ToString(), Int32.Parse(fila["horas_ordinarias"].ToString()), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaHorarios.Add(horario);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if ((id > -1))
            {

                try
                {
                    //select* from books where convert(char(32), book_id) like '7%'CAST(price AS TEXT)
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from horario where cast(id AS TEXT) like '"+id + "%'");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        HorarioENT horario = new HorarioENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["hora_inicio"].ToString()), DateTime.Parse(fila["hora_final"].ToString()), fila["dia"].ToString(), fila["descripcion"].ToString(), Int32.Parse(fila["horas_ordinarias"].ToString()), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaHorarios.Add(horario);
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
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from horario where dia like " + "'" +dias + "%'");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        
                        HorarioENT horario = new HorarioENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["hora_inicio"].ToString()), DateTime.Parse(fila["hora_final"].ToString()), fila["dia"].ToString(), fila["descripcion"].ToString(), Int32.Parse(fila["horas_ordinarias"].ToString()), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaHorarios.Add(horario);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            return ListaHorarios;
        }

        public void AgregarHorario(HorarioENT pHorario)
        {
            Console.WriteLine("Hola");
            Console.WriteLine(pHorario.Horas_Ordinarias);
            Console.WriteLine("Adios");
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                
                string sentenciaSQL = "INSERT INTO horario(descripcion, dia, hora_inicio, hora_final, horas_ordinarias, fecha_creacion, creado_por, fecha_modificacion, modificado_por, activo)VALUES(@descripcion, @dia, @hora_inicio, @hora_final, @horas_ordinarias, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por, @activo)";
                parametros.AgregarParametro("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, pHorario.Descripcion);
                parametros.AgregarParametro("@dia", NpgsqlTypes.NpgsqlDbType.Varchar, pHorario.Dia);
                parametros.AgregarParametro("@hora_inicio", NpgsqlTypes.NpgsqlDbType.Time, TimeSpan.Parse(pHorario.Hora_Inicio));
                parametros.AgregarParametro("@hora_final", NpgsqlTypes.NpgsqlDbType.Time, TimeSpan.Parse(pHorario.Hora_Final));
                parametros.AgregarParametro("@horas_ordinarias", NpgsqlTypes.NpgsqlDbType.Integer, pHorario.Horas_Ordinarias);
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pHorario.getFechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pHorario.getCreador);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pHorario.getFechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pHorario.getModificador);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pHorario.getActivo);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ActualizarHorario(HorarioENT pHorario)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "UPDATE horario SET descripcion =@descripcion, dia =@dia, hora_inicio =@hora_inicio, hora_final =@hora_final, horas_ordinarias =@horas_ordinarias, fecha_modificacion =@fecha_modificacion, modificado_por =@modificado_por, activo =@activo WHERE id =" + pHorario.Id ;
                parametros.AgregarParametro("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, pHorario.Descripcion);
                parametros.AgregarParametro("@dia", NpgsqlTypes.NpgsqlDbType.Varchar, pHorario.Dia);
                parametros.AgregarParametro("@hora_inicio", NpgsqlTypes.NpgsqlDbType.Time, TimeSpan.Parse(pHorario.Hora_Inicio));
                parametros.AgregarParametro("@hora_final", NpgsqlTypes.NpgsqlDbType.Time, TimeSpan.Parse(pHorario.Hora_Final));
                parametros.AgregarParametro("@horas_ordinarias", NpgsqlTypes.NpgsqlDbType.Integer, pHorario.Horas_Ordinarias);
                //parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pHorario.getFechaCreacion);
                //parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pHorario.getCreador);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pHorario.getFechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pHorario.getModificador);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pHorario.getActivo);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void EliminarHorario(int id)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "delete from horario where id = " + id;
                conexion.EjecutarSQL(sentenciaSQL);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /**/
    }
}
