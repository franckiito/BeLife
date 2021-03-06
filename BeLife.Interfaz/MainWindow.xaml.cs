﻿using MahApps;
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
using System.Windows.Markup;

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

        private void AdministradorContrato_Click(object sender, RoutedEventArgs e)
        {
       
                Contratos cn = new Contratos();
                Application.Current.MainWindow = cn;
                cn.Show();
                this.Hide();
                this.Close();
            
        }

        private void ListarContrato(object sender, RoutedEventArgs e)
        {
            ListarC lc = new ListarC();
            App.Current.MainWindow = lc;
            lc.Show();
            this.Hide();
            this.Close();
        }

        private void ListarUsuarios(object sender, RoutedEventArgs e)
        {
            ListarU lu = new ListarU();
            App.Current.MainWindow = lu;
            lu.Show();
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
                    btnAdministradorUsuarios.Background = PinkColor;
                    btnAdministradorContratos.Background = PinkColor;
                    btnListarContratos.Background = PinkColor;
                    btnListarUsuarios.Background = PinkColor;





                }
            }
            else
            {
                SolidColorBrush FlyColor = new SolidColorBrush(Color.FromRgb(131, 50, 136));
                Resources.MergedDictionaries.Clear();
                Opciones.Background = Brushes.White;
                Inicio.Background = Brushes.White;

                btnAdministradorUsuarios.Background = Brushes.White;
                btnAdministradorContratos.Background = Brushes.White;
                btnListarContratos.Background = Brushes.White;
                btnListarUsuarios.Background = Brushes.White;


            }
        }
    }

   
}
