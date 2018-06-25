using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    class Comuna
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Comuna()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            Nombre = string.Empty;
        }

        /// <summary>
        /// Busca en la tabla Comuna algun registro que su Id sea el mismo que el parametro y lo retorna.
        /// </summary>
        /// <param name="id">int Id Comuna</param>
        /// <returns>Comuna comuna</returns>
        public bool Read()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.Comuna comuna = bbdd.Comuna.Where(x => x.Id == this.Id).FirstOrDefault();
                if (comuna != null)
                {
                    CommonBC.Syncronize(comuna, this);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer comuna." + ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos los registros de la tabla Comuna.
        /// </summary>
        /// <returns>List<Comuna></returns>
        public List<Comuna> ReadAll()
        {
            BeLifeEntities bbdd = new BeLifeEntities();

            try
            {
                List<Entity.Comuna> listaDatos = bbdd.Comuna.ToList<Entity.Comuna>();
                List<Comuna> list = SyncList(listaDatos);

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
        /// <returns>List<Comuna></returns>
        private List<Comuna> SyncList(List<Entity.Comuna> listaDatos)
        {
            List<Comuna> list = new List<Comuna>();

            foreach (var x in listaDatos)
            {
                Comuna comuna = new Comuna();
                CommonBC.Syncronize(x, comuna);
                list.Add(comuna);
            }

            return list;
        }

    }
}
