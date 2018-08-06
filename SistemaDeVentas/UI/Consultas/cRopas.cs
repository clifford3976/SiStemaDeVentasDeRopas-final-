
using Entidades;
using SistemaDeVentas.VentanasReportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace SistemaDeVentas.UI.Consultas
{
    public partial class cRopas : Form
    {
        List<Ropas> ropas = new List<Ropas>();
        public cRopas()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Ropas, bool>> filtro = x => true;

            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://Id

                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Debe Digitar un Numero!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        int id = Convert.ToInt32(CriteriotextBox.Text);

                        filtro = x => x.RopaId == id;

                        if (BLL.RopasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este ID, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }


                    break;

                case 1://Descripcion

                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(3))
                    {
                        MessageBox.Show("Debe Digitar una Descripcion!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        filtro = x => x.Descripcion.Contains(CriteriotextBox.Text);

                        if (BLL.RopasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Esta Descripcion, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;

                case 2://Precio

                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Debe Digitar un Numero!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        decimal precio = Convert.ToDecimal(CriteriotextBox.Text);
                        filtro = x => x.Precio == precio;


                        if (BLL.RopasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este precio, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;

                case 3://Size

                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(3))
                    {
                        MessageBox.Show("Debe Digitar un size!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        
                        filtro = x => x.Size.Contains(CriteriotextBox.Text);


                        if (BLL.RopasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Este size, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }



                    break;

                case 4://marca
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(3))
                    {
                        MessageBox.Show("Debe Digitar una marca!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {

                        filtro = x => x.Marca.Contains(CriteriotextBox.Text);


                        if (BLL.RopasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("Esta marca, No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    break;

                case 5://Inventario
                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Debe Digitar un Numero!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        decimal Invetario = Convert.ToDecimal(CriteriotextBox.Text);
                        filtro = x => x.Inventario == Invetario;


                        if (BLL.RopasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("No  hay Existencia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    break;

                case 6://Todo
                    filtro = x => true;
                    break;
            }


            ropas = BLL.RopasBLL.GetList(filtro);
            RopasdataGridView.DataSource = ropas;
            CriteriotextBox.Clear();
            errorProvider1.Clear();
        }

        private bool Validar(int error)
        {
            bool paso = false;
            int num = 0;

            if (error == 1 && string.IsNullOrEmpty(CriteriotextBox.Text))
            {
                errorProvider1.SetError(CriteriotextBox, "Por Favor, LLenar Casilla!");
                paso = true;
            }
            if (error == 2 && int.TryParse(CriteriotextBox.Text, out num) == false)
            {
                errorProvider1.SetError(CriteriotextBox, "Debe Digitar un Numero");
                paso = true;
            }

            if (error == 3 && int.TryParse(CriteriotextBox.Text, out num) == true)
            {
                errorProvider1.SetError(CriteriotextBox, "Debe Digitar Caracteres");
                paso = true;
            }

            return paso;
        }

        private void Reportebutton_Click(object sender, EventArgs e)
        {
            if(ropas.Count == 0)
            {
                MessageBox.Show("no hay datos");
            }
            RopasReportes ropasReportes = new RopasReportes(ropas);
            ropasReportes.ShowDialog();
        }
    }
}
