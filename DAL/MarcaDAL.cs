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
        public List<MarcaENT> ObtenerMarcas(DateTime fecha_inicio, DateTime fecha_fin, string tipo_marca, int empleado, int departamento, string generado)
        {
            List<MarcaENT> ListaMarcas = new List<MarcaENT>();
            // Console.WriteLine(pFiltro + " " + 1);
            string consulta = "select * from marca ";
            //"select * from puesto where cast(id AS TEXT) like '" + pTexto + "%'"
            if (fecha_inicio != null || fecha_fin != null || tipo_marca != "" || empleado > 0 || departamento > 0 || generado != "")
            {
                consulta += "where ";
                if (fecha_inicio != null)
                {
                    consulta += "marca_inicio = '" + fecha_inicio + "' ";
                    if (fecha_fin != null)
                    {
                        consulta += "and marca_final = '" + fecha_fin + "' ";
                    }
                    //PENDIENTE
                    if (tipo_marca != "")
                    {
                        
                    }
                    if (empleado > 0)
                    {
                        consulta += "and cast(id_empleado AS TEXT) like '" + empleado + "%' ";
                    }
                    //PENDIENTE
                    if (departamento > 0)
                    {
                        
                    }
                    if (generado != "")
                    {
                        consulta += "and estado like '" + generado + "%' ";
                    }
                }
                if (fecha_fin != null)
                {
                    consulta += "marca_final = '" + fecha_fin + "' ";
                    if (fecha_inicio != null)
                    {
                        consulta += "and marca_inicio = '" + fecha_inicio + "' ";
                    }
                    //PENDIENTE
                    if (tipo_marca != "")
                    {

                    }
                    if (empleado > 0)
                    {
                        consulta += "and cast(id_empleado AS TEXT) like '" + empleado + "%' ";
                    }
                    //PENDIENTE
                    if (departamento > 0)
                    {

                    }
                    if (generado != "")
                    {
                        consulta += "and estado like '" + generado + "%' ";
                    }
                }
                //PENDIENTE
                if (tipo_marca != "")
                {
                    
                }
                if (empleado > 0)
                {
                    consulta += "cast(id_empleado AS TEXT) like '" + empleado + "%' ";
                    if (fecha_fin != null)
                    {
                        consulta += "and marca_final = '" + fecha_fin + "' ";
                    }
                    //PENDIENTE
                    if (tipo_marca != "")
                    {

                    }
                    if (fecha_inicio != null)
                    {
                        consulta += "and marca_inicio = '" + fecha_inicio + "' ";
                    }
                    //PENDIENTE
                    if (departamento > 0)
                    {

                    }
                    if (generado != "")
                    {
                        consulta += "and estado like '" + generado + "%' ";
                    }
                }
                //PENDIENTE
                if (departamento > 0)
                {
                    
                }
                if (generado != "")
                {
                    consulta += "estado like '" + generado + "%' ";
                    if (fecha_fin != null)
                    {
                        consulta += "and marca_final = '" + fecha_fin + "' ";
                    }
                    //PENDIENTE
                    if (tipo_marca != "")
                    {

                    }
                    if (fecha_inicio != null)
                    {
                        consulta += "and marca_inicio = '" + fecha_inicio + "' ";
                    }
                    //PENDIENTE
                    if (departamento > 0)
                    {

                    }
                    if (empleado > 0)
                    {
                        consulta += "and cast(id_empleado AS TEXT) like '" + empleado + "%' ";
                    }
                }
            }
            try
            {

                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL(consulta);
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    string str = fila["imagen"].ToString();
                    byte[] imagen = Encoding.ASCII.GetBytes(str);
                    MarcaENT marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["marca_inicio"].ToString()), DateTime.Parse(fila["marca_final"].ToString()), fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), (Byte[])fila["foto_inicio"], (Byte[])fila["foto_final"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));
                    ListaMarcas.Add(marca);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            


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
                    MarcaENT marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), (DateTime)(fila["marca_inicio"]), DateTime.Now, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), (Byte[])fila["foto_inicio"], null, (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));
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

        public void EditarMarcaDatosCompletos(MarcaENT pMarca)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "UPDATE marca SET marca_final=@marca_final, foto_final=@foto_final, fecha_modificacion=@fecha_modificacion, modificado_por=@modificado_por WHERE id= " + pMarca.idMarca;

                parametros.AgregarParametro("@id", NpgsqlTypes.NpgsqlDbType.Integer, pMarca.idMarca);
                parametros.AgregarParametro("@marca_inicio", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.marcar_inicio);
                parametros.AgregarParametro("@marca_final", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.marcar_final);
                parametros.AgregarParametro("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, pMarca.estado);
                parametros.AgregarParametro("@id_empleado", NpgsqlTypes.NpgsqlDbType.Integer, pMarca.IdEmpleado);
                parametros.AgregarParametro("@foto_inicio", NpgsqlTypes.NpgsqlDbType.Bytea, pMarca.foto_inicio);
                parametros.AgregarParametro("@foto_final", NpgsqlTypes.NpgsqlDbType.Bytea, pMarca.foto_final);
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
    }
}
