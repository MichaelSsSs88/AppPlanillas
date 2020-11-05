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
        private string dia { get; set; }
        private int horas_ordinarias { get; set; }
        private string creadoPor { get; set; }
        private DateTime fechaCreacion { get; set; }
        private DateTime fechaModificacion { get; set; }
        private string modificadoPor { get; set; }
        private Boolean activo { get; set; }
        public List<HorarioENT> horarios { get; set; }

        public HorarioENT(int pId, DateTime pHora_inicio, DateTime pHora_final, string pDia, string pDescripcion, int pHoras_ordinarias, DateTime pFechaCreacion, string pCreadoPor, DateTime pFechaModificacion, string pModificadoPor, Boolean pActivo)
        {
            this.id = pId;
            this.hora_inicio = pHora_inicio;
            this.hora_final = pHora_final;
            this.descripcion = pDescripcion;
            this.dia = pDia;
            this.horas_ordinarias = pHoras_ordinarias;
            this.fechaCreacion = pFechaCreacion;
            this.creadoPor = pCreadoPor;
            this.fechaModificacion = pFechaModificacion;
            this.modificadoPor = pModificadoPor;
            this.activo = pActivo;
            
        }

        public HorarioENT()
        {
            HorarioDAL horario = new HorarioDAL();
            horarios = horario.ObtenerHorarios(-1,"");
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

        public string Dia
        {
            get
            {
                return this.dia;
            }
        }

        public int Horas_Ordinarias
        {
            get
            {
                return this.horas_ordinarias;
            }
        }

        public string getCreador
        {
            get
            {
                return this.creadoPor;
            }
        }

        public DateTime getFechaCreacion
        {
            get
            {
                return this.fechaCreacion;
            }
        }

        public string getModificador
        {
            get
            {
                return this.modificadoPor;
            }
        }

        public DateTime getFechaModificacion
        {
            get
            {
                return this.fechaModificacion;
            }
        }

        public Boolean getActivo
        {
            get
            {
                return this.activo;
            }
        }
    }
}
