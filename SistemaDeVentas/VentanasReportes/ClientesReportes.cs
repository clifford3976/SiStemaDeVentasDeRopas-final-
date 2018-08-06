
using Entidades;
using SistemaDeVentas.UI.Reportes;
using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace SistemaDeVentas.VentanasReportes
{
    public partial class ClientesReportes : Form
    {
        List<Clientes> datos = null;

        public ClientesReportes(List<Clientes> clientes)
        {
            InitializeComponent();
            datos = clientes;
        }

        private void ClientesViewer_Load(object sender, EventArgs e)
        {
            ReporteDeClientes reporteDeClientes = new ReporteDeClientes();
            reporteDeClientes.SetDataSource(datos);

            ClientesViewer.ReportSource = reporteDeClientes;
            ClientesViewer.Refresh();

            
        }
    }
}
