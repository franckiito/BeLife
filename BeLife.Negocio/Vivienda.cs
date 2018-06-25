using BeLife.Entity;
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

        //public Region Region = new Region();
        //public string NombreRegion
        //{
        //    get { return Region.Nombre; }
        //}

        //public int IdRegion { get; set; }

        //public Comuna Comuna = new Comuna();
        //public string NombreComuna
        //{
        //    get { return Comuna.Nombre; }
        //}

        //public int IdComuna { get; set; }

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

        /// <summary>
        /// Crea un registro de Vivienda en la BBDD
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            bool crea = false;

            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                Entity.Vivienda vivienda = new Entity.Vivienda();

                //Ve si no existe el Vivienda para poder crearlo.
                if (!this.Read())
                {
                    //Sincroniza datos 
                    CommonBC.Syncronize(this, vivienda);

                    //Guarda los cambios
                    bbdd.Vivienda.Add(vivienda);
                    bbdd.SaveChanges();
                    crea = true;
                }
                else
                {
                    throw new Exception("El vivienda ya existe.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Crear Vivienda. " + ex.Message);
            }

            return crea;
        }

        /// <summary>
        /// Buscar una Vivienda por el parametro Codigo Postal en la tabla Cliente.
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public bool Read()
        {

            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.Vivienda vivienda = bbdd.Vivienda.Where(x => x.CodigoPostal == this.CodigoPostal).FirstOrDefault();

                if (vivienda != null)
                {
                    //Sincroniza datos 
                    CommonBC.Syncronize(vivienda, this);

                    return true;
                }
                else
                {
                    return false;
                    throw new Exception("La vivienda : " + CodigoPostal + "  no existe.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Read Vivienda. " + ex.Message);
            }



        }

        /// <summary>
        /// Actualiza los datos del objeto en la BD.
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.Vivienda vivienda = bbdd.Vivienda.Where(x => x.CodigoPostal == this.CodigoPostal).FirstOrDefault();
                if (vivienda != null)
                {
                    //sincroniza la clase de negocio con la entidad de BD.
                    CommonBC.Syncronize(this, vivienda);

                    //Modifica los cambios.
                    bbdd.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("La Vivienda no existe.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Actualizar Vivienda. " + ex.Message);
            }
        }

        /// <summary>
        /// Elimina la vivienda
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.Vivienda viv = bbdd.Vivienda.Where(x => x.CodigoPostal == this.CodigoPostal).FirstOrDefault();
                if (viv != null)
                {
                    //sincroniza la clase de la aplicacion con la entidad de BD y modifica los cambios
                    bbdd.Vivienda.Remove(viv);
                    bbdd.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("La Vivienda no existe.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error Delete Vivienda. " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos los registros de la tabla Vivienda.
        /// </summary>
        /// <returns>List<Vivienda></returns>
        public List<Vivienda> ReadAll()
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();

                List<Entity.Vivienda> listaDatos = bbdd.Vivienda.ToList<Entity.Vivienda>();
                List<Vivienda> list = SyncList(listaDatos);

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer las Viviendas. " + ex.Message);
            }
        }

        /// <summary>
        /// Sincroniza una lista Entity en una de Negocio
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns>List<Vivienda></returns>
        private List<Vivienda> SyncList(List<Entity.Vivienda> listaDatos)
        {
            List<Vivienda> list = new List<Vivienda>();

            try
            {
                foreach (var x in listaDatos)
                {
                    Vivienda vivienda = new Vivienda();
                    CommonBC.Syncronize(x, vivienda);

                    list.Add(vivienda);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Sincronizar Lista. " + ex.Message);
            }

            return list;
        }
    }
}
