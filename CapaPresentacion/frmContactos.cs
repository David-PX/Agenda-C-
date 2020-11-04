using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion

{


    public partial class frmContactos : Form
    {
        private string idcontactos;
        private bool Editarse = false;
        E_contactos objEntidad = new E_contactos();
        N_contactos objNegocios = new N_contactos();
        public frmContactos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MostrarTabla(txtBuscar.Text);
        }

        public void MostrarTabla(string buscar)
        {
            N_contactos objNegocio = new N_contactos();
            TablaContactos.DataSource = objNegocio.ListarContactos(buscar);
        }

        public void limpiarCaja()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCedula.Text = "";
            txtCorreo.Text = "";
            txtNum1.Text = "";
            txtNum2.Text = "";
            txtDireccion.Text = "";
            txtNombre.Focus();
            Editarse = false;
        }

        private void frmContactos_Load(object sender, EventArgs e)
        {
            MostrarTabla("");
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCaja();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    objEntidad.Nombres = txtNombre.Text;
                    objEntidad.Apellidos = txtApellidos.Text;
                    objEntidad.Cedula = txtCedula.Text;
                    objEntidad.Correo = txtCorreo.Text;
                    objEntidad.Telefono1 = txtNum1.Text;
                    objEntidad.Telefono2 = txtNum2.Text;
                    objEntidad.Direccion = txtDireccion.Text;

                    objNegocios.InsertandoContactos(objEntidad);

                    MessageBox.Show("Se guardo el registro");
                    MostrarTabla("");
                    limpiarCaja();
                }
                catch (Exception ez)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ez);
                }
            }
            if (Editarse == true)
            {

                try
                {
                    objEntidad.ID = Convert.ToInt32(idcontactos);
                    objEntidad.Nombres = txtNombre.Text;
                    objEntidad.Apellidos = txtApellidos.Text;
                    objEntidad.Cedula = txtCedula.Text;
                    objEntidad.Correo = txtCorreo.Text;
                    objEntidad.Telefono1 = txtNum1.Text;
                    objEntidad.Telefono2 = txtNum2.Text;
                    objEntidad.Direccion = txtDireccion.Text;

                    objNegocios.EditandoContactos(objEntidad);

                    MessageBox.Show("Se edito el registro");
                    MostrarTabla("");
                    limpiarCaja();
                    Editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro" + ex);
                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (TablaContactos.SelectedRows.Count > 0)
            {
                objEntidad.ID = Convert.ToInt32(TablaContactos.CurrentRow.Cells[0].Value.ToString());
                objNegocios.EliminandoContactos(objEntidad);

                MessageBox.Show("Se elimino correctamente");
                MostrarTabla("");
                limpiarCaja();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que quieres eliminar");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (TablaContactos.SelectedRows.Count > 0)
            {
                Editarse = true;
                idcontactos = TablaContactos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = TablaContactos.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = TablaContactos.CurrentRow.Cells[2].Value.ToString();
                txtCedula.Text = TablaContactos.CurrentRow.Cells[3].Value.ToString();
                txtCorreo.Text = TablaContactos.CurrentRow.Cells[4].Value.ToString();
                txtNum1.Text = TablaContactos.CurrentRow.Cells[5].Value.ToString();
                txtNum2.Text = TablaContactos.CurrentRow.Cells[6].Value.ToString();
                txtDireccion.Text = TablaContactos.CurrentRow.Cells[7].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }
    }
}
