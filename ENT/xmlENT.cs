using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPlanillas.ENT
{
    class xmlENT
    {
        public xmlENT(int cedula, string nombre, double monto)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.monto = monto;
        }

        public int cedula { get; set; }
        public string nombre { get; set; }
        public double monto { get; set; }
    }
}
