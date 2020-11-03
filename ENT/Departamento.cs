using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPlanillas.ENT
{
    class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string creadoPor { get; set; }
        public DateTime fechaModificacion { get; set; } 
        public string modificadoPor { get; set; }
        public Boolean activo { get; set; }

        public Departamento () { }

        public Departamento (int pId, string pNombre, DateTime pFechaCreacion, string pCreadoPor, DateTime pFechaModificacion, string pModificadoPor, Boolean pActivo)
        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.fechaCreacion = pFechaCreacion;
            this.creadoPor = pCreadoPor;
            this.fechaModificacion = pFechaModificacion;
            this.modificadoPor = pModificadoPor;
            this.activo = pActivo;
        }

    }
}
