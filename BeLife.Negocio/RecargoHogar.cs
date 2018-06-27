using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class RecargoHogar : Cliente, ITarificador
    {
        public int CalcularEdad(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;
            return age;
        }

        public float CalcularRecargo(Plan primaPlan, Vehiculo vehi,  Vivienda vivn)
        {
            int edad = CalcularEdad(this.FechaNacimiento, DateTime.Now);
            float PrimaBase = 0;
            float Recargo = 0;

            //Pregunta por el año de contruccion para asignar valor de prima
            if (vivn.Anho == 2013)
            {
                Recargo = 1.0F;
                PrimaBase += primaPlan.PrimaBase + Recargo;
            }
            else if (vivn.Anho == 2008)
            {
                Recargo = 0.8F;
                PrimaBase += primaPlan.PrimaBase + Recargo;
            }
            else
            {
                Recargo = 0.2F;
                PrimaBase += primaPlan.PrimaBase + Recargo;
            }

            //pregunta por el sexo del cliente para asignar valor de prima// 1 hombre -  2 mujer
            if (vivn.Region.IdRegion == 13)
            {
                Recargo = 3.2F;
                PrimaBase += primaPlan.PrimaBase + Recargo;
            }
            else
            {
                Recargo = 2.8F;
                PrimaBase += primaPlan.PrimaBase + Recargo;
            }           

            return PrimaBase;
        }
    }
}
