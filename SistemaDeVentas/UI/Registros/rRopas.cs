
using Entidades;
using System;
using System.Windows.Forms;

namespace SistemaDeVentas.UI.Registros
{
    public partial class rRopas : Form
    {
        public rRopas()
        {
            InitializeComponent();
        }

        private bool validar(int error)
        {
            bool errores = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider1.SetError(IdnumericUpDown, "Llenar Id");
                errores = true;
            }

            if (error == 2 && PrecionumericUpDown.Value == 0)
            {
                errorProvider1.SetError(PrecionumericUpDown, "Llenar precio");
                errores = true;
            }
            if (error == 2 && string.IsNullOrEmpty(SizetextBox.Text))
            {
                errorProvider1.SetError(SizetextBox, "Llena size");
                errores = true;
            }
            if (error == 2 && string.IsNullOrEmpty(MarcatextBox.Text))
            {
                errorProvider1.SetError(MarcatextBox, "Llena marca");
                errores = true;
            }

            if (error == 2 && string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                errorProvider1.SetError(DescripciontextBox, "Llena Descripcion");
                errores = true;
            }

            if (error == 2 && string.IsNullOrEmpty(InventariotextBox.Text))
            {
                errorProvider1.SetError(InventariotextBox, "Llena Inventario");
                errores = true;
            }


            return errores;

        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            SizetextBox.Clear();
            PrecionumericUpDown.Value = 0;
            InventariotextBox.Clear();
            DescripciontextBox.Clear();
            MarcatextBox.Clear();
            InventariotextBox.Text = 0.ToString();


            errorProvider1.Clear();
        }

        private Ropas Llenaclase()
        {
            Ropas Ropa = new Ropas();

            InventariotextBox.Text = 0.ToString();
            Ropa.RopaId = Convert.ToInt32(IdnumericUpDown.Value);
            Ropa.Descripcion = DescripciontextBox.Text;
            Ropa.Size = SizetextBox.Text;
            Ropa.Marca = MarcatextBox.Text;
            Ropa.Precio = Convert.ToDecimal(PrecionumericUpDown.Value);
            Ropa.Inventario = Convert.ToInt32(InventariotextBox.Text);

            return Ropa;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Ropas Ropa = Llenaclase();


            if (validar(2))
            {
                MessageBox.Show("llenar campo");
            }
            else
            {
                if (IdnumericUpDown.Value == 0)
                {
                    paso = BLL.RopasBLL.Guardar(Ropa);
                }
                else
                {
                    var P = BLL.RopasBLL.Buscar(Convert.ToInt32(IdnumericUpDown.Value));
                    if (P != null)
                    {
                        paso = BLL.RopasBLL.Modificar(Ropa);
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
                    MessageBox.Show("No se pudo Guardar!",
                        "trata de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (validar(1))
            {
                MessageBox.Show("llenar los campos");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                Ropas Ropa = BLL.RopasBLL.Buscar(id);

                if (Ropa != null)
                {
                    IdnumericUpDown.Value = Ropa.RopaId;
                    DescripciontextBox.Text = Ropa.Descripcion;
                    SizetextBox.Text = Ropa.Size;
                    MarcatextBox.Text = Ropa.Marca;
                    PrecionumericUpDown.Value = Ropa.Precio;
                    InventariotextBox.Text = Ropa.Inventario.ToString();

                }
                else
                {
                    MessageBox.Show("No Fue Encontrado!",
                        "trata de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider1.Clear();
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (validar(1))
            {
                MessageBox.Show("llenar los campos");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);

                if (BLL.RopasBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!",
                        "Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se Pudo Eliminar!",
                        "trata de nuevo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider1.Clear();
            }
        }
    }
}
