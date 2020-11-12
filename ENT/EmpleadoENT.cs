using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIIIC
{
    class EmpleadoENT
    {
        private int id { get; set; }
        private string nombre { get; set; }
        private string apellido_uno { get; set; }
        private string apellido_dos { get; set; }
        private DateTime FechaNacimiento { get; set; }
        private int id_puesto { get; set; }

        private double salario_hora { get; set; }
        private byte[] imagen { get; set; }

        private DateTime fechaCreacion { get; set; }
        private string creadoPor { get; set; }
        private DateTime fechaModificacion { get; set; }
        private string modificadoPor { get; set; }
        private Boolean activo { get; set; }
        public List<EmpleadoENT> empleados { get; set; }

        public EmpleadoENT(int pId, string pNombre, string pApellido_uno, string pApellido_dos, DateTime FechaNacimiento, int pId_puesto, byte[] pImagen, double salario_hora, DateTime fechaCreacion, string creadoPor, DateTime fechaModificacion, string modificadoPor, bool activo)
        {
            this.id = pId;
            this.nombre = pNombre;
            this.apellido_uno = pApellido_uno;
            this.apellido_dos = pApellido_dos;
            this.FechaNacimiento = FechaNacimiento;
            this.id_puesto = pId_puesto;
            this.imagen = pImagen;
            this.salario_hora = salario_hora;
            this.creadoPor = creadoPor;
            this.fechaModificacion = fechaModificacion;
            this.modificadoPor = modificadoPor;
            this.fechaCreacion = fechaCreacion;
            this.activo = activo;
        }

        public EmpleadoENT()
        {
            EmpleadoDAL empleado = new EmpleadoDAL();
            empleados = empleado.ObtenerEmpleados("Todos","");
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public string Apellido_Uno
        {
            get
            {
                return this.apellido_uno;
            }
        }

        public string Apellido_Dos
        {
            get
            {
                return this.apellido_dos;
            }
        }

        public DateTime fechaNacimiento
        {
            get
            {
                return this.FechaNacimiento;
            }
        }

        public int Id_Puesto
        {
            get
            {
                return this.id_puesto;
            }
        }

        public double Salario_Hora
        {
            get
            {
                return this.salario_hora;
            }
        }

        public byte[] Imagen
        {
            get
            {
                return this.imagen;
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

        public Image getImagen
        {
            get
            {
                Image returnImage = null;
                try
                {
                    MemoryStream ms = new MemoryStream(this.imagen, 0, this.imagen.Length);
                    ms.Write(this.imagen, 0, this.imagen.Length);
                    returnImage = Image.FromStream(ms, true);
                }
                catch { }
                return returnImage;
            }
        }
    }
}
