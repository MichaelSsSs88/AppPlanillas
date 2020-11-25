using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    class MarcaENT
    {
        public int idMarca { get; }
        public DateTime? marcar_inicio { get;}
        public DateTime? marcar_final { get;}
        public string estado { get;}
        public int IdEmpleado { get;}
        public byte[] foto_inicio { get; }
        public byte[] foto_final { get;}
        public DateTime fechaCreacion { get;}
        public string creadoPor { get;}
        public DateTime fechaModificacion { get;}
        public string modificadoPor { get;}
        public List<MarcaENT> Marcas { get; set; }
        public int IdUnificacion { get; }
        public MarcaENT(int idMarca, DateTime? marcar_inicio, DateTime? marcar_final, string estado, int idEmpleado, byte[] foto_inicio, byte[] foto_final, DateTime fechaCreacion, string creadoPor, DateTime fechaModificacion, string modificadoPor, int idUnificacion)
        {
            this.marcar_inicio = marcar_inicio;
            this.marcar_final = marcar_final;
            this.estado = estado;
            IdEmpleado = idEmpleado;
            this.foto_inicio = foto_inicio;
            this.foto_final = foto_final;
            this.idMarca = idMarca;
            this.fechaCreacion = fechaCreacion;
            this.creadoPor = creadoPor;
            this.fechaModificacion = fechaModificacion;
            this.modificadoPor = modificadoPor;
            this.IdUnificacion = idUnificacion;
        }

        public MarcaENT()
        {
        }

       
    }
}
