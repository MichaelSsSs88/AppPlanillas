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
        public List<HorarioENT> ObtenerHorarios()
        {
            List<HorarioENT> ListaHorarios = new List<HorarioENT>();
            try
            {
                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from horario");
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    HorarioENT horario = new HorarioENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["hora_inicio"].ToString()), DateTime.Parse(fila["hora_final"].ToString()), fila["descripcion"].ToString(), Int32.Parse(fila["horas_ordinarias"].ToString()));
                    ListaHorarios.Add(horario);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ListaHorarios;
        }
    }
}
