
using Entidades;
using System;
using System.Windows.Forms;

namespace SistemaDeVentas.UI.Registros
{
    public partial class rClientes : Form
    {
        public rClientes()
        {
            InitializeComponent();
        }

        private void rClientes_Load(object sender, EventArgs e)
        {

        }

        private bool validar(int error)
        {
            bool errores = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider1.SetError(IdnumericUpDown, "Llenar Id");
                errores = true;
            }

            if (error == 2 && string.IsNullOrEmpty(NombretextBox.Text))
            {
                errorProvider1.SetError(NombretextBox, "Llene nombre");
                errores = true;
            }


            if (error == 2 && string.IsNullOrEmpty(DirecciontextBox.Text))
            {
                errorProvider1.SetError(DirecciontextBox, "Llene direccion");
                errores = true;
            }


            if (error == 2 && string.IsNullOrEmpty(CedulamaskedTextBox.Text))
            {
                errorProvider1.SetError(CedulamaskedTextBox, "Llene cedula");
                errores = true;
            }


            if (error == 2 && string.IsNullOrEmpty(TelefonomaskedTextBox.Text))
            {
                errorProvider1.SetError(TelefonomaskedTextBox, "Llene telefono");
                errores = true;
            }

            return errores;

        }
        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Clear();
            DirecciontextBox.Clear();
            TelefonomaskedTextBox.Clear();
            CedulamaskedTextBox.Clear();
            DevueltatextBox.Clear();

            errorProvider1.Clear();
        }
        private Clientes Llenaclase()
        {
            DevueltatextBox.Text = 0.ToString();
            Clientes Cliente = new Clientes();
            Cliente.ClienteId = Convert.ToInt32(IdnumericUpDown.Value);
            Cliente.Nombre = NombretextBox.Text;
            Cliente.Direccion = DirecciontextBox.Text;
            Cliente.Cedula = CedulamaskedTextBox.Text;
            Cliente.Telefono = TelefonomaskedTextBox.Text;

            Cliente.Devuelta = Convert.ToDecimal(DevueltatextBox.Text);


            return Cliente;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (validar(1))
            {
                MessageBox.Show("llenar clienteId");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                Clientes Cliente = BLL.ClientesBLL.Buscar(id);

                if (Cliente != null)
                {
                    IdnumericUpDown.Value = Cliente.ClienteId;
                    NombretextBox.Text = Cliente.Nombre;
                    DirecciontextBox.Text = Cliente.Direccion;
                    CedulamaskedTextBox.Text = Cliente.Cedula;
                    TelefonomaskedTextBox.Text = Cliente.Telefono;
                    DevueltatextBox.Text = Cliente.Devuelta.ToString();


                }
                else
                {
                    MessageBox.Show("No Fue Encontrado!",
                        "busacr de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider1.Clear();
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            bool paso = false;
            Clientes Cliente = Llenaclase();


            if (validar(2))
            {
                MessageBox.Show("llenar los campos");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                if (id == 0)
                {
                    paso = BLL.ClientesBLL.Guardar(Cliente);
                }
                else
                {
                    var P = BLL.ClientesBLL.Buscar(id);
                    if (P != null)
                    {
                        paso = BLL.ClientesBLL.Modificar(Cliente);
                    }
                }
                Limpiar();
                errorProvider1.Clear();
                if (paso)
                {
                    MessageBox.Show("Guardado!",
                        "Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No pudo Guardar!",
                        "guardar de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (validar(1))
            {
                MessageBox.Show("llenar clienteId");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);

                if (BLL.ClientesBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!",
                        "Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No fue Eliminar!",
                        "eliminar de nuevo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider1.Clear();
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
