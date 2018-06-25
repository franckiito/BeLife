using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class Region
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Region()
        {
            this.Init();
        }

        /// <summary>
        /// Inicializador
        /// </summary>
        private void Init()
        {
            Id = 0;
            Nombre = string.Empty;
        }

        /// <summary>
        /// Busca en la tabla Comuna algun registro que su Id sea el mismo que el parametro y lo retorna.
        /// </summary>
        /// <param name="id">int Id Comuna</param>
        /// <returns>Region region</returns>
        public bool Read()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.Region region = bbdd.Region.Where(x => x.Id == this.Id).FirstOrDefault();
                if (region != null)
                {
                    CommonBC.Syncronize(region, this);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer region." + ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos los registros de la tabla Region.
        /// </summary>
        /// <returns>List<Region></returns>
        public List<Region> ReadAll()
        {
            BeLifeEntities bbdd = new BeLifeEntities();

            try
            {
                List<Entity.Region> listaDatos = bbdd.Region.ToList<Entity.Region>();
                List<Region> list = SyncList(listaDatos);

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer las comunas. " + ex.Message);
            }
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<Region></returns>
        private List<Region> SyncList(List<Entity.Region> listaDatos)
        {
            List<Region> list = new List<Region>();

            foreach (var x in listaDatos)
            {
                Region region = new Region();
                CommonBC.Syncronize(x, region);
                list.Add(region);
            }

            return list;
        }
    }
}
