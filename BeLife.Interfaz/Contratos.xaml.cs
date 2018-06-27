using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using BeLife.Negocio;

namespace BeLife.Interfaz
{
    /// <summary>
    /// Lógica de interacción para Contratos.xaml
    /// </summary>
    public partial class Contratos : MetroWindow
    {
        Validaciones validaciones = new Validaciones();
        public Contratos()
        {
            InitializeComponent();
        }

        private void AdministradorContrato_Click(object sender, RoutedEventArgs e)
        {
            Contratos cn = new Contratos();
            App.Current.MainWindow = cn;
            cn.Show();
            this.Hide();
            this.Close();
        }

        private void Vehiculo_Click(object sender, RoutedEventArgs e)
        {
            SeguroVehiculo.IsOpen = true;
        }

        private void Vivienda_Click(object sender, RoutedEventArgs e)
        {
            SeguroVivienda.IsOpen = true;
        }

        private void btninicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            Application.Current.MainWindow = inicio;
            inicio.Show();
            this.Hide();
            this.Close();
        }

        private void BtnAgregaVivienda_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidaDatosVivienda())
                {
                    Vivienda vivienda = new Vivienda()
                    {
                        CodigoPostal = int.Parse(TxtCodigoPostal.Text),
                        Anho = int.Parse(TxtAnioVivienda.Text),
                        Direccion = TxtDireccion.Text,
                        ValorInmueble = double.Parse(TxtValorInmueble.Text)
                    };
                    vivienda.ValorContenido = double.Parse(TxtValorContenido.Text);
                    
                    if (vivienda.Create())
                    {
                        MessageBox.Show("Vivienda agregada", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiaDatosVivienda();
                    }
                    else
                    {
                        MessageBox.Show("La vivienda no se pudo agregar", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void LimpiaDatosVivienda()
        {
            TxtCodigoPostal.Text = "";
            TxtDireccion.Text = "";
            TxtValorContenido.Text = "";
            TxtValorInmueble.Text = "";
            TxtAnioVivienda.Text = "";
            CboRegion.SelectedIndex = -1;
            CboComuna.SelectedIndex = -1;
        }

        private bool ValidaDatosVivienda()
        {
            bool valida = true;
            try
            {
                if (!validaciones.ValidaCodigoPostal(int.Parse(TxtCodigoPostal.Text)))
                {
                    valida = false;
                }
                if (!validaciones.ValidaAnhoVivienda(int.Parse(TxtAnioVivienda.Text)))
                {
                    valida = false;
                }
                if (!validaciones.ValidaDireccion(TxtDireccion.Text))
                {
                    valida = false;
                }
                if (!validaciones.ValidaValorInmueble(double.Parse(TxtValorInmueble.Text)))
                {
                    valida = false;
                }

            }
            catch (Exception ex)
            {
                valida = false;
                throw new Exception(ex.Message);
            }
            return valida;
        }

        private void BtnAgregarAutomovil_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (validaciones.ValidaPatente(TxtPatente.Text) && validaciones.ValidaAnhoVehiculo(int.Parse(TxtAnioVehiculo.Text)))
                {
                    Vehiculo vehiculo = new Vehiculo()
                    {
                        Patente = TxtCodigoPostal.Text,
                        Anho = int.Parse(TxtAnioVivienda.Text),
                        
                    };

                    if (vehiculo.Create())
                    {
                        MessageBox.Show("Vehiculo agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiaDatosVivienda();
                    }
                    else
                    {
                        MessageBox.Show("El vehiculo no se pudo agregar", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

       
    }
}
