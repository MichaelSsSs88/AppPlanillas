using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPlanillas.DAL;

namespace AppPlanillas.ENT
{
    class DepartamentoENT
    {
        private int id { get; set; }
        private string nombre { get; set; }
        private DateTime fechaCreacion { get; set; }
        private string creadoPor { get; set; }
        private DateTime fechaModificacion { get; set; } 
        private string modificadoPor { get; set; }
        private Boolean activo { get; set; }
        public List<DepartamentoENT> departamentos { get; }

        public DepartamentoENT () 
        {
            this.departamentos = new DepartamentoDAL().ObtenerDepartamentos(-1, "");
            //Prueba//
        }

        public DepartamentoENT (int pId, string pNombre, DateTime pFechaCreacion, string pCreadoPor, DateTime pFechaModificacion, string pModificadoPor, Boolean pActivo)
        {
            this.id = pId;
            this.nombre = pNombre;
            this.fechaCreacion = pFechaCreacion;
            this.creadoPor = pCreadoPor;
            this.fechaModificacion = pFechaModificacion;
            this.modificadoPor = pModificadoPor;
            this.activo = pActivo;
        }

        public int getId
        {
            get
            {
                return this.id;
            }
        }

        public string getNombre
        {
            get
            {
                return this.nombre;
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
