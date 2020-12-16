using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    class PagoENT
    {
        public int idPago { get; }
        public DateTime fecha_inicio { get; }
        public DateTime fecha_fin { get; }

        public string descripcion { get; }
        public double total { get; set; }
        public DateTime fechaCreacion { get; }
        public string creadoPor { get; }
        public DateTime fechaModificacion { get; set; }
        public string modificadoPor { get; set; }
        public PagoENT(int idPago, DateTime fecha_inicio, DateTime fecha_fin, string descripcion, double total, DateTime fechaCreacion, string creadoPor, DateTime fechaModificacion, string modificadoPor)
        {
            this.idPago = idPago;
            this.fecha_inicio = fecha_inicio;
            this.fecha_fin = fecha_fin;
            this.descripcion = descripcion;
            this.total = total;
            this.fechaCreacion = fechaCreacion;
            this.creadoPor = creadoPor;
            this.fechaModificacion = fechaModificacion;
            this.modificadoPor = modificadoPor;
        }


    }
}
