using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    class Modelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Modelo()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            Nombre = string.Empty;
        }

        /// <summary>
        /// Busca en la tabla Modelo algun registro que su Id sea el mismo que el parametro y lo retorna.
        /// </summary>
        /// <param name="id">int Id Modelo</param>
        /// <returns>Marca marca</returns>
        public bool Read()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.ModeloVehiculo modelo = bbdd.ModeloVehiculo.Where(x => x.Id == this.Id).FirstOrDefault();
                if (modelo != null)
                {
                    CommonBC.Syncronize(modelo, this);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer modelo." + ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos los registros de la tabla Modelo.
        /// </summary>
        /// <returns>List<Modelo></returns>
        public List<Modelo> ReadAll()
        {
            BeLifeEntities bbdd = new BeLifeEntities();

            try
            {
                List<Entity.ModeloVehiculo> listaDatos = bbdd.ModeloVehiculo.ToList<Entity.ModeloVehiculo>();
                List<Modelo> list = SyncList(listaDatos);

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer las modelos. " + ex.Message);
            }
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<Modelo></returns>
        private List<Modelo> SyncList(List<Entity.ModeloVehiculo> listaDatos)
        {
            List<Modelo> list = new List<Modelo>();

            foreach (var x in listaDatos)
            {
                Modelo modelo = new Modelo();
                CommonBC.Syncronize(x, modelo);
                list.Add(modelo);
            }

            return list;
        }

    }
}
