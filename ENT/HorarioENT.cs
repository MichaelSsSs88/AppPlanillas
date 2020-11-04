using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIIIC
{
    class HorarioENT
    {
        private int id { get; set; }
        private DateTime hora_inicio { get; set; }
        private DateTime hora_final { get; set; }
        private string descripcion { get; set; }
        private int horas_ordinarias { get; set; }
        public List<HorarioENT> horarios { get; set; }
        public HorarioENT(int pId, DateTime pHora_inicio, DateTime pHora_final, string pDescripcion, int pHoras_ordinarias)
        {
            this.id = pId;
            this.hora_inicio = pHora_inicio;
            this.hora_final = pHora_final;
            this.descripcion = pDescripcion;
            this.horas_ordinarias = pHoras_ordinarias;
        }

        public HorarioENT()
        {
            HorarioDAL horario = new HorarioDAL();
            horarios = horario.ObtenerHorarios();
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public DateTime Hora_Inicio
        {
            get
            {
                return this.hora_inicio;
            }
        }

        public DateTime Hora_Final
        {
            get
            {
                return this.hora_final;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
        }

        public int Horas_Ordinarias
        {
            get
            {
                return this.Horas_Ordinarias;
            }
        }
    }
}
