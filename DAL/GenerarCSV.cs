using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appFlotillaCombustible.DAL
{
    class GenerarCSV
    {
        SaveFileDialog dlGuardar;
        DataGridView dbTabla;

        public GenerarCSV(DataGridView dbTabla)
        {
            this.dbTabla = dbTabla;
            this.dlGuardar = new SaveFileDialog();
        }

        public void guardar()
        {
            dlGuardar.Filter = "Fichero CSV (*.csv)|*.csv";
            dlGuardar.FileName = "Datos_sqlite";
            dlGuardar.Title = "Exportar a CSV";
            if (dlGuardar.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csvMemoria = new StringBuilder();

                //para los títulos de las columnas, encabezado
                for (int i = 0; i < dbTabla.Columns.Count; i++)
                {
                    if (i == dbTabla.Columns.Count - 1)
                    {
                        if (dbTabla.Columns[i].Visible == true)
                        {
                            csvMemoria.Append(String.Format("\"{0}\"",
                            dbTabla.Columns[i].HeaderText));
                        }
                    }
                    else
                    {
                        if (dbTabla.Columns[i].Visible == true)
                        {
                            csvMemoria.Append(String.Format("\"{0}\";",
                            dbTabla.Columns[i].HeaderText));
                        }
                            
                    }
                }
                csvMemoria.AppendLine();


                for (int m = 0; m < dbTabla.Rows.Count; m++)
                {
                    for (int n = 0; n < dbTabla.Columns.Count; n++)
                    {
                        //si es la última columna no poner el ;
                        if (n == dbTabla.Columns.Count - 1)
                        {
                            if (dbTabla.Columns[n].Visible == true)
                            {
                                csvMemoria.Append(String.Format("\"{0}\"",
                                 dbTabla.Rows[m].Cells[n].Value));
                            }
                        }
                        else
                        {
                            if (dbTabla.Columns[n].Visible == true)
                            {
                                csvMemoria.Append(String.Format("\"{0}\";",
                                dbTabla.Rows[m].Cells[n].Value));
                            }
                        }
                    }
                    csvMemoria.AppendLine();
                }
                System.IO.StreamWriter sw =
                    new System.IO.StreamWriter(dlGuardar.FileName, false,
                       System.Text.Encoding.Default);
                sw.Write(csvMemoria.ToString());
                sw.Close();
            }
        }
    }
}
