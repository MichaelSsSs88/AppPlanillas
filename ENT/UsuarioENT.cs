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
        private DateTime fechaCreacion { get; set; }
        private string creadoPor { get; set; }
        private DateTime fechaModificacion { get; set; }
        private string modificadoPor { get; set; }
        private Boolean activo { get; set; }
        public List<UsuarioENT> usuarios { get; set; }
        public UsuarioENT(int pId, string pNombre, string pCorreo, string pTipo, string pContrasena, DateTime pFechaCreacion, string pCreadoPor, DateTime pFechaModificacion, string pModificadoPor, Boolean pActivo)
        {
            this.id = pId;
            this.nombre = pNombre;
            this.correo = pCorreo;
            this.tipo = pTipo;
            this.contrasena = pContrasena;
            this.fechaCreacion = pFechaCreacion;
            this.creadoPor = pCreadoPor;
            this.fechaModificacion = pFechaModificacion;
            this.modificadoPor = pModificadoPor;
            this.activo = pActivo;
        }

        public UsuarioENT(string pFiltro, string pTexto)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            usuarios = usuario.ObtenerUsuarios(pFiltro, pTexto);
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
