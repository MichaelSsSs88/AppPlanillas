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
    class DepartamentoDAL
    {

        public DepartamentoDAL () { }

        public void AgregarDepartamento (DepartamentoENT pDepartamento)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "INSERT INTO departamento (nombre, fecha_creacion, creado_por, fecha_modificacion, modificado_por, activo)" +
                                                              "VALUES (@nombre, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por, @activo)";
                parametros.AgregarParametro("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, pDepartamento.getNombre);
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pDepartamento.getFechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pDepartamento.getCreador);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pDepartamento.getFechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pDepartamento.getModificador);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pDepartamento.getActivo);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ActualizarDepartamento (DepartamentoENT pDepartamento)
        {
            
                int numero = 0;
                try
                {
                   
                    string sentenciaSQL = "UPDATE departamento set nombre =" + pDepartamento.getNombre + " where id = " + pDepartamento.getId;
                    AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                    conexion.EjecutarSQL(sentenciaSQL);
                }
                catch (Exception e)
                {
                    numero = 1;
                    throw e;
                }
            return numero;
        }

        public List<DepartamentoENT> ObtenerDepartamentos()
        {
            List<DepartamentoENT> departamentos = new List<DepartamentoENT>();
            try
            {
                DataSet dsetDepartamentos = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("SELECT * FROM departamento");
                foreach (DataRow fila in dsetDepartamentos.Tables[0].Rows)
                {
                    ENT.DepartamentoENT departamento = new ENT.DepartamentoENT((int)fila["id"], fila["nombre"].ToString(), (DateTime)fila["fecha_creacion"], fila["creado_por"].ToString(), (DateTime)fila["fecha_modificacion"], fila["modificado_por"].ToString(), (bool)fila["activo"]);
                    departamentos.Add(departamento);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return departamentos;
        }

    }
}
