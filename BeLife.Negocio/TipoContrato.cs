using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class TipoContrato
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoContrato()
        {
            this.Init();
        }

        private void Init()
        {
            Id = 0;
            Descripcion = string.Empty;
        }

        /// <summary>
        /// Busca en la tabla TipoContrato algun registro que su Id sea el mismo que el parametro y lo retorna.
        /// </summary>
        /// <param name="id">int Id TipoContrato</param>
        /// <returns>bool</returns>
        public bool Read()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.TipoContrato tipoContrato = bbdd.TipoContrato.Where(x => x.Id == this.Id).FirstOrDefault();
                if (tipoContrato != null)
                {
                    CommonBC.Syncronize(tipoContrato, this);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer tipo de contrato." + ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos los registros de la tabla TipoContrato.
        /// </summary>
        /// <returns>List<TipoContrato></returns>
        public List<TipoContrato> ReadAll()
        {
            BeLifeEntities bbdd = new BeLifeEntities();

            try
            {
                List<Entity.TipoContrato> listaDatos = bbdd.TipoContrato.ToList<Entity.TipoContrato>();
                List<TipoContrato> list = SyncList(listaDatos);

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer las Tipo de Contrato. " + ex.Message);
            }
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<TipoContrato></returns>
        private List<TipoContrato> SyncList(List<Entity.TipoContrato> listaDatos)
        {
            List<TipoContrato> list = new List<TipoContrato>();

            foreach (var x in listaDatos)
            {
                TipoContrato tipoContrato = new TipoContrato();
                CommonBC.Syncronize(x, tipoContrato);
                list.Add(tipoContrato);
            }

            return list;
        }

    }
}
