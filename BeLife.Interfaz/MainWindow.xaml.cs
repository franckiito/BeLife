using MahApps;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MetroSegurosBeLife;

namespace BeLife.Interfaz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public List<String> Opcioness
        {
            get; set;
        }

        public List<String> Sexo
        {
            get; set;
        }

        public List<String> Estadocivil
        {
            get; set;
        }

        public MainWindow()
        {
            Opcioness = new List<String>();
            Opcioness.Add("Plan 1");
            Opcioness.Add("Plan 2");
            Opcioness.Add("Plan 3");


            Sexo = new List<String>();
            Sexo.Add("Otro");
            Sexo.Add("Femenino");
            Sexo.Add("Masculino");

            Estadocivil = new List<String>();
            Estadocivil.Add("Soltero");
            Estadocivil.Add("Casado");
            Estadocivil.Add("Viudo");
            Estadocivil.Add("Divorciado");

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }


        private void AdministradorUsuarios_Click(object sender, RoutedEventArgs e)
        {
                FlyU.IsOpen = true;
        }

        private void AdministradorContrato_Click(object sender, RoutedEventArgs e)
        {
            FlyContrato.IsOpen= true;
        }

        private void ListarContrato(object sender, RoutedEventArgs e)
        {
            FlyListarC.IsOpen = true;
        }

        private void ListarUsuarios(object sender, RoutedEventArgs e)
        {
            FlyListarU.IsOpen = true;
        }
    }

   
}
