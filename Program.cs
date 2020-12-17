using AppPlanillas.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPlanillas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new PanelPagos());
            try
            {
                int x = 0;
                try
                {
                    TimeSpan Horas1 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
                    TimeSpan Horas2 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
                    int Horas = Horas1.Hours - Horas2.Hours;
                    
                }
                catch
                {
                    x=1;
                    MessageBox.Show("Dirijase a panel de control->Reloj y region-> Configurar hora y fecha-> Cambiar fecha y hora-> Cambiar configuraion del calendario->Configuracion adicional-> Hora. Colocar en hora corta: HH:mm y en hora larga: HH:mm:ss", "Sistema de pagos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

                if (x ==1)
                {
                    Application.Exit();
                }
                else
                {
                    Application.Run(new Login());
                }
                
            }
            catch
            {
                MessageBox.Show("Corregir parametrizacion de base de datos en el archivo ini para poder ingresar", "Sistema de pagos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
            
        }
    }
}
