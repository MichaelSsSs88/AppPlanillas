using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIIIC
{
    class Dia_feriadoENT
    {
        private int id { get; set; }
        private DateTime fecha { get; set; }
        private string motivo { get; set; }
        public List<Dia_feriadoENT> feriados { get; set; }
        public Dia_feriadoENT(int pId, DateTime pFecha, string pMotivo)
        {
            this.id = pId;
            this.fecha = pFecha;
            this.motivo = pMotivo;
        }

        public Dia_feriadoENT()
        {
            Dia_feriadoDAL feriado = new Dia_feriadoDAL();
            feriados = feriado.ObtenerFeriados();
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
        }

        public string Motivo
        {
            get
            {
                return this.motivo;
            }
        }
    }
}
