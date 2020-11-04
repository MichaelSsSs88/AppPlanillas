using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIIIC
{
    class UsuarioENT
    {
        private int id { get; set; }
        private string nombre { get; set; }
        private string correo { get; set; }
        private string tipo { get; set; }
        private string contrasena { get; set; }
        public List<UsuarioENT> usuarios { get; set; }
        public UsuarioENT(int pId, string pNombre, string pCorreo, string pTipo, string pContrasena)
        {
            this.id = pId;
            this.nombre = pNombre;
            this.correo = pCorreo;
            this.tipo = pTipo;
            this.contrasena = pContrasena;
        }

        public UsuarioENT()
        {
            UsuarioDAL usuario = new UsuarioDAL();
            usuarios = usuario.ObtenerUsuarios();
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

        public string Correo
        {
            get
            {
                return this.correo;
            }
        }

        public string Tipo
        {
            get
            {
                return this.tipo;
            }
        }

        public string Contrasena
        {
            get
            {
                return this.contrasena;
            }
        }
    }
}
