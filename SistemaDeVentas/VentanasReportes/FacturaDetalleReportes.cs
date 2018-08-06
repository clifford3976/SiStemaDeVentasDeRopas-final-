
using Entidades;
using SistemaDeVentas.UI.Reportes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaDeVentas.VentanasReportes
{
    public partial class FacturaDetalleReportes : Form
    {
        List<Facturas> datos = null;

        public FacturaDetalleReportes(List<Facturas> facturas)
        {
            InitializeComponent();
            datos = facturas;
        }

        private void FacturadetalleViewer_Load(object sender, EventArgs e)
        {
            ReportesDeFacturas reportesDeFacturas = new ReportesDeFacturas();
            reportesDeFacturas.SetDataSource(datos);

            FacturadetalleViewer.ReportSource = reportesDeFacturas;
            FacturadetalleViewer.Refresh();
        }
    }
}
