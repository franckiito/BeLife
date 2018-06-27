using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class RecargoVida : Cliente, ITarificador
    {
        public int CalcularEdad(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;
            return age;
        }


        public float CalcularRecargo(Plan primaPlan, Vehiculo vehi, Vivienda vivn)
        {
            try
            {
                int edad = CalcularEdad(this.FechaNacimiento, DateTime.Now);
                float PrimaBase = 0;
                float Recargo = 0;

                //Pregunta por el rango de edad del cliente para asignar valor de prima
                if (edad > 18 && edad < 25)
                {
                    Recargo = 3.6F;
                    PrimaBase += primaPlan.PrimaBase + Recargo;
                }
                else if (edad > 26 && edad < 45)
                {
                    Recargo = 2.4F;
                    PrimaBase += primaPlan.PrimaBase + Recargo;
                }
                else
                {
                    Recargo = 6F;
                    PrimaBase += primaPlan.PrimaBase + Recargo;
                }

                //pregunta por el sexo del cliente para asignar valor de prima// 1 hombre -  2 mujer
                if (this.Sexo.Id == 1)
                {
                    Recargo = 2.4F;
                    PrimaBase += primaPlan.PrimaBase + Recargo;
                }
                else
                {
                    Recargo = 1.2F;
                    PrimaBase += primaPlan.PrimaBase + Recargo;
                }

                /*pregunta por el estado civil del cliente para asignar valor de prima
                1 Soltero, 2 Casado y otros*/

                if (EstadoCivil.Id == 1)
                {
                    Recargo = 4.8F;
                    PrimaBase += primaPlan.PrimaBase + Recargo;
                }
                else if (EstadoCivil.Id == 2)
                {
                    Recargo = 2.4F;
                    PrimaBase += primaPlan.PrimaBase + Recargo;
                }
                else
                {
                    Recargo = 3.6F;
                    PrimaBase += primaPlan.PrimaBase + Recargo;
                }

                return PrimaBase;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }
    }

}
