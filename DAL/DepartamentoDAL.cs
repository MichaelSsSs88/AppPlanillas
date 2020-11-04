using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace AppPlanillas.DAL
{
    class DepartamentoDAL
    {

        public DepartamentoDAL () { }

        public void AgregarDepartamento (ENT.DepartamentoENT pDepartamento)
        {
            try
            {
                Parametro parametros = new Parametro();
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                string sentenciaSQL = "INSERT INTO departamento (nombre, fecha_creacion, creado_por, fecha_modificacion, modificado_por, activo)" +
                                                              "VALUES (@nombre, @fecha_creacion, @creado_por, @fecha_modificacion, @modificado_por, @activo)";
                parametros.AgregarParametro("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar, pDepartamento.Nombre);
                parametros.AgregarParametro("@fecha_creacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pDepartamento.fechaCreacion);
                parametros.AgregarParametro("@creado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pDepartamento.creadoPor);
                parametros.AgregarParametro("@fecha_modificacion", NpgsqlTypes.NpgsqlDbType.Timestamp, pDepartamento.fechaModificacion);
                parametros.AgregarParametro("@modificado_por", NpgsqlTypes.NpgsqlDbType.Varchar, pDepartamento.modificadoPor);
                parametros.AgregarParametro("@activo", NpgsqlTypes.NpgsqlDbType.Boolean, pDepartamento.activo);
                conexion.EjecutarSQL(sentenciaSQL, parametros.ObtenerParametros());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ENT.DepartamentoENT> ObtenerDepartamentos()
        {
            List<ENT.DepartamentoENT> departamentos = new List<ENT.DepartamentoENT>();
            try
            {
                DataSet dsetDepartamentos = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("SELECT * FROM departamento");
                foreach (DataRow fila in dsetDepartamentos.Tables[0].Rows)
                {
                    ENT.DepartamentoENT departamento = new ENT.DepartamentoENT();
                    departamento.Id = (int)fila["id"];
                    departamento.Nombre = fila["nombre"].ToString();
                    departamento.fechaCreacion = (DateTime)fila["fecha_creacion"];
                    departamento.creadoPor = fila["creado_por"].ToString();
                    departamento.fechaModificacion = (DateTime)fila["fecha_modificacion"];
                    departamento.modificadoPor = fila["modificado_por"].ToString();
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
