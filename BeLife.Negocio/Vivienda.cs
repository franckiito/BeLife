using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class Vivienda
    {
        public int CodigoPostal { get; set; }
        public int Anho { get; set; }
        public string Direccion { get; set; }
        public double ValorInmueble { get; set; }
        public double ValorContenido { get; set; }

        public Region Region = new Region();
        public string NombreRegion
        {
            get { return Region.Nombre; }
        }

        public int IdRegion { get; set; }

        public Comuna Comuna = new Comuna();
        public string NombreComuna
        {
            get { return Comuna.Nombre; }
        }

        public int IdComuna { get; set; }

        public Vivienda()
        {
            this.Init();
        }

        private void Init()
        {
            CodigoPostal = 0;
            Anho = 0;
            Direccion = string.Empty;
            ValorInmueble = 0;
            ValorContenido = 0;

        }
    }
}
