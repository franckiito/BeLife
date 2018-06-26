using BeLife.Entity;
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

        /// <summary>
        /// Retorna todos los registros de la tabla MarcaModelo.
        /// </summary>
        /// <returns>List<Marca></returns>
        //public List<MarcaModeloVehiculo> ReadAll()
        //{
        //    BeLifeEntities bbdd = new BeLifeEntities();

        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al leer las marca. " + ex.Message);
        //    }
        //}

        private List<Marca> SyncList(List<Entity.MarcaVehiculo> listaDatos)
        {
            List<Marca> list = new List<Marca>();

            foreach (var x in listaDatos)
            {
                Marca marca = new Marca();
                CommonBC.Syncronize(x, marca);
                list.Add(marca);
            }

            return list;
        }
    }
}
