﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BeLife.Negocio
{
    public class Validaciones
    {
        

        /// <summary>
        /// Retorna True si el rut es valido y no es nulo.
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public bool ValidaRut(string rut)
        {
            try
            {
                bool valida = true;

                if (string.IsNullOrEmpty(rut))
                {
                    valida = false;
                    throw new Exception("Debe Ingresar Rut.");
                }
                if (!ValidaRutChileno(rut))
                {
                    valida = false;
                    throw new Exception("Debe ingresar un Rut Valido.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
            }
        }

        //Rut Chileno Valido
        public bool ValidaRutChileno(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return validacion;
        }

        /// <summary>
        /// Retorna true si el Nombre es valido.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public bool ValidaNombre(string nombre)
        {
            try
            {
                bool valida = true;

                if (string.IsNullOrEmpty(nombre))
                {
                    valida = false;
                    throw new Exception("Debe Ingresar nombres.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna true si el Apellido es valido.
        /// </summary>
        /// <param name="apellido"></param>
        /// <returns></returns>
        public bool ValidaApellido(string apellido)
        {
            try
            {
                bool valida = true;

                if (string.IsNullOrEmpty(apellido))
                {
                    valida = false;
                    throw new Exception("Debe Ingresar apellido.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna True cuando una fecha es mayor de edad y no es nula.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool ValidaFechaNacimiento(DateTime fecha)
        {
            try
            {
                bool valida = true;

                if (fecha == null)
                {
                    valida = false;
                    throw new Exception("Debe Ingresar fecha.");
                }
                if (ValidaEdad(fecha) < 18)
                {
                    valida = false;
                    throw new Exception("Debe ser mayor de edad.");
                }
                

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna la edad, de una fecha ingresada por parametro.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        private int ValidaEdad(DateTime fecha)
        {
            try
            {
                int age = DateTime.Now.Year - fecha.Year;
                if (DateTime.Now.Month < fecha.Month || (DateTime.Now.Month == fecha.Month && DateTime.Now.Day < fecha.Day))
                    age--;
                return age;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna true cuando se ha seleccionado un combobox.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ValidaComboBoxEstado(int index)
        {
            try
            {
                bool valida = true;

                if (index < 0)
                {
                    valida = false;
                    throw new Exception("Debe seleccionar un item del combobox Estado.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna true cuando se ha seleccionado un combobox.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ValidaComboBoxSexo(int index)
        {
            try
            {
                bool valida = true;

                if (index < 0)
                {
                    valida = false;
                    throw new Exception("Debe seleccionar un item del combobox Sexo.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Retorna el numero de contrato generado por la la fecha actual.
        /// </summary>
        /// <returns></returns>
        public string GeneraNumeroContrato()
        {
            string numero = "";

            try
            {
                numero += DateTime.Now.Year + "";
                //Compara el mes, si es menor a 10 antepone un 0.
                if (DateTime.Now.Month < 10)
                {
                    numero += "0" + DateTime.Now.Month;
                }
                else
                {
                    numero += DateTime.Now.Month + "";
                }
                //Compara el dia, si es menor a 10 antepone un 0.
                if (DateTime.Now.Day < 10)
                {
                    numero += "0" + DateTime.Now.Day;
                }
                else
                {
                    numero += DateTime.Now.Day + "";
                }
                //Compara el Hora, si es menor a 10 antepone un 0.
                if (DateTime.Now.Hour < 10)
                {
                    numero += "0" + DateTime.Now.Hour;
                }
                else
                {
                    numero += DateTime.Now.Hour + "";
                }
                //Compara el Minutos, si es menor a 10 antepone un 0.
                if (DateTime.Now.Minute < 10)
                {
                    numero += "0" + DateTime.Now.Minute;
                }
                else
                {
                    numero += DateTime.Now.Minute + "";
                }
                //Compara el Segundos, si es menor a 10 antepone un 0.
                if (DateTime.Now.Second < 10)
                {
                    numero += "0" + DateTime.Now.Second;
                }
                else
                {
                    numero += DateTime.Now.Second + "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return numero;
        }

        public DateTime GeneraTermino(DateTime fecha)
        {
            return fecha.AddMonths(+1);
        }

        /// <summary>
        /// Retorna true si el numero de contrato es valido.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public bool ValidaNumeroContrato(string numero)
        {
            try
            {
                bool valida = true;

                if (string.IsNullOrEmpty(numero))
                {
                    valida = false;
                    throw new Exception("Debe Ingresar Numero Contrato.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna trye cuando la fecha incio Vigencia es valida.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool ValidaInicioVigencia(DateTime fecha)
        {
            bool valida = true;
            try
            {
                if (fecha == null)
                {
                    valida = false;
                    throw new Exception("Debe ingresar fecha inicio vigencia.");
                }
                if ( fecha < DateTime.Now.AddDays(-1) ) 
                {
                    valida = false;
                    throw new Exception("La fecha inicio vigencia no puede ser menor a la fecha actual.");
                }
                if((fecha.Month - DateTime.Now.Month) >= 1)
                {
                    valida = false;
                    throw new Exception("La fecha inicio vigencia no puede tener mas de un mes de desfaz");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
            }
            return valida;
        }

        /// <summary>
        /// Retorna true cuando se ha seleccionado un combobox.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ValidaComboBoxPlan(int index)
        {
            try
            {
                bool valida = true;

                if (index < 0)
                {
                    valida = false;
                    throw new Exception("Debe seleccionar un item del combobox Plan.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna true si la poliza anual es valida.
        /// </summary>
        /// <param name="pol"></param>
        /// <returns></returns>
        public bool ValidaPolizaAnual(string pol)
        {
            try
            {
                bool valida = true;

                if (string.IsNullOrEmpty(pol))
                {
                    valida = false;
                    throw new Exception("Debe Ingresar Poliza Anual.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna true si la poliza mensual es valida.
        /// </summary>
        /// <param name="pol"></param>
        /// <returns></returns>
        public bool ValidaPolizaMensual(string pol)
        {
            try
            {
                bool valida = true;

                if (string.IsNullOrEmpty(pol))
                {
                    valida = false;
                    throw new Exception("Debe Ingresar Poliza Mensual.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retorna true si la observacion es valida.
        /// </summary>
        /// <param name="observacion"></param>
        /// <returns></returns>
        public bool ValidaObservaciones(string observacion)
        {
            try
            {
                bool valida = true;

                if (string.IsNullOrEmpty(observacion))
                {
                    valida = false;
                    throw new Exception("Debe ingresar observacion.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        /// <summary>
        /// Valida que el año del vehiculo sea correcto.
        /// </summary>
        /// <param name="anio"></param>
        /// <returns></returns>
        public bool ValidaAnhoVehiculo(int anio)
        {
            try
            {
                bool valida = false;

                if (anio >= 1980 && anio <= DateTime.Now.Year)
                {
                    valida = true;
                }
                else
                {
                    valida = false;
                    throw new Exception("Debe ingresar un año valido.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Valida que la patente tenga el formato correcto.
        /// </summary>
        /// <param name="patente"></param>
        /// <returns>Bool</returns>
        public bool ValidaPatente(string patente)
        {
            try
            {
                bool valida = false;

                if (!patente.Equals(String.Empty) && !patente.Equals(null) && !patente.Equals(""))
                {
                    valida = true;
                    // AAAA99
                    string regex1 = "^[A-Z]{4}[0-9]{2}$";
                    // AAA999
                    string regex2 = "^[A-Z]{3}[0-9]{3}$";
                    // AA9999
                    string regex3 = "^[A-Z]{2}[0-9]{4}$";

                    if (Regex.Match(patente, regex1).Success || Regex.Match(patente, regex2).Success ||
                            Regex.Match(patente, regex3).Success)
                    {
                        valida = true;
                    }
                    else
                    {
                        valida = false;
                        throw new Exception("Debe una patente valida.");
                    }
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Valida el codigo postal de la vivienda
        /// </summary>
        /// <param name="codigoPostal"></param>
        /// <returns>Bool</returns>
        public bool ValidaCodigoPostal(int codigoPostal)
        {
            try
            {
                bool valida = false;

                if (codigoPostal >= 1000000 && codigoPostal <= 9999999)
                {
                    valida = true;
                }
                else
                {
                    valida = false;
                    throw new Exception("Debe ingresar codigo postal Valido.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valida que el año de la vivienda sea Valido.
        /// </summary>
        /// <param name="anio"></param>
        /// <returns></returns>
        public bool ValidaAnhoVivienda(int anio)
        {
            try
            {
                bool valida = false;

                if (anio >= 1910 && anio <= DateTime.Now.Year)
                {
                    valida = true;
                }
                else
                {
                    valida = false;
                    throw new Exception("Debe ingresar año Valido para la vivienda.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valida que la direccion no sea nula.
        /// </summary>
        /// <param name="direccion"></param>
        /// <returns></returns>
        public bool ValidaDireccion(string direccion)
        {
            try
            {
                bool valida = true;

                if (string.IsNullOrEmpty(direccion))
                {
                    valida = false;
                    throw new Exception("Debe Ingresar Direccion.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Valida que el valor inmueble sea valido.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool ValidaValorInmueble(double valor)
        {
            try
            {
                bool valida = false;

                if (valor > 0)
                {
                    valida = true;
                }
                else
                {
                    valida = false;
                    throw new Exception("Debe ingresar un valor de inmueble Valido.");
                }

                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
