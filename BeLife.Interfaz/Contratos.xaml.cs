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

namespace BeLife.Interfaz
{
    /// <summary>
    /// Lógica de interacción para Contratos.xaml
    /// </summary>
    public partial class Contratos : MetroWindow
    {
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

    }
}
