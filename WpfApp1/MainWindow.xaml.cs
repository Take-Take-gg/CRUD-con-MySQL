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
using System.Data.OleDb;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i;

        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            string Cu, No, Ap, Gr, Te, Di, Co;
            Cu = txtCuenta.Text;
            No = txtNombre.Text;
            Ap = txtApellidos.Text;
            Gr = txtGrupo.Text;
            Te = txtTelefono.Text;
            Di = txtDireccion.Text;
            Co = txtCorreo.Text;

          //  gvDatos.Rows.Add

            i = i + 1;
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (gvDatos.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)gvDatos.SelectedItems[0];
                txtCuenta.Text = row["Cuenta"].ToString();
                txtNombre.Text = row["Producto"].ToString();
                txtApellidos.Text = row["Precio"].ToString();
                txtGrupo.Text = row["Comprador"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
                txtDireccion.Text = row["Direccion"].ToString();
                txtCorreo.Text = row["Correo"].ToString();
                txtCuenta.IsEnabled = false;
                btnNuevo.Content = "Actualizar";
            }
            else
            {
                MessageBox.Show("Favor de seleccionar la id del producto que desea editar");
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LimpiaTodo()
        {
            txtCuenta.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtGrupo.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            btnNuevo.Content = "Nuevo";
            txtCuenta.IsEnabled = true;
        }
    }
}
