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
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : MetroWindow
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void AdministradorUsuarios_Click(object sender, RoutedEventArgs e)
        {

            Clientes cli = new Clientes();
            Application.Current.MainWindow = cli;
            cli.Show();
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
    }
}
