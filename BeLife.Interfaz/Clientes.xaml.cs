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
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : MetroWindow
    {
        Validaciones validaciones = new Validaciones();
        public Clientes()
        {
            InitializeComponent();
            LimpiaDatos();
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

        /// <summary>
        /// Agrega un Cliente en la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidaDatosCliente())
                {
                    Cliente cliente = new Cliente()
                    {
                        Rut = TxtRut.Text,
                        Nombres = TxtNombres.Text,
                        Apellidos = TxtApellidos.Text,
                        FechaNacimiento = (DateTime)FechaNacimiento.SelectedDate
                    };

                    Sexo sexo = new Sexo();
                    sexo.Id = CboSexo.SelectedIndex + 1;
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
        /// Retorna true si todos los campos son validados.
        /// </summary>
        /// <returns></returns>
        public bool ValidaDatosCliente()
        {
            bool valida = true;
            try
            {
                if (!validaciones.ValidaRut(TxtRut.Text))
                {
                    valida = false;
                }
                if (!validaciones.ValidaNombre(TxtNombres.Text))
                {
                    valida = false;
                }
                if (!validaciones.ValidaApellido(TxtApellidos.Text))
                {
                    valida = false;
                }
                if (!validaciones.ValidaFechaNacimiento((DateTime)FechaNacimiento.SelectedDate))
                {
                    valida = false;
                }
                if (!validaciones.ValidaComboBoxSexo(CboSexo.SelectedIndex))
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

        /// <summary>
        /// Limpia los Datos del formulario y carga los combobox
        /// </summary>
        private void LimpiaDatos()
        {
            TxtRut.Text = "";
            TxtNombres.Text = "";
            TxtApellidos.Text = "";
            FechaNacimiento.SelectedDate = DateTime.Today;
            cargaDatos();
        }

        /// <summary>
        /// Carga los combobox Sexo y Estado con los datos de la BD
        /// </summary>
        private void cargaDatos()
        {
            Sexo sexo = new Sexo();
            CboSexo.ItemsSource = sexo.ReadAll();
            CboSexo.SelectedIndex = -1;

            EstadoCivil estadoCivil = new EstadoCivil();
            CboEstadoCivil.ItemsSource = estadoCivil.ReadAll();
            CboEstadoCivil.SelectedIndex = -1;
        }

        /// <summary>
        /// Elimina el cliente de la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (validaciones.ValidaRut(TxtRut.Text))
                {
                    Cliente cliente = new Cliente()
                    {
                        Rut = TxtRut.Text
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

        /// <summary>
        /// Actualiza los datos del Cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidaDatosCliente())
                {
                    Cliente cliente = new Cliente()
                    {
                        Rut = TxtRut.Text,
                        Nombres = TxtNombres.Text,
                        Apellidos = TxtApellidos.Text,
                        FechaNacimiento = (DateTime)FechaNacimiento.SelectedDate
                    };

                    Sexo sexo = new Sexo();
                    sexo.Id = CboSexo.SelectedIndex + 1;
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

        /// <summary>
        /// Busca un Cliente por su rut y carga los textbox si lo encuentra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (validaciones.ValidaRut(TxtRut.Text))
                {
                    Cliente cliente = new Cliente()
                    {
                        Rut = TxtRut.Text
                    };
                    if (cliente.Read())
                    {
                        TxtNombres.Text = cliente.Nombres;
                        TxtApellidos.Text = cliente.Apellidos;
                        FechaNacimiento.SelectedDate = cliente.FechaNacimiento;
                        CargaSexo(cliente.Sexo.Id);
                        CargaEstado(cliente.EstadoCivil.Id);
                        MessageBox.Show("Datos del Cliente fueron cargados.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("El cliente no existe.", "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        /// <summary>
        /// Carga el combo box Estado Civil con en ID
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
        /// Carga el combobox Sexo con algun ID
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

            CboSexo.SelectedIndex = sexo.Id - 1;

        }
    }
}
