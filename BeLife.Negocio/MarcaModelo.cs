using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    class MarcaModelo
    {
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }

        public MarcaModelo()
        {
            this.Init();
        }

        private void Init()
        {
            Marca = new Marca();
            Modelo = new Modelo();
        }



    }
}
