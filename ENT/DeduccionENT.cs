﻿using System;
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
        private string nombre { get; set; }
        private double porcentaje { get; set; }
        private string sistema { get; set; }
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

        public DeduccionENT (int pId, string pNombre, double pPorcentaje, string pSistema, DateTime pFechaCreacion, string pCreadoPor, DateTime pFechaModificacion, string pModificadoPor, Boolean pActivo)
        {
            this.id = pId;
            this.nombre = pNombre;
            this.porcentaje = pPorcentaje;
            this.sistema = pSistema;
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

        public string getNombre
        {
            get
            {
                return this.nombre;
            }
        }

        public double getPorcentaje
        {
            get
            {
                return this.porcentaje;
            }
        }

        public string getSistema
        {
            get
            {
                return this.sistema;
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

    }
}
