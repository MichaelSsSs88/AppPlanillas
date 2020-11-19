using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DAL
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

        public void ExportarDatos(DataGridView datalistado)
        {
            dlGuardar.Filter = "Fichero CSV (*.csv)|*.csv";
            dlGuardar.FileName = "Datos_sqlite";
            dlGuardar.Title = "Exportar a CSV";
            if (dlGuardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook = excel.Workbooks.Add();
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = xlWorkBook.Sheets[1];
                    excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
                    
                    int IndiceColumna = 0;
                    foreach (DataGridViewColumn columna in datalistado.Columns) //Aquí empezamos a leer las columnas del listado a exportar
                    {
                        IndiceColumna++;
                        if (columna.Visible == true)
                            xlWorkSheet.Cells[1, IndiceColumna] = columna.Name;
                        else
                            IndiceColumna--;
                    }
                    xlWorkSheet.Cells.RowHeight = 50;
                    xlWorkSheet.Cells.ColumnWidth = 10;
                    int IndiceFila = 0;
                   foreach (DataGridViewRow fila in datalistado.Rows) //Aquí leemos las filas de las columnas leídas
                    {
                        IndiceFila++;
                        IndiceColumna = 0;
                        
                        foreach (DataGridViewColumn columna in datalistado.Columns)
                        {
                            
                            IndiceColumna++;
                            if (columna.Name == "Foto")
                            {
                                //xlWorkSheet.Cells[IndiceFila + 1, IndiceColumna].with = "250";
                                //xlWorkSheet.Cells[IndiceFila + 1, IndiceColumna].x = "250";
                                if(IndiceFila==1)
                                        xlWorkSheet.Shapes.AddPicture(Application.StartupPath + @"\IMG\insertMedium.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 680, 50, 50, 50);
                                else
                                    xlWorkSheet.Shapes.AddPicture(Application.StartupPath + @"\IMG\insertMedium.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 680, (IndiceFila*50), 50, 50);
                                //var eapp = new Microsoft.Office.Interop.Excel.Application();

                                //xlWorkSheet.Shapes.AddPicture(Application.StartupPath + @"\IMG\insertMedium.png", MsoTriState.msoFalse, MsoTriState.msoCTrue, 50, 50, 50, 50).;

                                //excel.Cells[IndiceFila + 1, IndiceColumna] = (Image)fila.Cells[columna.Name].Value;
                                // Rango donde se intertará la imagen
                                //Microsoft.Office.Interop.Excel.Range r1;
                                //r1 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[IndiceFila + 1, IndiceColumna]
                                //r1.Select(); //Es necesario seleccinar un rango para poder insertar
                                // Console.WriteLine("Here");
                                // Objeto de todas las imagenes del excel
                                //Microsoft.Office.Interop.Excel.Pictures oPictures =
                                //(Microsoft.Office.Interop.Excel.Pictures)xlWorkSheet.Pictures(System.Reflection.Missing.Value);

                                //La ruta de la imagen donde esta la imagen a insertar,
                                //OJO es necesario indicar bien la ruta, de lo contrario marcará el siguiente error
                                //"Error en el método Insert de la clase Pictures" y pues eso despista ya que solo es
                                //la ruta y no la implementacion del método
                                //string pathTEMP_BMP = System.IO.Path.GetTempFileName();
                                // xlWorkSheet.im.Save(pathTEMP_BMP, System.Drawing.Imaging.ImageFormat.Bmp);

                                /* xlWorkSheet.Shapes.AddPicture(Application.StartupPath + @"\IMG\insertMedium.png",
                                 Microsoft.Office.Core.MsoTriState.msoFalse,
                                 Microsoft.Office.Core.MsoTriState.msoCTrue,
                                 float.Parse(r1.Left.ToString()), float.Parse(r1.Top.ToString()),
                                float.Parse(r1.Width.ToString()), float.Parse(r1.Height.ToString()));*/

                            }
                            if (columna.Visible==true && columna.Name!= "Foto")
                                xlWorkSheet.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                            else
                            {
                                IndiceColumna--;
                            }
                        }
                    }
                    excel.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("No hay Registros a Exportar.");
                }
            }
        }
    }
}
