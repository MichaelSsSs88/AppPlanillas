using AppPlanillas.DAL;
using AppPlanillas.ENT;
using DAL;
using ENT;
using ProyectoIIIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPlanillas.DLL
{
    class Unificacion
    {
        public List<UnificacionENT> Unificacione(IEnumerable<int> DiferentesEmpleados, DateTime fecha_inicio, DateTime fecha_fin, List<MarcaENT> marcas, string creador, string modificador)
        {
            List<DeduccionENT> Deducciones = new DeduccionDAL().ObtenerDeducciones(-1, "");
            List<HorarioENT> Horarios = new HorarioDAL().ObtenerHorarios(-1, "");
            List<Dia_feriadoENT> Feriados = new Dia_feriadoDAL().ObtenerFeriados("Todos", "");
            List<UnificacionENT> unificaciones = new List<UnificacionENT>();
            foreach (int cedula in DiferentesEmpleados)
            {
                int IdMarca=new MarcaDAL().ObtenerMarcas(cedula);
                
                if (IdMarca != -1)
                    new MarcaDAL().AnularMarca(IdMarca);

                double horas = 0;
                double horas_extras = 0;
                double horas_feriados = 0;
                double salario_horas = 0;
                double salario_horas_extras = 0;
                double salario_horas_feriados = 0;
                double total_deduccion = 0;

                foreach (MarcaENT marca in marcas)
                {


                    if (marca.IdEmpleado == cedula)
                    {
                        foreach (HorarioENT horario in Horarios)
                        {
                            if (this.DiaSemana(marca.marcar_inicio.Value.DayOfWeek).CompareTo(horario.Dia) == 0)
                            {
                                TimeSpan Horas1 = TimeSpan.Parse(marca.marcar_final.Value.ToString("HH:mm"));
                                TimeSpan Horas2 = TimeSpan.Parse(marca.marcar_inicio.Value.ToString("HH:mm"));
                                int Horas = Horas1.Hours - Horas2.Hours;
                                Console.WriteLine(Horas1 + " " + Horas2 + " Horas: " + Horas);
                                if (Horas >= horario.Horas_Ordinarias)
                                {
                                    horas += horario.Horas_Ordinarias;
                                    horas_extras += (Horas - horario.Horas_Ordinarias);
                                }
                                else
                                {
                                    horas += Horas;
                                }

                                foreach (Dia_feriadoENT feriado in Feriados)
                                {
                                    if (marca.marcar_inicio.Value.Month == feriado.Mes && marca.marcar_inicio.Value.Day == feriado.Dia)
                                    {
                                        horas_feriados += Horas;
                                    }
                                }

                                break;
                            }
                        }


                    }
                }

                double SalarioHora = new EmpleadoDAL().SalarioEmpleado(cedula);
                foreach (DeduccionENT rebajar in Deducciones)
                {
                    if (rebajar.getSistema.CompareTo("Porcentaje") == 0)
                    {
                        if (rebajar.getIdEmpleado == 0)
                            total_deduccion += ((horas * SalarioHora) + (horas_extras * (SalarioHora * 1.5)) + horas_feriados * SalarioHora) * (rebajar.getValor / 100);
                        else
                        {
                            if (rebajar.getIdEmpleado == cedula)
                            {
                                total_deduccion += ((horas * SalarioHora) + (horas_extras * (SalarioHora * 1.5)) + horas_feriados * SalarioHora) * (rebajar.getValor / 100);
                            }
                        }
                    }
                    else
                    {
                        if (rebajar.getIdEmpleado == 0)
                            total_deduccion += rebajar.getValor;
                        else
                        {
                            if (rebajar.getIdEmpleado == cedula)
                            {
                                total_deduccion += rebajar.getValor;
                            }
                        }
                    }
                }

                this.AgregarUnificacion(new UnificacionENT(1, fecha_inicio, fecha_fin, horas, horas_extras, horas_feriados, (horas * SalarioHora), (horas_extras * (SalarioHora * 1.5)), horas_feriados * SalarioHora, total_deduccion, cedula, "generado", DateTime.Now, creador, DateTime.Now, modificador, 0), marcas);

            }

            return new UnificacionDAL().ObtenerUnificacion("", "", 0,0,"") ;
        }

        private List<MarcaENT> VerificarMarcas(List<MarcaENT> Lista)
        {

            return Lista;
        }

        public void AgregarUnificacion(UnificacionENT punificacionENT, List<MarcaENT> marcas)
        {
            int numero = 0;
            try
            {
                AccesoDatosPostgre conexion = AccesoDatosPostgre.Instance;
                try
                {
                    conexion.IniciarTransaccion();
                    int unificacion = new UnificacionDAL().AgregarUnificacion(punificacionENT);
                    
                    foreach(MarcaENT marca in marcas)
                    {
                        
                        if (marca.IdEmpleado== punificacionENT.idEmpleado)
                        {
                            marca.modificadoPor = punificacionENT.modificadoPor;
                            marca.fechaModificacion = DateTime.Now;
                            marca.IdUnificacion = unificacion;
                            marca.estado = "aplicado";
                            new MarcaDAL().EditarMarcaDatosCompletos(marca);
                        }
                    }
                    conexion.CommitTransaccion();

                }
                catch (Exception e)
                {
                    conexion.RollbackTransaccion();
                    throw e;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UnificacionENT EditarUnificacion(UnificacionENT pUnificacionENT, MarcaENT marca)
        {
            List<HorarioENT> Horarios = new HorarioDAL().ObtenerHorarios(-1, "");
            List<Dia_feriadoENT> Feriados = new Dia_feriadoDAL().ObtenerFeriados("Todos", "");
            int horas = 0;
            int horas_extras = 0;
            int horas_feriados=0;
            foreach (HorarioENT horario in Horarios)
            {
                if (this.DiaSemana(marca.marcar_inicio.Value.DayOfWeek).CompareTo(horario.Dia) == 0)
                {
                    TimeSpan Horas1 = TimeSpan.Parse(marca.marcar_final.Value.ToString("HH:mm"));
                    TimeSpan Horas2 = TimeSpan.Parse(marca.marcar_inicio.Value.ToString("HH:mm"));
                    int Horas = Horas1.Hours - Horas2.Hours;
                    Console.WriteLine(Horas1 + " " + Horas2 + " Horas: " + Horas);
                    if (Horas >= horario.Horas_Ordinarias)
                    {
                        horas += horario.Horas_Ordinarias;
                        horas_extras += (Horas - horario.Horas_Ordinarias);
                    }
                    else
                    {
                        horas += Horas;
                    }

                    foreach (Dia_feriadoENT feriado in Feriados)
                    {
                        if (marca.marcar_inicio.Value.Month == feriado.Mes && marca.marcar_inicio.Value.Day == feriado.Dia)
                        {
                            horas_feriados += Horas;
                        }
                    }

                    break;
                }
            }
            return pUnificacionENT;
        }


            private string DiaSemana(DayOfWeek dow)
        {
            switch (dow)
            {
                case (DayOfWeek.Monday):
                    return "Lunes";
                case (DayOfWeek.Tuesday):
                    return "Martes";
                case (DayOfWeek.Wednesday):
                    return "Miercoles";
                case (DayOfWeek.Thursday):
                    return "Jueves";
                case (DayOfWeek.Friday):
                    return "Viernes";
                case (DayOfWeek.Saturday):
                    return "Sábado";
                case (DayOfWeek.Sunday):
                    return "Domingo";
            }
            return "";
        }
    }
}
