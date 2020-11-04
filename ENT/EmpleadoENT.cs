using System;
using System.Collections.Generic;
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
        private int edad { get; set; }
        private int id_departamento { get; set; }
        private byte[] imagen { get; set; }
        public List<EmpleadoENT> empleados { get; set; }
        public EmpleadoENT(int pId, string pNombre, string pApellido_uno, string pApellido_dos, int pEdad, int pId_departamento, byte[] pImagen)
        {
            this.id = pId;
            this.nombre = pNombre;
            this.apellido_uno = pApellido_uno;
            this.apellido_dos = pApellido_dos;
            this.edad = pEdad;
            this.id_departamento = pId_departamento;
            this.imagen = pImagen;
        }

        public EmpleadoENT()
        {
            EmpleadoDAL empleado = new EmpleadoDAL();
            empleados = empleado.ObtenerEmpleados();
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

        public int Edad
        {
            get
            {
                return this.edad;
            }
        }

        public int Id_Departamento
        {
            get
            {
                return this.id_departamento;
            }
        }

        public byte[] Imagen
        {
            get
            {
                return this.imagen;
            }
        }
    }
}
