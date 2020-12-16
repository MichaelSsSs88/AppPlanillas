using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class MarcaDAL
    {
        public List<MarcaENT> ObtenerMarcas(String fecha_inicio, String fecha_fin, string tipo_marca, int empleado, int departamento, string generado)
        {
            List<MarcaENT> ListaMarcas = new List<MarcaENT>();
            string consulta = "select marca.* from marca join empleado on marca.id_empleado = empleado.id join puesto on puesto.id = empleado.id_puesto ";
            if (fecha_inicio != "" || fecha_fin != "" || tipo_marca != "" || empleado > 0 || departamento > 0 || generado != "")
            {
                
                if (fecha_inicio != "")
                {
                   
                        if (tipo_marca == "Entrada")
                        {
                            consulta += "and marca.marca_inicio >='" + DateTime.Parse(fecha_inicio) + "'";
                        }
                        else if (tipo_marca == "Salida")
                        {
                        consulta += "and marca.marca_final >='" + DateTime.Parse(fecha_inicio) + "'";
                        }
                        else
                        {
                        consulta += "and marca.marca_inicio >'" + DateTime.Parse(fecha_inicio) + "'";
                        }   
                  
                }
                if (fecha_fin != "")
                {
                    if (tipo_marca == "Entrada")
                    {
                        
                            consulta += " and marca.marca_inicio <= '" + DateTime.Parse(fecha_fin) + "' ";
                    }
                    else if (tipo_marca == "Salida")
                    {
                        
                            consulta += " and marca.marca_final <= '" + DateTime.Parse(fecha_fin) + "' ";
                    }
                    else
                    {
                        
                            consulta += " and marca.marca_final <= '" + DateTime.Parse(fecha_fin) + "' ";
                    }
                    
                    
                }
                //PENDIENTE
               if (empleado > 0)
                {
                    
                        consulta += " and marca.id_empleado= " + empleado;
                    
                }
                //PENDIENTE
                if (departamento > 0)
                {
                    consulta += " and puesto.id_departamento=" + departamento;
                }
                if (generado != "")
                {
                  
                    consulta += " and marca.estado = '" + generado.ToLower() + "'"; 
                   
                }
            }
           
            try
            {

                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL(consulta);
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    string str = fila["foto_inicio"].ToString();
                    DateTime? entrada = null;
                    DateTime? salida = null;
                    if (fila["marca_inicio"].ToString().Length > 0)
                        entrada = DateTime.Parse(fila["marca_inicio"].ToString());
                    if (fila["marca_final"].ToString().Length > 0)
                        salida = DateTime.Parse(fila["marca_final"].ToString());


                    MarcaENT marca = null;
                    if (fila["foto_inicio"].ToString().Length>0 && fila["foto_final"].ToString().Length > 0)
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), (Byte[])fila["foto_inicio"], (Byte[])fila["foto_final"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));
                    else if (fila["foto_inicio"].ToString().Length>0)
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), (Byte[])fila["foto_inicio"], null, (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));
                    else if (fila["foto_final"].ToString().Length > 0)
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), null, (Byte[])fila["foto_final"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));
                    else
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), null, null, (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));

                    //byte[] imagen = Encoding.ASCII.GetBytes(str);
                    ListaMarcas.Add(marca);
                }
            }
            catch (Exception e)
            {
                    throw e;
            }

            return ListaMarcas;
        }

        public List<MarcaENT> ObtenerMarcasUnificadas(int IdUnificacion)
        {
            List<MarcaENT> ListaMarcas = new List<MarcaENT>();
            //string consulta = "select marca.* from marca join empleado on marca.id_empleado = empleado.id join puesto on puesto.id = empleado.id_puesto ";
            string consulta = "select marca.* from marca join empleado on marca.id_empleado = empleado.id join puesto on puesto.id = empleado.id_puesto  where marca.id_unificacion=@IdUnificacion";
              Parametro parametros = new Parametro();
            
              //AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
               parametros.AgregarParametro("@IdUnificacion", NpgsqlTypes.NpgsqlDbType.Integer, IdUnificacion);
               
            try
            {
                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL(consulta,parametros.ObtenerParametros());
              
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    string str = fila["foto_inicio"].ToString();
                    DateTime? entrada = null;
                    DateTime? salida = null;
                    if (fila["marca_inicio"].ToString().Length > 0)
                        entrada = DateTime.Parse(fila["marca_inicio"].ToString());
                    if (fila["marca_final"].ToString().Length > 0)
                        salida = DateTime.Parse(fila["marca_final"].ToString());


                    MarcaENT marca = null;
                    if (fila["foto_inicio"].ToString().Length > 0 && fila["foto_final"].ToString().Length > 0)
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), (Byte[])fila["foto_inicio"], (Byte[])fila["foto_final"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));
                    else if (fila["foto_inicio"].ToString().Length > 0)
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), (Byte[])fila["foto_inicio"], null, (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));
                    else if (fila["foto_final"].ToString().Length > 0)
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), null, (Byte[])fila["foto_final"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));
                    else
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), null, null, (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));

                    ListaMarcas.Add(marca);
                }
                
            }
            catch (Exception Ex)
            {
              
                throw Ex;
            }
            
            return ListaMarcas;
        }


            public List<MarcaENT> ObtenerMarcas(String fecha_inicio, int empleado, string generado)
        {
            List<MarcaENT> ListaMarcas = new List<MarcaENT>();
            string consulta = "select marca.* from marca join empleado on marca.id_empleado = empleado.id join puesto on puesto.id = empleado.id_puesto ";
            if (fecha_inicio != "" || empleado > 0 || generado != "")
            {

                if (fecha_inicio != "")
                {
                    consulta += "and to_char(marca.marca_inicio, 'dd/MM/yyyy') ='" + fecha_inicio + "'";

                }

                //PENDIENTE
                if (empleado > 0)
                {

                    consulta += " and marca.id_empleado= " + empleado;

                }
                //PENDIENTE

                if (generado != "")
                {

                    consulta += " and marca.estado = '" + generado.ToLower() + "'";

                }
            }

            try
            {

                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL(consulta);
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    string str = fila["foto_inicio"].ToString();
                    DateTime? entrada = null;
                    DateTime? salida = null;
                    if (fila["marca_inicio"].ToString().Length > 0)
                        entrada = DateTime.Parse(fila["marca_inicio"].ToString());
                    if (fila["marca_final"].ToString().Length > 0)
                        salida = DateTime.Parse(fila["marca_final"].ToString());


                    MarcaENT marca = null;
                    if (fila["foto_inicio"].ToString().Length > 0 && fila["foto_final"].ToString().Length > 0)
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), (Byte[])fila["foto_inicio"], (Byte[])fila["foto_final"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));
                    else if (fila["foto_inicio"].ToString().Length > 0)
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), (Byte[])fila["foto_inicio"], null, (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));
                    else if (fila["foto_final"].ToString().Length > 0)
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), null, (Byte[])fila["foto_final"], (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));
                    else
                        marca = new MarcaENT(Int32.Parse(fila["id"].ToString()), entrada, salida, fila["estado"].ToString(), Int32.Parse(fila["id_empleado"].ToString()), null, null, (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), int.Parse(fila["id_unificacion"].ToString()));

                    //byte[] imagen = Encoding.ASCII.GetBytes(str);
                   // Console.WriteLine(marca.idMarca + " " + marca.marcar_inicio.ToString());
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
                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from marca where id_empleado=" + pIdEmpleado + " and marca_final is null and estado='generado'");
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
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

        public void AgregarMarcaManual(MarcaENT pMarca)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "INSERT INTO public.marca(marca_inicio, marca_final, estado, id_empleado, foto_inicio, fecha_creacion, creado_por, fecha_modificacion, modificado_por, id_unificacion)" +
                                      "VALUES(@marca_inicio, @marca_final, @estado, @id_empleado, @foto_inicio, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por, @id_unificacion)";

                parametros.AgregarParametro("@marca_inicio", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.marcar_inicio);
                parametros.AgregarParametro("@marca_final", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.marcar_final);
                parametros.AgregarParametro("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, pMarca.estado);
                parametros.AgregarParametro("@id_empleado", NpgsqlTypes.NpgsqlDbType.Integer, pMarca.IdEmpleado);
                parametros.AgregarParametro("@foto_inicio", NpgsqlTypes.NpgsqlDbType.Bytea, pMarca.foto_inicio);
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.fechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pMarca.creadoPor);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pMarca.fechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pMarca.modificadoPor);
                parametros.AgregarParametro("@id_unificacion", NpgsqlTypes.NpgsqlDbType.Integer, pMarca.IdUnificacion);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void AnularMarca(int IdMarca)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "UPDATE marca SET estado='nulo' WHERE id= @IdMarca";
                parametros.AgregarParametro("@IdMarca", NpgsqlTypes.NpgsqlDbType.Integer, IdMarca);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch
            {

            }
        }


    public void EliminarMarca(int IdMarca)
            {
                try
                {
                    Parametro parametros = new Parametro();
                    AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                    string sentenciaSQL = "DELETE FROM marca WHERE id= " + IdMarca;
                }
                catch
                {
                    throw;
                }
            }

        public void EditarMarcaEstadoUnificacio(MarcaENT marcaENT)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "UPDATE marca SET estado=@estado,fecha_modificacion=@fecha_modificacion, modificado_por=@modificado_por WHERE id=@idMarca";
                parametros.AgregarParametro("@idMarca", NpgsqlTypes.NpgsqlDbType.Integer, marcaENT.idMarca);
                parametros.AgregarParametro("@estado", NpgsqlTypes.NpgsqlDbType.Varchar, marcaENT.estado);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, DateTime.Now);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, marcaENT.modificadoPor);
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
                string sentenciaSQL = "UPDATE marca SET marca_inicio=@marca_inicio,marca_final=@marca_final, estado=@estado, id_empleado=@id_empleado, foto_inicio=@foto_inicio,foto_final=@foto_final, fecha_modificacion=@fecha_modificacion, modificado_por=@modificado_por, id_unificacion=@id_unificacion WHERE id= @id";

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
                parametros.AgregarParametro("@id_unificacion", NpgsqlTypes.NpgsqlDbType.Integer, pMarca.IdUnificacion);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
