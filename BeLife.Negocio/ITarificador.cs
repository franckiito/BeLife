using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeLife.Negocio
{
    public interface ITarificador 
    {
        int CalcularEdad(DateTime birthDate, DateTime now);
        float CalcularRecargo(Plan primaPlan, Vehiculo vehi, Vivienda vivn);
        

        

        
    }

}
