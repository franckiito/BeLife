using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class RegionComuna
    {
        public Region Region { get; set; }
        public Comuna Comuna { get; set; }

        public RegionComuna()
        {
            this.Init();
        }

        private void Init()
        {
            Region = new Region();
            Comuna = new Comuna();
        }

        /// <summary>
        /// Busca los modelos asociados a una Marca.
        /// </summary>
        /// <returns>List<Modelo></returns>
        public List<Comuna> ReadComunasRegion()
        {
            List<Comuna> comunas = new List<Comuna>();

            BeLifeEntities bbdd = new BeLifeEntities();

            try
            {
                var regionComunas = bbdd.RegionComuna.Where(x => x.IdRegion == Region.Id);
                foreach (var comuns in regionComunas)
                {
                    Comuna comuna = new Comuna
                    {
                        Id = comuns.IdComuna
                    };
                    comuna.Read();
                    comunas.Add(comuna);
                }
                return comunas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar las comuna de la region. " + ex.Message);
            }
        }
    }
}
