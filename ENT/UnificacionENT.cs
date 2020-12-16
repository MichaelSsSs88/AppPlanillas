using ProyectoIIIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{

    public class UnificacionENT
    {
        public int idUnificacion { get; }
        public DateTime fecha_inicio { get; }
        public DateTime fecha_fin { get; }
        public double hora_regular { get; }
        public double hora_extra { get; }
        public double hora_doble { get; }
        public double total_regular { get; }
        public double total_extra { get; }
        public double total_doble { get; }
        public double total_deduccion { get; }
        public int idEmpleado { get; }
        public string estado { get; set; }
        public DateTime fechaCreacion { get; }
        public string creadoPor { get; }
        public DateTime fechaModificacion { get; set; }
        public string modificadoPor { get; set; }
        public List<MarcaENT> Marcas { get; set; }
        public int? IdPago { get; set; }

        public UnificacionENT(int idUnificacion, DateTime fecha_inicio, DateTime fecha_fin, double hora_regular, double hora_extra, double hora_doble, double total_regular, double total_extra, double total_doble, double total_deduccion, int idEmpleado, string estado, DateTime fechaCreacion, string creadoPor, DateTime fechaModificacion, string modificadoPor, int? idPago)
        {
            this.idUnificacion = idUnificacion;
            this.fecha_inicio = fecha_inicio;
            this.fecha_fin = fecha_fin;
            this.hora_regular = hora_regular;
            this.hora_extra = hora_extra;
            this.hora_doble = hora_doble;
            this.total_regular = total_regular;
            this.total_extra = total_extra;
            this.total_doble = total_doble;
            this.total_deduccion = total_deduccion;
            this.idEmpleado = idEmpleado;
            this.estado = estado;
            this.fechaCreacion = fechaCreacion;
            this.creadoPor = creadoPor;
            this.fechaModificacion = fechaModificacion;
            this.modificadoPor = modificadoPor;
            this.IdPago = idPago;
        }

        public String Nombre
        {
            get
            {
                return new EmpleadoDAL().ObtenerEmpleado(this.idEmpleado);
            }
        }
    }
}
