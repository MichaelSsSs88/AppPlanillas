using System;
using System.Collections.Generic;
using System.Text;
using System.Data; // manejo de datos
using System.Data.OleDb;
using System.Xml;
using Npgsql;//Para controlar la conexion a base de datos con postgresql
using NpgsqlTypes;

namespace DAL
{
    public class AccesoDatosPostgre
    {                        
        public NpgsqlConnection conexion;       //Objeto de tipo conexion, para establecer comunicacion con la BD
        private NpgsqlTransaction transaccion;  //Objeto de tipo transaccion de base de datos, para iniciar, procesar y cerrar transacciones
        private bool hayTransaccion;            //Bandera que determina si hay una transaccion activa
        private string schema;                  //Almacena el esquema con el cual se trabaja en la base de datos, para devolverlo mediante un metodo get        
        private static AccesoDatosPostgre instance;

        public static AccesoDatosPostgre Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new AccesoDatosPostgre();
                }
                return instance;
            }
        }

        public DataSet CargarIni()
        {
            DataSet dsetConf = new DataSet();
            try
            {
                string ArchivoXML = System.Environment.CurrentDirectory +"\\INI.xml";
                System.IO.FileStream fsReadXml = new System.IO.FileStream(ArchivoXML, System.IO.FileMode.Open);
                dsetConf.ReadXml(fsReadXml);
            }
            catch (Exception e)
            {
                throw e;
            }
            return dsetConf;
        }


        // Constructor
        private AccesoDatosPostgre()
        {
            //DataSet parametros = this.cargarIni();
            //DataTable tabla = parametros.Tables[0];
            //DataRow fila = tabla.Rows[0];

            DataRow fila = this.CargarIni().Tables[0].Rows[0];
            
            conexion = new NpgsqlConnection("Encoding = UNICODE; Server=" + fila["Server"].ToString() + 
                                            ";Port = " + fila["Port"].ToString() + 
                                            ";User Id=" + fila["Usuario"].ToString() + 
                                            ";Password=" + fila["Password"].ToString() + 
                                            ";Database=" + fila["Database"].ToString() + 
                                            ";CommandTimeout=3600;");
            try
            {
                conexion.Open();
                this.schema = fila["Schema"].ToString();
            }
            catch (NpgsqlException error)
            {
                throw error;
            }
        }
        
        // Indica el estado de la persistencia
        public  string Estado()
        {
            String mensaje = "";

            // estado dela conexi�n
            switch (conexion.State)
            {
                case System.Data.ConnectionState.Broken:
                    mensaje = "La conexi�n con la base de datos fue interrumpida.";
                    break;
                case System.Data.ConnectionState.Closed:
                    mensaje = "La conexi�n con la base de datos fue cerrada o no pudo ser establecida.";
                    break;
                case System.Data.ConnectionState.Connecting:
                    mensaje = "Conectandose.";
                    break;
                case System.Data.ConnectionState.Executing:
                    mensaje = "Ejecutando.";
                    break;
                case System.Data.ConnectionState.Fetching:
                    mensaje = "Extrayendo.";
                    break;
                case System.Data.ConnectionState.Open:
                    mensaje = "Abierta.";
                    break;
            }

            return mensaje;
        }

        // destructor
        ~AccesoDatosPostgre()
        {           
        }
        
        public void Desconectar()
        {
            try
            {
                conexion.Close();
            }
            catch (NpgsqlException error)
            {
                throw error;
            }
        }

        //Manipulacion de select
        public  DataSet EjecutarConsultaSQL(String pSql)
        {            
            NpgsqlDataAdapter oDataAdapter = new NpgsqlDataAdapter(pSql, conexion);
            DataSet oDataSet = new DataSet();

            // capturar la excepci�n
            try
            {
                oDataAdapter.Fill(oDataSet);
            }
            catch (NpgsqlException error)
            {
                throw error;
            }

            return oDataSet;
        }
        
        public  DataSet EjecutarConsultaSQL(String pSql, NpgsqlParameter[] myParamArray)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(pSql, conexion);

            cmd.CommandType = CommandType.Text;

            for (int j = 0; j < myParamArray.Length; j++)
            {
                cmd.Parameters.Add(myParamArray[j]);
            }

            NpgsqlDataAdapter oDataAdapter = new NpgsqlDataAdapter(cmd);
            DataSet oDataSet = new DataSet();

            // capturar la excepci�n
            try
            {
                oDataAdapter.Fill(oDataSet, "tabla");
            }
            catch (NpgsqlException error)
            {
                throw error;
            }

            return oDataSet;
        }
        
        // M�todo para manipular Insert, Update, Delete
        public  void EjecutarSQL(String pSql)
        {
            // Definicion de Command
            NpgsqlCommand cmd = null;

            try
            {
                cmd = new NpgsqlCommand(pSql, conexion);

                if (this.hayTransaccion)
                {
                    cmd.Transaction = this.transaccion;
                }

                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException error)
            {
                throw error;
            }

        }
        
        // M�todo para manipular Insert, Update, Delete con identidad
        public  void EjecutarSQL(string pSql, NpgsqlParameter[] myParamArray, ref string pNumero)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(pSql, conexion);
                cmd.CommandType = CommandType.Text;
                for (int j = 0; j < myParamArray.Length; j++)
                {
                    cmd.Parameters.Add(myParamArray[j]);
                }

                if (this.hayTransaccion)
                {
                    cmd.Transaction = this.transaccion;
                }
                
                pNumero = "";
                pNumero = cmd.ExecuteScalar().ToString();            
            }
            catch (NpgsqlException error)
            {
                throw error;
            }
        }

        //M�todo para manipular Insert, Update pero con parametros
        public  void EjecutarSQL(string sql, NpgsqlParameter[] myParamArray)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexion);
                cmd.CommandType = CommandType.Text;
                for (int j = 0; j < myParamArray.Length; j++)
                {
                    cmd.Parameters.Add(myParamArray[j]);
                }

                if (this.hayTransaccion)
                {
                    cmd.Transaction = this.transaccion;
                }

                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException error)
            {
                throw error;
            }
        }
        
        //Metodos de transaccion
        public  void IniciarTransaccion()
        {
            try
            {
                if (this.hayTransaccion == false)
                {
                    this.transaccion = this.conexion.BeginTransaction();
                    this.hayTransaccion = true;
                }
            }catch(Exception error)
            {
                throw error;
            }
        }
        
        public  void CommitTransaccion()
        {
            try
            {
                if (this.hayTransaccion)
                {
                    this.transaccion.Commit();
                    this.hayTransaccion = false;
                }
            }catch(Exception error)
            {
                throw error;
            }
        }
        
        public  void RollbackTransaccion()
        {
            try
            {
                if (this.hayTransaccion)
                {
                    this.transaccion.Rollback();
                    this.hayTransaccion = false;
                }
            }catch(Exception error)
            {
                throw error;
            }
        }
                               
        public  string Schema
        {
            get { return this.schema; }
        }            
    }//Finaliza la clase
}//Finaliza el namespace

