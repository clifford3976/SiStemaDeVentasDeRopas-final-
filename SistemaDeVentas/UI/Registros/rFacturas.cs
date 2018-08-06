using BLL;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaDeVentas.UI.Registros
{
    public partial class rFacturas : Form
    {

        decimal ITBIS = 0;
        decimal Total = 0;

        public rFacturas()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;

        }
        public void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            CantidadnumericUpDown.Value = 0;
            TotaltextBox.Clear();

            ImportetextBox.Clear();
            SubtotaltextBox.Text = 0.ToString();
            TotaltextBox.Text = 0.ToString();
            ITBIStextBox.Text = 0.ToString();
            RecibidotextBox.Text = 0.ToString();
            DetalledataGridView.DataSource = null;

            ITBIS = 0;
            Total = 0;

            errorProvider1.Clear();
        }

        private Facturas LlenaClase()
        {
            Facturas Factura = new Facturas();

            Factura.FacturaId = Convert.ToInt32(IdnumericUpDown.Value);
            Factura.ClienteId = Convert.ToInt32(ClientecomboBox.SelectedValue);
            Factura.Fecha = FechadateTimePicker.Value;
            Factura.SubTotal = Convert.ToDecimal(SubtotaltextBox.Text);
            Factura.ITBIS = Convert.ToDecimal(ITBIStextBox.Text);
            Factura.Total = Convert.ToDecimal(TotaltextBox.Text);
            Factura.Recibido = Convert.ToDecimal(RecibidotextBox.Text);
            Factura.Devuelta = Convert.ToDecimal(RecibidotextBox.Text) - Convert.ToDecimal(TotaltextBox.Text);


            foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {

                Factura.AgregarDetalle
                    (ToInt(item.Cells["id"].Value),
                     Factura.FacturaId,
                       ToInt(item.Cells["usuarioId"].Value),
                     ToInt(item.Cells["ropaId"].Value),
                      ToInt(item.Cells["cantidad"].Value),
                       ToInt(item.Cells["precio"].Value),
                    ToInt(item.Cells["importe"].Value),
                    Convert.ToString(item.Cells["ropa"].Value),
                    ToInt(item.Cells["clienteId"].Value)



                  );
            }
            return Factura;
        }


        private void LlenarCampos(Facturas Factura)
        {
            Limpiar();
            IdnumericUpDown.Value = Factura.FacturaId;
            FechadateTimePicker.Value = Factura.Fecha;
            SubtotaltextBox.Text = Factura.SubTotal.ToString();
            ITBIStextBox.Text = Factura.ITBIS.ToString();
            TotaltextBox.Text = Factura.Total.ToString();
            RecibidotextBox.Text = Factura.Recibido.ToString();


            DetalledataGridView.DataSource = Factura.Detalle;

        }

        private void LlenarComboBox()
        {
            Repositorio<Clientes> Cliente = new Repositorio<Clientes>(new Contexto());
            ClientecomboBox.DataSource = Cliente.GetList(c => true);
            ClientecomboBox.ValueMember = "ClienteId";
            ClientecomboBox.DisplayMember = "Nombre";

            Repositorio<Usuarios> Usuario = new Repositorio<Usuarios>(new Contexto());
            UsuariocomboBox.DataSource = Usuario.GetList(c => true);
            UsuariocomboBox.ValueMember = "UsuarioId";
            UsuariocomboBox.DisplayMember = "Nombre";

            Repositorio<Ropas> Entrada = new Repositorio<Ropas>(new Contexto());
            RopascomboBox.DataSource = Entrada.GetList(c => true);
            RopascomboBox.ValueMember = "RopaId";
            RopascomboBox.DisplayMember = "Descripcion";
        }

        private void RopascomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in BLL.RopasBLL.GetList(x => x.Descripcion == RopascomboBox.Text))
            {
                PreciotextBox.Text = item.Precio.ToString();

            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<FacturaDetalle> Detalle = new List<FacturaDetalle>();


            if (DetalledataGridView.DataSource != null)
            {
                Detalle = (List<FacturaDetalle>)DetalledataGridView.DataSource;
            }



            foreach (var item in BLL.RopasBLL.GetList(x => x.Inventario < CantidadnumericUpDown.Value))
            {

                MessageBox.Show("No hay ",
                    "validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (string.IsNullOrEmpty(ImportetextBox.Text))
            {
                MessageBox.Show("llena cantidad",
                    "validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Detalle.Add(
                    new FacturaDetalle(id: 0,
                    facturaId: (int)Convert.ToInt32(IdnumericUpDown.Value),
                    usuarioId: (int)UsuariocomboBox.SelectedValue,
                       ropaId: (int)RopascomboBox.SelectedValue,
                        cantidad: (int)Convert.ToDecimal(CantidadnumericUpDown.Value),
                        precio: (int)Convert.ToDecimal(PreciotextBox.Text),
                         importe: (int)Convert.ToDecimal(ImportetextBox.Text),
                            ropa: (string)BLL.RopasBLL.RetornarDescripcion(RopascomboBox.Text),
                            clienteId: (int)ClientecomboBox.SelectedValue
                       
                        
                       
                        

                    ));





                DetalledataGridView.DataSource = null;
                DetalledataGridView.DataSource = Detalle;


            }

            decimal SubTotal = 0;

            foreach (var item in Detalle)
            {
                SubTotal += item.Importe;
            }


            SubtotaltextBox.Text = SubTotal.ToString();


            ITBIS = BLL.FacturasBLL.CalcularITBIS(Convert.ToDecimal(SubtotaltextBox.Text));

            ITBIStextBox.Text = ITBIS.ToString();

            Total = BLL.FacturasBLL.Total(Convert.ToDecimal(SubtotaltextBox.Text), Convert.ToDecimal(ITBIStextBox.Text));

            TotaltextBox.Text = Total.ToString();


        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ImportetextBox.Text = BLL.FacturasBLL.CalcularImporte(Convert.ToDecimal(PreciotextBox.Text), Convert.ToInt32(CantidadnumericUpDown.Value)).ToString();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Facturas Factura = BLL.FacturasBLL.Buscar(id);

            if (Factura != null)
            {
                LlenarCampos(Factura);

            }
            else
                MessageBox.Show("No se encontro!", "buscar de nuevo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {


                MessageBox.Show("llenar campos!",
                    "Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                if (BLL.FacturasBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!",
                        "Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!",
                        "trata de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(2))
            {
                MessageBox.Show("agreagar ropas al grid",
                    "validar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Suficiente())
            {
                MessageBox.Show("Cantidad recibida no es suficiente. \nIngrese una cantidad Mayor",
                    "Errror",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                Facturas Factura = LlenaClase();
                bool Paso = false;



                if (IdnumericUpDown.Value == 0)
                {
                    Paso = BLL.FacturasBLL.Guardar(Factura);
                    errorProvider1.Clear();
                }
                else
                {
                    var P = BLL.FacturasBLL.Buscar(Convert.ToInt32(IdnumericUpDown.Value));
                    if (P != null)
                    {
                        Paso = BLL.FacturasBLL.Modificar(Factura);
                    }

                    errorProvider1.Clear();
                }

                if (Paso)
                {

                    MessageBox.Show("Guardado!!", "Exitosamente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo guardar!!",
                        "trata de nuevo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null)
            {

                List<FacturaDetalle> Detalle = (List<FacturaDetalle>)DetalledataGridView.DataSource;


                Detalle.RemoveAt(DetalledataGridView.CurrentRow.Index);


                decimal SubTotal = 0;

                foreach (var item in Detalle)
                {
                    SubTotal -= item.Importe;
                }

                SubTotal *= (-1);
                SubtotaltextBox.Text = SubTotal.ToString();



                ITBIS = BLL.FacturasBLL.CalcularITBIS(Convert.ToDecimal(SubtotaltextBox.Text));
                ITBIStextBox.Text = ITBIS.ToString();

                Total = BLL.FacturasBLL.Total(Convert.ToDecimal(SubtotaltextBox.Text), Convert.ToDecimal(ITBIStextBox.Text));
                TotaltextBox.Text = Total.ToString();

                

                DetalledataGridView.DataSource = null;
                DetalledataGridView.DataSource = Detalle;

            }
        }

        private bool Validar(int error)
        {
            bool paso = false;



            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider1.SetError(IdnumericUpDown,
                   "No dejes id vacio");
                paso = true;
            }
            if (error == 2 && string.IsNullOrWhiteSpace(TotaltextBox.Text))
            {
                errorProvider1.SetError(TotaltextBox,
                   "No dejes el total vacio");
                paso = true;
            }
            if (error == 2 && string.IsNullOrWhiteSpace(SubtotaltextBox.Text))
            {
                errorProvider1.SetError(SubtotaltextBox,
                   "No dejes el subtotal vacio");
                paso = true;
            }
            if (error == 2 && string.IsNullOrWhiteSpace(ITBIStextBox.Text))
            {
                errorProvider1.SetError(ITBIStextBox,
                   "No dejes el Itbis vacio");
                paso = true;
            }

            if (error == 2 && DetalledataGridView.RowCount == 0)
            {
                errorProvider1.SetError(DetalledataGridView,
                    "siempre agregue una ropa");
                paso = true;
            }

            if (error == 3 && string.IsNullOrEmpty(ImportetextBox.Text))
            {
                errorProvider1.SetError(ImportetextBox,
                    "siempre agregue una ropa");
                paso = true;
            }

            return paso;
        }

      

        private decimal ToDecim(object valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor.ToString(), out retorno);
            return retorno;

        }

        private bool Suficiente()
        {
            bool paso = false;

            decimal recibido = ToDecim(RecibidotextBox.Text);
            decimal total = ToDecim(TotaltextBox.Text);

            if (recibido < total)
            {
                MessageBox.Show("el efectivo no es sufuciente!!",
                        "trata de nuevo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                paso = true;
            }

            return paso;
        }

      
    }
}
