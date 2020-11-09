using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppPlanillas.DAL;

namespace AppPlanillas.ENT
{
    class DeduccionENT
    {
        private int id { get; set; }
        private string descripcion { get; set; }
        private string sistema { get; set; }
        private double valor { get; set; }
        private int idEmpleado { get; set; }
        private DateTime fechaCreacion { get; set; }
        private string creadoPor { get; set; }
        private DateTime fechaModificacion { get; set; }
        private string modificadoPor { get; set; }
        private Boolean activo { get; set; }

        private List<DeduccionENT> deducciones { get; }

        public DeduccionENT () 
        {
            this.deducciones = new DeduccionDAL().ObtenerDeducciones(-1, "");
        }

        public DeduccionENT (int pId, string pDescripcion, string pSistema, double pValor, int pIdEmpleado, DateTime pFechaCreacion, string pCreadoPor, DateTime pFechaModificacion, string pModificadoPor, Boolean pActivo)
        {
            this.id = pId;
            this.descripcion = pDescripcion;
            this.sistema = pSistema;
            this.valor = pValor;
            this.idEmpleado = pIdEmpleado;
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

        public string getDescripcion
        {
            get
            {
                return this.descripcion;
            }
        }

        public double getValor
        {
            get
            {
                return this.valor;
            }
        }

        public string getSistema
        {
            get
            {
                return this.sistema;
            }
        }

        public int getIdEmpleado
        {
            get
            {
                return this.idEmpleado;
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
