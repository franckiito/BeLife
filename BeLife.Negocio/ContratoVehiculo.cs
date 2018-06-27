using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class ContratoVehiculo
    {
        // Atributos 
        public Contrato Contrato { get; set; }
        public Vehiculo Vehiculo { get; set; }

        // Constructor
        public ContratoVehiculo()
        {
            this.Init();
        }

        // Metodo Inicializador
        private void Init()
        {
            Contrato = new Contrato();
            Vehiculo = new Vehiculo();
        }


    }
}
