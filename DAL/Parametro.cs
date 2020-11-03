using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;

namespace DAL
{
    public class Parametro
    {
        private List<NpgsqlParameter> parametros;

        public Parametro() 
        {
            this.parametros = new List<NpgsqlParameter>();
        }

        public void AgregarParametro(string nombre, NpgsqlDbType tipo, Object valor)
        {
            NpgsqlParameter oParametro = new NpgsqlParameter();
            oParametro.ParameterName = nombre;
            oParametro.NpgsqlDbType = tipo;
            oParametro.NpgsqlValue = valor;

            this.parametros.Add(oParametro);
        }

        public NpgsqlParameter[] ObtenerParametros()
        {
            NpgsqlParameter[] array = new NpgsqlParameter[this.parametros.Count];

            for (int i = 0; i < this.parametros.Count; i++) 
            {
                array[i] = this.parametros[i];
            }


            return array; //this.parametros.ToArray();
        }
    }
}
