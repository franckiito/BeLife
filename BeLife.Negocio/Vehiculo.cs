﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class Vehiculo
    {
        public string Patente { get; set; }
        public int IdMarca { get; set; }
        public int IdModelo { get; set; }
        public int Anho { get; set; }

        public Vehiculo()
        {
            this.Init();
        }

        private void Init()
        {
            throw new NotImplementedException();
        }
    }
}
