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

using BeLife.Negocio;

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

        //Da acceso para poder hacer las validaciones
        Validaciones validaciones = new Validaciones();
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
            LimpiaDatos();
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

        private void BtnGuardaCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidaDatosCliente())
                {
                    Cliente cliente = new Cliente()
                    {
                        Rut = txtRut.Text,
                        Nombres = txtNombres.Text,
                        Apellidos = txtApellidos.Text,
                        FechaNacimiento = (DateTime)FechaNacimiento.SelectedDate
                    };

                    Sexo sexo = new Sexo();
                    sexo.Id = CboSexos.SelectedIndex + 1;
                    if (sexo.Read())
                    {
                        cliente.Sexo = sexo;
                    }

                    EstadoCivil estado = new EstadoCivil();
                    estado.Id = CboEstadoCivil.SelectedIndex + 1;
                    if (estado.Read())
                    {
                        cliente.EstadoCivil = estado;
                    }

                    if (cliente.Create())
                    {
                        MessageBox.Show("Cliente agregado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiaDatos();
                    }
                    else
                    {
                        MessageBox.Show("El Cliente no se pudo agregar", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        /// <summary>
        /// Limpia los Datos del formulario y carga los combobox
        /// </summary>
        private void LimpiaDatos()
        {
            txtRut.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            FechaNacimiento.SelectedDate = DateTime.Today;
            CargaDatos();
        }

        /// <summary>
        /// Carga los combobox Sexo y Estado con los datos de la BD
        /// </summary>
        private void CargaDatos()
        {
            Sexo sexo = new Sexo();
            CboSexos.ItemsSource = sexo.ReadAll();
            CboSexos.SelectedIndex = -1;

            EstadoCivil estadoCivil = new EstadoCivil();
            CboEstadoCivil.ItemsSource = estadoCivil.ReadAll();
            CboEstadoCivil.SelectedIndex = -1;
        }

        /// <summary>
        /// Retorna true si todos los campos son validados.
        /// </summary>
        /// <returns></returns>
        public bool ValidaDatosCliente()
        {
            bool valida = true;
            try
            {
                if (!validaciones.ValidaRut(txtRut.Text))
                {
                    valida = false;
                }
                if (!validaciones.ValidaNombre(txtNombres.Text))
                {
                    valida = false;
                }
                if (!validaciones.ValidaApellido(txtApellidos.Text))
                {
                    valida = false;
                }
                if (!validaciones.ValidaFechaNacimiento((DateTime)FechaNacimiento.SelectedDate))
                {
                    valida = false;
                }
                if (!validaciones.ValidaComboBoxSexo(CboSexos.SelectedIndex))
                {
                    valida = false;
                }
                if (!validaciones.ValidaComboBoxEstado(CboEstadoCivil.SelectedIndex))
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

        private void BtnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (validaciones.ValidaRut(txtRut.Text))
                {
                    Cliente cliente = new Cliente()
                    {
                        Rut = txtRut.Text
                    };
                    if (cliente.Read())
                    {
                        txtNombres.Text = cliente.Nombres;
                        txtApellidos.Text = cliente.Apellidos;
                        FechaNacimiento.SelectedDate = cliente.FechaNacimiento;
                        CargaSexo(cliente.Sexo.Id);
                        CargaEstado(cliente.EstadoCivil.Id);
                        MessageBox.Show("Datos del Cliente fueron cargados.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// Carga los estados
        /// </summary>
        /// <param name="idEstadoCivil"></param>
        private void CargaEstado(int idEstadoCivil)
        {
            EstadoCivil estado = new EstadoCivil();
            estado.Id = idEstadoCivil;

            if (!estado.Read())
            {
                throw new Exception("Error al leer estado.");
            }

            CboEstadoCivil.SelectedIndex = estado.Id - 1;

        }
        
        /// <summary>
        /// Carga los sexos
        /// </summary>
        /// <param name="idSexo"></param>
        private void CargaSexo(int idSexo)
        {
            Sexo sexo = new Sexo();

            sexo.Id = idSexo;

            if (!sexo.Read())
            {
                throw new Exception("Error al leer Sexo.");
            }

            CboSexos.SelectedIndex = sexo.Id - 1;

        }

        private void BtnEliminaCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (validaciones.ValidaRut(txtRut.Text))
                {
                    Cliente cliente = new Cliente()
                    {
                        Rut = txtRut.Text
                    };
                    if (cliente.Delete())
                    {
                        MessageBox.Show("El cliente con rut " + cliente.Rut + " fue eliminado.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiaDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BtnActualizaCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidaDatosCliente())
                {
                    Cliente cliente = new Cliente()
                    {
                        Rut = txtRut.Text,
                        Nombres = txtNombres.Text,
                        Apellidos = txtApellidos.Text,
                        FechaNacimiento = (DateTime)FechaNacimiento.SelectedDate
                    };

                    Sexo sexo = new Sexo();
                    sexo.Id = CboSexos.SelectedIndex + 1;
                    if (sexo.Read())
                    {
                        cliente.Sexo = sexo;
                    }
                    else
                    {
                        throw new Exception("Sexo Invalido.");
                    }

                    EstadoCivil estado = new EstadoCivil();
                    estado.Id = CboEstadoCivil.SelectedIndex + 1;
                    if (estado.Read())
                    {
                        cliente.EstadoCivil = estado;
                    }
                    else
                    {
                        throw new Exception("Estado Invalido.");
                    }

                    if (cliente.Update())
                    {
                        MessageBox.Show("Cliente actualizado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiaDatos();
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
