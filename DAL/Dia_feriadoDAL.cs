﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENT;

namespace DAL
{
    class Dia_feriadoDAL
    {
        public List<Dia_feriadoENT> ObtenerFeriados(string pFiltro, string pTexto)
        {
            List<Dia_feriadoENT> ListaFeriados = new List<Dia_feriadoENT>();
            if (pFiltro == "Todos") {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from dia_feriado");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        Dia_feriadoENT feriado = new Dia_feriadoENT(Int32.Parse(fila["id"].ToString()), Int32.Parse(fila["dia"].ToString()), Int32.Parse(fila["mes"].ToString()), fila["motivo"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaFeriados.Add(feriado);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Codigo")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from dia_feriado where id = " + int.Parse(pTexto));
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        Dia_feriadoENT feriado = new Dia_feriadoENT(Int32.Parse(fila["id"].ToString()), Int32.Parse(fila["dia"].ToString()), Int32.Parse(fila["mes"].ToString()), fila["motivo"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaFeriados.Add(feriado);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Fecha")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from dia_feriado where id = " + DateTime.Parse(pTexto));
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        Dia_feriadoENT feriado = new Dia_feriadoENT(Int32.Parse(fila["id"].ToString()), Int32.Parse(fila["dia"].ToString()), Int32.Parse(fila["mes"].ToString()), fila["motivo"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaFeriados.Add(feriado);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Motivo")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from dia_feriado where id = " + pTexto);
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        Dia_feriadoENT feriado = new Dia_feriadoENT(Int32.Parse(fila["id"].ToString()), Int32.Parse(fila["dia"].ToString()), Int32.Parse(fila["mes"].ToString()), fila["motivo"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                        ListaFeriados.Add(feriado);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return ListaFeriados;
        }

        public void AgregarFeriado (Dia_feriadoENT pFeriado)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "INSERT INTO dia_feriado (motivo, dia, mes, fecha_creacion, creado_por, fecha_modificacion, modificado_por, activo)" +
                                      "VALUES (@motivo, @dia, @mes @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por, @activo)";
               
                parametros.AgregarParametro("@motivo", NpgsqlTypes.NpgsqlDbType.Varchar, pFeriado.Motivo);
                parametros.AgregarParametro("@dia", NpgsqlTypes.NpgsqlDbType.Integer, pFeriado.Dia);
                parametros.AgregarParametro("@mes", NpgsqlTypes.NpgsqlDbType.Integer, pFeriado.Mes);
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pFeriado.getFechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pFeriado.getCreador);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pFeriado.getFechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pFeriado.getModificador);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pFeriado.getActivo);

                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void ActualizarDiaFeriado(Dia_feriadoENT pFeriado)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "UPDATE dia_feriado SET dia =@dia, mes=@mes, motivo =@motivo WHERE id " + pFeriado.Id;
                parametros.AgregarParametro("@dia", NpgsqlTypes.NpgsqlDbType.Date, pFeriado.Dia);
                parametros.AgregarParametro("@mes", NpgsqlTypes.NpgsqlDbType.Date, pFeriado.Mes);
                parametros.AgregarParametro("@motivo", NpgsqlTypes.NpgsqlDbType.Varchar, pFeriado.Motivo);
                

                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void EliminarDiaFeriado(Dia_feriadoENT pFeriado)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "DELETE FROM dia_feriado WHERE id = @id";
                parametros.AgregarParametro("@id", NpgsqlTypes.NpgsqlDbType.Integer, pFeriado.Id);
                

                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
