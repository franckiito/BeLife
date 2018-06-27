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
    /// Lógica de interacción para ListarU.xaml
    /// </summary>
    public partial class ListarU : MetroWindow
    {
        public ListarU()
        {
            InitializeComponent();
            LimpiaDatos();
            CargaClientes();
        }

        private void CargaClientes()
        {
            Cliente cliente = new Cliente();
            GrdClientes.ItemsSource = cliente.ReadAll();

        }

        private void LimpiaDatos()
        {
            TxtRut.Text = "";
            CargaDatos();
        }

        private void CargaDatos()
        {
            Sexo sexo = new Sexo();
            CboSexo.ItemsSource = sexo.ReadAll();
            CboSexo.SelectedIndex = -1;

            EstadoCivil estadoCivil = new EstadoCivil();
            CboEstadoCivil.ItemsSource = estadoCivil.ReadAll();
            CboEstadoCivil.SelectedIndex = -1;
        }

        private void ListarUsuarios(object sender, RoutedEventArgs e)
        {
            ListarU lu = new ListarU();
            App.Current.MainWindow = lu;
            lu.Show();
            this.Hide();
            this.Close();
        }

        private void btninicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            Application.Current.MainWindow = inicio;
            inicio.Show();
            this.Hide();
            this.Close();
        }

        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Lee los controles de la interfaz.
                string rut = TxtRut.Text;

                Sexo sexo = new Sexo();
                sexo.Id = CboSexo.SelectedIndex + 1;

                EstadoCivil estado = new EstadoCivil();
                estado.Id = CboEstadoCivil.SelectedIndex + 1;

                Cliente cliente = new Cliente();

                //Solo Rut
                if (String.IsNullOrEmpty(rut) == false && !sexo.Read() && !estado.Read())
                {
                    GrdClientes.ItemsSource = cliente.ReadAll(rut);
                }
                //Solo Sexo
                if (String.IsNullOrEmpty(rut) != false && sexo.Read() && !estado.Read())
                {
                    GrdClientes.ItemsSource = cliente.ReadAllBySexo(sexo.Id);
                }
                //Solo Estado
                if (String.IsNullOrEmpty(rut) != false && !sexo.Read() && estado.Read())
                {
                    GrdClientes.ItemsSource = cliente.ReadAllByEstadoCivil(estado.Id);
                }
                //Rut y Sexo
                if (String.IsNullOrEmpty(rut) == false && sexo.Read() && !estado.Read())
                {
                    GrdClientes.ItemsSource = cliente.ReadAllRutSexo(rut, sexo.Id);
                }
                //Rut y Estado
                if (String.IsNullOrEmpty(rut) == false && !sexo.Read() && estado.Read())
                {
                    GrdClientes.ItemsSource = cliente.ReadAllRutEstado(rut, estado.Id);
                }
                //Sexo y Estado
                if (String.IsNullOrEmpty(rut) != false && sexo.Read() && estado.Read())
                {
                    GrdClientes.ItemsSource = cliente.ReadAll(sexo.Id, estado.Id);
                }
                //Rut, Sexo y Estado
                if (String.IsNullOrEmpty(rut) == false && sexo.Read() && estado.Read())
                {
                    GrdClientes.ItemsSource = cliente.ReadAll(rut, sexo.Id, estado.Id);
                }
                //NINGUNO
                if (String.IsNullOrEmpty(rut) != false && !sexo.Read() && !estado.Read())
                {
                    GrdClientes.ItemsSource = cliente.ReadAll();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BtnBorrarFiltro_Click(object sender, RoutedEventArgs e)
        {
            TxtRut.Text = "";
            CboEstadoCivil.SelectedIndex = -1;
            CboSexo.SelectedIndex = -1;
        }

        bool Contraste = false;

        private void BtnContraste_Click(object sender, RoutedEventArgs e)
        {
            Contraste = !Contraste;
            if (Contraste)
            {

                {
                    SolidColorBrush PinkColor = new SolidColorBrush(Color.FromRgb(242, 0, 252));

                    Opciones.Background = Brushes.Black;
                    Inicio.Background = Brushes.Black;
                }
            }
            else
            {
                SolidColorBrush FlyColor = new SolidColorBrush(Color.FromRgb(131, 50, 136));
                Resources.MergedDictionaries.Clear();
                Opciones.Background = Brushes.White;
                Inicio.Background = Brushes.White;
                
            }
        }
    }
}
