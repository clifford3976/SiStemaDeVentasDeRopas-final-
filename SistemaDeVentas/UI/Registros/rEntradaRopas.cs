
using BLL;
using DAL;
using Entidades;
using System;
using System.Windows.Forms;

namespace SistemaDeVentas.UI.Registros
{
    public partial class rEntradaRopas : Form
    {
        public rEntradaRopas()
        {
            InitializeComponent();
            LlenaComboBox();
        }

        private void LlenaComboBox()
        {
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>(new Contexto());
            RopacomboBox.DataSource = repositorio.GetList(c => true);
            RopacomboBox.ValueMember = "RopaId";
            RopacomboBox.DisplayMember = "Descripcion";
        }

        private bool validar(int error)
        {
            bool errores = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider1.SetError(IdnumericUpDown, "Llenar Id");
                errores = true;
            }

            if (error == 2 && CantidadnumericUpDown.Value == 0)
            {
                errorProvider1.SetError(CantidadnumericUpDown, "Llene Nombre");
                errores = true;
            }


            return errores;

        }
        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            CantidadnumericUpDown.Value = 0;


            errorProvider1.Clear();
        }
        private EntradaRopas Llenaclase()
        {
            EntradaRopas EntradaRopa = new EntradaRopas();
            EntradaRopa.EntradaId = Convert.ToInt32(IdnumericUpDown.Value);
            EntradaRopa.RopaId = (int)RopacomboBox.SelectedValue;
            EntradaRopa.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);


            return EntradaRopa;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            EntradaRopas EntradaRopa = Llenaclase();


            if (validar(2))
            {
                MessageBox.Show("llenar campos");
            }
            else
            {
                if (IdnumericUpDown.Value == 0)
                {
                    paso = BLL.EntradaRopasBLL.Guardar(EntradaRopa);
                }
                else
                {
                    var P = BLL.EntradaRopasBLL.Buscar(Convert.ToInt32(EntradaRopa));
                    if (P != null)
                    {
                        paso = BLL.EntradaRopasBLL.Modificar(EntradaRopa);
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
                MessageBox.Show("llenar campos");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                EntradaRopas EntradaRopa = BLL.EntradaRopasBLL.Buscar(id);

                if (EntradaRopa != null)
                {
                    IdnumericUpDown.Value = EntradaRopa.EntradaId;
                    RopacomboBox.SelectedValue = EntradaRopa.RopaId;
                    CantidadnumericUpDown.Value = EntradaRopa.Cantidad;



                }
                else
                {
                    MessageBox.Show("No Fue Encontrado!",
                        "buscar de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider1.Clear();
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (validar(1))
            {
                MessageBox.Show("llenar campos");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);

                if (BLL.EntradaRopasBLL.Eliminar(id))
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

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
