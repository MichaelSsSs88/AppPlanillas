using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIIIC
{
    class Dia_feriadoDAL
    {
        public List<Dia_feriadoENT> ObtenerFeriados()
        {
            List<Dia_feriadoENT> ListaFeriados = new List<Dia_feriadoENT>();
            try
            {
                DataSet dsetClientes = AccesoDatosPostgre.Instance.EjecutarConsultaSQL("select * from dia_feriado");
                foreach (DataRow fila in dsetClientes.Tables[0].Rows)
                {
                    Dia_feriadoENT feriado = new Dia_feriadoENT(Int32.Parse(fila["id"].ToString()), DateTime.Parse(fila["fecha"].ToString()),fila["motivo"].ToString());
                    ListaFeriados.Add(feriado);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ListaFeriados;
        }
    }
}
