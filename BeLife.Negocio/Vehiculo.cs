using BeLife.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class Vehiculo
    {
        public string Patente { get; set; }
        public int IdMarca { get; set; } //
        public int IdModelo { get; set; } //
        public int Anho { get; set; }
        public MarcaModelo MarcaModelo { get; set; }

        public Vehiculo()
        {
            this.Init();
        }

        private void Init()
        {
            Patente = string.Empty;
            IdMarca = 0;
            IdModelo = 0;
            Anho = 0;
        }

        /// <summary>
        /// Retorna true o false si esta el Vehiculo, por su patente.
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {

            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.Vehiculo vehiculo = bbdd.Vehiculo.Where(x => x.Patente == this.Patente).FirstOrDefault();

                if (vehiculo != null)
                {
                    //Sincroniza datos 
                    CommonBC.Syncronize(vehiculo, this);

                    return true;
                }
                else
                {
                    return false;
                    throw new Exception("El Vehiculo patente: " + Patente + "  no existe.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Read Vehiculo. " + ex.Message);
            }
        }

        /// <summary>
        /// Trae una lista de los vehiculos que existen en la BD.
        /// </summary>
        /// <returns></returns>
        public List<Vehiculo> ReadAll()
        {
            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();

                List<Entity.Vehiculo> listaDatos = bbdd.Vehiculo.ToList<Entity.Vehiculo>();
                List<Vehiculo> list = SyncList(listaDatos);

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer los Vehiculos. " + ex.Message);
            }
        }

        /// <summary>
        /// Agrega el vehiculo a la BD.
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            bool crea = false;

            try
            {
                BeLifeEntities bbdd = new BeLifeEntities();
                Entity.Vehiculo vehiculo = new Entity.Vehiculo();

                //Ve si no existe el vehiculo para poder crearlo.
                if (!this.Read())
                {
                    //Sincroniza datos 
                    CommonBC.Syncronize(this, vehiculo);

                    //Guarda los cambios
                    bbdd.Vehiculo.Add(vehiculo);
                    bbdd.SaveChanges();
                    crea = true;

                }
                else
                {
                    throw new Exception("El Vehiculo ya existe.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Crear Vehiculo. " + ex.Message);
            }

            return crea;
        }

        /// <summary>
        /// Actualiza el Vehiculo
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                //Trae un cliente.
                Entity.Vehiculo vehiculo = bbdd.Vehiculo.Where(x => x.Patente == this.Patente).FirstOrDefault();
                if (vehiculo != null)
                {
                    //sincroniza la clase de negocio con la entidad de BD.
                    CommonBC.Syncronize(this, vehiculo);

                    //Modifica los cambios.
                    bbdd.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("El vehiculo no existe.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Actualizar el Vehiculo. " + ex.Message);
            }
        }

        /// <summary>
        /// Elimina Vehiculo
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            BeLifeEntities bbdd = new BeLifeEntities();
            try
            {
                Entity.Vehiculo vehiculo = bbdd.Vehiculo.Where(x => x.Patente == this.Patente).FirstOrDefault();
                if (vehiculo != null)
                {
                    //sincroniza la clase de la aplicacion con la entidad de BD y modifica los cambios
                    bbdd.Vehiculo.Remove(vehiculo);
                    bbdd.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("El cliente no existe.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error Delete Vehiculo. " + ex.Message);
            }
        }

        /// <summary>
        /// Sincroniza dos listas una de entity y la otra de la clase de negocio.
        /// </summary>
        /// <param name="listaDatos"></param>
        /// <returns></returns>
        private List<Vehiculo> SyncList(List<Entity.Vehiculo> listaDatos)
        {
            List<Vehiculo> list = new List<Vehiculo>();

            foreach (var x in listaDatos)
            {
                Vehiculo vehiculo = new Vehiculo();
                CommonBC.Syncronize(x, vehiculo);
                list.Add(vehiculo);

            }

            return list;
        }
    }
}
