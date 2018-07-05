using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class MarcaModelo
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

        /// <summary>
        /// Busca los modelos asociados a una Marca.
        /// </summary>
        /// <returns>List<Modelo></returns>
        public List<Modelo> ReadModelosMarca()
        {
            List<Modelo> modelos = new List<Modelo>();

            BeLifeEntities bbdd = new BeLifeEntities();

            try
            {
                var modeloVehiculos = bbdd.MarcaModeloVehiculo.Where(x => x.IdMarca == Marca.Id);
                foreach (var models in modeloVehiculos)
                {
                    Modelo modelo = new Modelo
                    {
                        Id = models.IdModelo
                    };
                    modelo.Read();
                    modelos.Add(modelo);
                }
                return modelos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar los modelos de la marca. " + ex.Message);
            }
        }
        
        
    }
}
