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
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;

            if (txtCeunta.Text != "")
            {
                if (txtCuenta.IsEnabled == true)
                {
                    cmd.CommandText = "insert into Directorio(NoCuenta,NombreAlumno,ApellidoAlumno,GrupoAlumno,NumeroAlumno,DireccionAlumno,CorreoAlumno) " +
                        "Values(" + txtCuenta.Text + ",'" + txtNombre.Text + "','" + txtApellido.Text + "','"
                        + txtGrupo.Text +  "','" + txtTelefono.Text + "',"
                        + txtDireccion.Text + ",'" + txtCorreo.Text + "')";
                    cmd.ExecuteNonQuery();
                    MostrarDatos();
                    MessageBox.Show("Nuevo alumno agregado ...");
                    LimpiaTodo();
                }
                else
                {
                    cmd.CommandText = "update Directorio set NoCuenta='" + txtCuenta.Text + "',ApellidoAlumno='" + txtApellido.Text +
                         "',GrupoAlumno='" + txtGrupo.Text + "',NumeroAlumno='" + txtTelefono.Text + "',='" + 
                        "',DireccionAlumno='" + txtDireccion.Text + "',CorreoAlumno='" + txtCorreo.Text + "' where NoCuenta=" + txtPedido.Text;
                    cmd.ExecuteNonQuery();
                    MostrarDatos();
                    MessageBox.Show("Datos del Alumno Actualizados...");
                    LimpiaTodo();
                }
            }
            else
            {
                MessageBox.Show("Pon un numero de Cuenta");
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (gvDatos.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)gvDatos.SelectedItems[0];
                txtCuenta.Text = row["NoCuenta"].ToString();
                txtNombre.Text = row["NombreAlumno"].ToString();
                txtApellidos.Text = row["ApellidoAlumno"].ToString();
                txtGrupo.Text = row["GrupoAlumno"].ToString();
                txtTelefono.Text = row["NumeroAlumno"].ToString();
                txtDireccion.Text = row["DireccionAlumno"].ToString();
                txtCorreo.Text = row["CorreoAlumno"].ToString();
                txtCuenta.IsEnabled = false;
                btnNuevo.Content = "Actualizar";
            }
            else
            {
                MessageBox.Show("Selecciona el numero de cuenta que desea editar");
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (gvDatos.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)gvDatos.SelectedItems[0];

                OleDbCommand cmd = new OleDbCommand();
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from Directorio where NoCuenta=" + row["NoCuenta"].ToString();
                cmd.ExecuteNonQuery();
                MostrarDatos();
                MessageBox.Show("Alumno Eliminado del directorio");
                LimpiaTodo();
            }
            else
            {
                MessageBox.Show("Elige un numero de Cuenta a Eliminar");
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiaTodo();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

        private void MostrarDatos()
        {
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Directorio";
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            gvDatos.ItemsSource = dt.AsDataView();

            if (dt.Rows.Count > 0)
            {
                lbContenido.Visibility = System.Windows.Visibility.Hidden;
                gvDatos.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                lbContenido.Visibility = System.Windows.Visibility.Visible;
                gvDatos.Visibility = System.Windows.Visibility.Hidden;
            }

        }
    }
}
