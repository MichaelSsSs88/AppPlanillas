using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPlanillas.ENT
{
    class PuestoENT
    {
        private int id { get; set; }
        private string descripcion { get; set; }
        private int id_departamento { get; set; }
        private DateTime fecha_creacion { get; set; }
        private string creado_por { get; set; }
        private DateTime fecha_modificacion { get; set; }
        private string modificado_por { get; set; }
        private Boolean activo { get; set; }

        public List<PuestoENT> puestos { get; set; }

        public PuestoENT(int pId, string pDescripcion, int pId_departamento, DateTime pFecha_creacion, string pCreado_por, DateTime pFecha_modificacion, string pModificado_por, Boolean pActivo)
        {
            this.id = pId;
            this.descripcion = pDescripcion;
            this.id_departamento = pId_departamento;
            this.fecha_creacion = pFecha_creacion;
            this.creado_por = pCreado_por;
            this.fecha_modificacion = pFecha_modificacion;
            this.modificado_por = pModificado_por;
            this.activo = pActivo;
        }

        public PuestoENT(string pFiltro, string pTexto)
        {
            //Dia_feriadoDAL feriado = new Dia_feriadoDAL();
           // feriados = feriado.ObtenerFeriados(pFiltro, pTexto);
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
        }

        public int Id_departamento
        {
            get
            {
                return this.id_departamento;
            }
        }

        public DateTime Fecha_creacion
        {
            get
            {
                return this.fecha_creacion;
            }
        }

        public string Creado_por
        {
            get
            {
                return this.creado_por;
            }
        }

        public DateTime Fecha_modificacion
        {
            get
            {
                return this.fecha_modificacion;
            }
        }

        public string Modificado_por
        {
            get
            {
                return this.modificado_por;
            }
        }

        public Boolean Activo
        {
            get
            {
                return this.activo;
            }
        }

        
    }
}
