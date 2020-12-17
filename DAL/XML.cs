using AppPlanillas.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPlanillas.DAL
{
    public static class XML
    {
        public static DataSet GetDataSet(DataGridView dgv)
        {
            var ds = new DataSet();
          
            var dt = new DataTable();
            var dt2 = new DataTable();
            ds.DataSetName = "?xml version=”1.0”?";
            //dt2.TableName = "Sinpe";

           // ds.Tables.Add(dt2);
           
            dt.TableName = "Empleado";
            foreach (var column in dgv.Columns.Cast<DataGridViewColumn>())
            {
                //if (column.Visible)
                //{ 
                    
                    dt.Columns.Add();
                //}
            }
            dt.Columns[0].ColumnName = "Cedula";
            dt.Columns[1].ColumnName = "Nombre";
            dt.Columns[2].ColumnName = "Monto";

            var cellValues = new object[dgv.Columns.Count];
            foreach (var row in dgv.Rows.Cast<DataGridViewRow>())
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }
            //dt2.Columns.Add(dt.Rows);
            ds.Tables.Add(dt);
            return ds;
        }
    }
}
