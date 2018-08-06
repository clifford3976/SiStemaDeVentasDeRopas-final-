using System;
using System.Windows.Forms;

namespace SistemaDeVentas
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.rClientes abrir = new UI.Registros.rClientes();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void ropasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.rRopas abrir = new UI.Registros.rRopas();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void entradaRopasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.rEntradaRopas abrir = new UI.Registros.rEntradaRopas();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.rUsuarios abrir = new UI.Registros.rUsuarios();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Registros.rFacturas abrir = new UI.Registros.rFacturas();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.Consultas.cClientes abrir = new UI.Consultas.cClientes();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void ropasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.Consultas.cRopas abrir = new UI.Consultas.cRopas();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void entradaRopasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.Consultas.cEntradaRopas abrir = new UI.Consultas.cEntradaRopas();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.Consultas.cUsuarios abrir = new UI.Consultas.cUsuarios();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void facturasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.Consultas.cFacturas abrir = new UI.Consultas.cFacturas();
            abrir.MdiParent = this;
            abrir.Show();
        }
    }
}
