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
        private DateTime fechaCreacion { get; set; }
        private string creadoPor { get; set; }
        private DateTime fechaModificacion { get; set; }
        private string modificadoPor { get; set; }
        private Boolean activo { get; set; }
        public List<Dia_feriadoENT> feriados { get; set; }
        public Dia_feriadoENT(int pId, DateTime pFecha, string pMotivo, DateTime pFechaCreacion, string pCreadoPor, DateTime pFechaModificacion, string pModificadoPor, Boolean pActivo)
        {
            this.id = pId;
            this.fecha = pFecha;
            this.motivo = pMotivo;
            this.fechaCreacion = pFechaCreacion;
            this.creadoPor = pCreadoPor;
            this.fechaModificacion = pFechaModificacion;
            this.modificadoPor = pModificadoPor;
            this.activo = pActivo;
        }

        public Dia_feriadoENT(string pFiltro, string pTexto)
        {
            Dia_feriadoDAL feriado = new Dia_feriadoDAL();
            feriados = feriado.ObtenerFeriados(pFiltro, pTexto);
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
