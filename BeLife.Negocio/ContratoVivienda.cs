using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class ContratoVivienda
    {
        // Atributos
        public Contrato Contrato { get; set; }
        public Vivienda Vivienda { get; set; }

        // Constructor
        public ContratoVivienda()
        {
            this.Init();
        }

        // Metodo Inicializador
        private void Init()
        {
            Contrato = new Contrato();
            Vivienda = new Vivienda();
        }

    }

}
