using AppPlanillas.ENT;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPlanillas.DAL
{
    class PuestoDAL
    {
        public List<PuestoENT> ObtenerPuestos(string pFiltro, string pTexto)
        {
            List<PuestoENT> ListaPuestos = new List<PuestoENT>();
            if (pFiltro == "Todos")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from puesto");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        PuestoENT puesto = new PuestoENT(Int32.Parse(fila["id"].ToString()), fila["descripcion"].ToString(), Int32.Parse(fila["id_departamento"].ToString()), DateTime.Parse(fila["fecha_creacion"].ToString()), fila["creado_por"].ToString(), DateTime.Parse(fila["fecha_modificacion"].ToString()), fila["modificado_por"].ToString(), Boolean.Parse(fila["activo"].ToString()));
                        ListaPuestos.Add(puesto);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Código")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from puesto where cast(id AS TEXT) like '" + pTexto + "%'");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        PuestoENT puesto = new PuestoENT(Int32.Parse(fila["id"].ToString()), fila["descripcion"].ToString(), Int32.Parse(fila["id_departamento"].ToString()), DateTime.Parse(fila["fecha_creacion"].ToString()), fila["creado_por"].ToString(), DateTime.Parse(fila["fecha_modificacion"].ToString()), fila["modificado_por"].ToString(), Boolean.Parse(fila["activo"].ToString()));
                        ListaPuestos.Add(puesto);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Descripción")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from puesto where descripcion like '" + pTexto + "%'"); 
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        PuestoENT puesto = new PuestoENT(Int32.Parse(fila["id"].ToString()), fila["descripcion"].ToString(), Int32.Parse(fila["id_departamento"].ToString()), DateTime.Parse(fila["fecha_creacion"].ToString()), fila["creado_por"].ToString(), DateTime.Parse(fila["fecha_modificacion"].ToString()), fila["modificado_por"].ToString(), Boolean.Parse(fila["activo"].ToString()));
                        ListaPuestos.Add(puesto);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Código Departamento")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from puesto where cast(id_departamento AS TEXT) like '" + pTexto + "%'");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        PuestoENT puesto = new PuestoENT(Int32.Parse(fila["id"].ToString()), fila["descripcion"].ToString(), Int32.Parse(fila["id_departamento"].ToString()), DateTime.Parse(fila["fecha_creacion"].ToString()), fila["creado_por"].ToString(), DateTime.Parse(fila["fecha_modificacion"].ToString()), fila["modificado_por"].ToString(), Boolean.Parse(fila["activo"].ToString()));
                        ListaPuestos.Add(puesto);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Fecha creacion")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from puesto where fecha_creacion = '" + pTexto + "");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        PuestoENT puesto = new PuestoENT(Int32.Parse(fila["id"].ToString()), fila["descripcion"].ToString(), Int32.Parse(fila["id_departamento"].ToString()), DateTime.Parse(fila["fecha_creacion"].ToString()), fila["creado_por"].ToString(), DateTime.Parse(fila["fecha_modificacion"].ToString()), fila["modificado_por"].ToString(), Boolean.Parse(fila["activo"].ToString()));
                        ListaPuestos.Add(puesto);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Creado por")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from puesto where creado_por like '" + pTexto + "%'");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        PuestoENT puesto = new PuestoENT(Int32.Parse(fila["id"].ToString()), fila["descripcion"].ToString(), Int32.Parse(fila["id_departamento"].ToString()), DateTime.Parse(fila["fecha_creacion"].ToString()), fila["creado_por"].ToString(), DateTime.Parse(fila["fecha_modificacion"].ToString()), fila["modificado_por"].ToString(), Boolean.Parse(fila["activo"].ToString()));
                        ListaPuestos.Add(puesto);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Fecha modificacion")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from puesto where fecha_modificacion = '" + pTexto + "");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        PuestoENT puesto = new PuestoENT(Int32.Parse(fila["id"].ToString()), fila["descripcion"].ToString(), Int32.Parse(fila["id_departamento"].ToString()), DateTime.Parse(fila["fecha_creacion"].ToString()), fila["creado_por"].ToString(), DateTime.Parse(fila["fecha_modificacion"].ToString()), fila["modificado_por"].ToString(), Boolean.Parse(fila["activo"].ToString()));
                        ListaPuestos.Add(puesto);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Modificado por")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from puesto where modificado_por like '" + pTexto + "%'");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        PuestoENT puesto = new PuestoENT(Int32.Parse(fila["id"].ToString()), fila["descripcion"].ToString(), Int32.Parse(fila["id_departamento"].ToString()), DateTime.Parse(fila["fecha_creacion"].ToString()), fila["creado_por"].ToString(), DateTime.Parse(fila["fecha_modificacion"].ToString()), fila["modificado_por"].ToString(), Boolean.Parse(fila["activo"].ToString()));
                        ListaPuestos.Add(puesto);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Activo")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from puesto where activo = true");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        PuestoENT puesto = new PuestoENT(Int32.Parse(fila["id"].ToString()), fila["descripcion"].ToString(), Int32.Parse(fila["id_departamento"].ToString()), DateTime.Parse(fila["fecha_creacion"].ToString()), fila["creado_por"].ToString(), DateTime.Parse(fila["fecha_modificacion"].ToString()), fila["modificado_por"].ToString(), Boolean.Parse(fila["activo"].ToString()));
                        ListaPuestos.Add(puesto);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (pFiltro == "Inactivo")
            {
                try
                {
                    DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from puesto where activo = false");
                    foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                    {
                        PuestoENT puesto = new PuestoENT(Int32.Parse(fila["id"].ToString()), fila["descripcion"].ToString(), Int32.Parse(fila["id_departamento"].ToString()), DateTime.Parse(fila["fecha_creacion"].ToString()), fila["creado_por"].ToString(), DateTime.Parse(fila["fecha_modificacion"].ToString()), fila["modificado_por"].ToString(), Boolean.Parse(fila["activo"].ToString()));
                        ListaPuestos.Add(puesto);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return ListaPuestos;
        }

        public void AgregarPuesto(PuestoENT pPuesto)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "INSERT INTO puesto(descripcion, id_departamento, fecha_creacion, creado_por, fecha_modificacion, modificado_por, activo)VALUES(@descripcion, @id_departamento, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por, @activo)";

                parametros.AgregarParametro("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, pPuesto.Descripcion);
                parametros.AgregarParametro("@id_departamento", NpgsqlTypes.NpgsqlDbType.Integer, pPuesto.Id_departamento);
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pPuesto.Fecha_creacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pPuesto.Creado_por);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pPuesto.Fecha_modificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pPuesto.Modificado_por);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pPuesto.Activo);

                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ActualizarPuestos(PuestoENT pPuesto)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "UPDATE puesto SET descripcion =@descripcion, id_departamento=@id_departamento, fecha_modificacion=@fecha_modificacion,  modificado_por=@modificado_por, activo=@activo WHERE id =" + pPuesto.Id;
                parametros.AgregarParametro("@descripcion", NpgsqlTypes.NpgsqlDbType.Varchar, pPuesto.Descripcion);
                parametros.AgregarParametro("@id_departamento", NpgsqlTypes.NpgsqlDbType.Integer, pPuesto.Id_departamento);
               // parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pPuesto.Fecha_creacion);
                //parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pPuesto.Creado_por);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pPuesto.Fecha_modificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pPuesto.Modificado_por);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pPuesto.Activo);


                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void EliminarPuesto(int pPuesto)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "DELETE FROM puesto WHERE id = @id";
                parametros.AgregarParametro("@id", NpgsqlTypes.NpgsqlDbType.Integer, pPuesto);


                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
