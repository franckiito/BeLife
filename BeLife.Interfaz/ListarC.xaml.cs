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
    /// Lógica de interacción para ListarC.xaml
    /// </summary>
    public partial class ListarC : MetroWindow
    {
        public ListarC()
        {
            InitializeComponent();
        }

        private void ListarC_Click(object sender, RoutedEventArgs e)
        {
            ListarC lc = new ListarC();
            App.Current.MainWindow = lc;
            lc.Show();
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
