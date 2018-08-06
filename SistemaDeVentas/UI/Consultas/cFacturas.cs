
using Entidades;
using SistemaDeVentas.VentanasReportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace SistemaDeVentas.UI.Consultas
{
    public partial class cFacturas : Form
    {
        List<Facturas> facturas = new List<Facturas>();
        public cFacturas()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Facturas, bool>> filtro = x => true;

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
                            filtro = x => x.FacturaId == id && (desdedateTimePicker.Value >= x.Fecha && HastadateTimePicker.Value <= x.Fecha);
                        }
                        else
                        {
                            filtro = x => x.FacturaId == id;
                        }


                        if (BLL.FacturasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show("No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }


                    break;

                case 1://Clienteid

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
                        int clienteId = Convert.ToInt32(CriteriotextBox.Text);

                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.ClienteId == clienteId && (desdedateTimePicker.Value >= x.Fecha && HastadateTimePicker.Value <= x.Fecha);
                        }
                        else
                        {
                            filtro = x => x.ClienteId == clienteId;
                        }



                        if (BLL.FacturasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show(" No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;

                case 2://Subtotal

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
                        decimal subtotal = Convert.ToDecimal(CriteriotextBox.Text);

                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.SubTotal == subtotal && (desdedateTimePicker.Value >= x.Fecha && HastadateTimePicker.Value <= x.Fecha);

                        }
                        else
                        {

                            filtro = x => x.SubTotal == subtotal;
                        }

                        if (BLL.FacturasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show(" No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;

                case 3://ITBIS

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
                        decimal itbis = Convert.ToDecimal(CriteriotextBox.Text);

                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.ITBIS == itbis && (desdedateTimePicker.Value >= x.Fecha && HastadateTimePicker.Value <= x.Fecha);
                        }
                        else
                        {
                            filtro = x => x.ITBIS == itbis;
                        }

                        if (BLL.FacturasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show(" No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    break;

                case 4://Total

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
                        decimal total = Convert.ToDecimal(CriteriotextBox.Text);
                        if (FechacheckBox.Checked == true)
                        {
                            filtro = x => x.Total == total && (desdedateTimePicker.Value >= x.Fecha && HastadateTimePicker.Value <= x.Fecha);
                        }
                        else
                        {
                            filtro = x => x.Total == total;
                        }


                        if (BLL.FacturasBLL.GetList(filtro).Count() == 0)
                        {
                            MessageBox.Show(" No Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    break;

                case 5://todo
                    filtro = x => true;
                    break;


            }

            facturas = BLL.FacturasBLL.GetList(filtro);
            FacturasdataGridView.DataSource = facturas;
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

        private void reportebutton_Click(object sender, EventArgs e)
        {
            if(facturas.Count == 0)
            {
                MessageBox.Show("no hay datos");
            }
            FacturasReportes facturasReportes = new FacturasReportes(facturas);
            FacturaDetalleReportes facturaDetalleReportes = new FacturaDetalleReportes(facturas);
            facturasReportes.ShowDialog();
        }
    }
}
