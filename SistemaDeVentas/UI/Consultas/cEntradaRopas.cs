using SistemaDeVentas.Entidades;
using SistemaDeVentas.VentanasReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace SistemaDeVentas.UI.Consultas
{
    public partial class cEntradaRopas : Form
    {
        List<EntradaRopas> entradaRopas = new List<EntradaRopas>();

        public cEntradaRopas()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<EntradaRopas, bool>> filtro = x => true;

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

                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.EntradaId == id && (desdedateTimePicker.Value >= x.Fecha && HastadateTimePicker.Value <= x.Fecha);
                        }
                        else
                        {
                            filtro = x => x.EntradaId == id;
                        }


                        if (BLL.EntradaRopasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }


                    break;

                case 1://RopaId

                    if (Validar(1))
                    {
                        MessageBox.Show("Favor Llenar Casilla ", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Validar(2))
                    {
                        MessageBox.Show("Debe Digitar un numero!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        int ropaId = Convert.ToInt32(CriteriotextBox.Text);

                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.RopaId == ropaId && (desdedateTimePicker.Value >= x.Fecha && HastadateTimePicker.Value <= x.Fecha);
                        }
                        else
                        {
                            filtro = x => x.RopaId == ropaId;
                        }



                        if (BLL.EntradaRopasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show(" No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;

                case 2://Cantidad

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
                        decimal cantidad = Convert.ToDecimal(CriteriotextBox.Text);

                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.Cantidad == cantidad && (desdedateTimePicker.Value >= x.Fecha && HastadateTimePicker.Value <= x.Fecha);

                        }
                        else
                        {

                            filtro = x => x.Cantidad == cantidad;
                        }

                        if (BLL.EntradaRopasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show(" No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;

              
                case 3: //Todo
                    filtro = x => true;
                    break;


            }


            entradaRopas = BLL.EntradaRopasBLL.GetList(filtro);
            EntradaRopasdataGridView.DataSource = entradaRopas;
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
            if(entradaRopas.Count == 0)
            {
                MessageBox.Show("no hay datos");
                return;
            }
            EntradaRopasReportes entradaRopasReportes = new EntradaRopasReportes(entradaRopas);
            entradaRopasReportes.ShowDialog();
        }
    }
 }
