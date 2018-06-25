using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    class Marca
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Marca()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            Nombre = string.Empty;
        }

        /// <summary>
        /// Busca en la tabla Marca algun registro que su Id sea el mismo que el parametro y lo retorna.
        /// </summary>
        /// <param name="id">int Id Marca</param>
        /// <returns>Marca marca</returns>
        public bool Read()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.MarcaVehiculo marca = bbdd.MarcaVehiculo.Where(x => x.Id == this.Id).FirstOrDefault();
                if (marca != null)
                {
                    CommonBC.Syncronize(marca, this);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer marca." + ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos los registros de la tabla Marca.
        /// </summary>
        /// <returns>List<Marca></returns>
        public List<Marca> ReadAll()
        {
            BeLifeEntities bbdd = new BeLifeEntities();

            try
            {
                List<Entity.MarcaVehiculo> listaDatos = bbdd.MarcaVehiculo.ToList<Entity.MarcaVehiculo>();
                List<Marca> list = SyncList(listaDatos);

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer las marca. " + ex.Message);
            }
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<Marca></returns>
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
