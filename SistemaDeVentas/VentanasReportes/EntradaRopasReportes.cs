
using Entidades;
using SistemaDeVentas.UI.Reportes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaDeVentas.VentanasReportes
{
    public partial class EntradaRopasReportes : Form
    {
        List<EntradaRopas> datos = null;

        public EntradaRopasReportes(List<EntradaRopas> entradaRopa)
        {
            InitializeComponent();
            datos = entradaRopa;
        }

        private void EntradaRopasViewer_Load(object sender, EventArgs e)
        {
            ReportesDeEntradaRopas reportesDeEntradaRopas = new ReportesDeEntradaRopas();
            reportesDeEntradaRopas.SetDataSource(datos);

            EntradaRopasViewer.ReportSource = reportesDeEntradaRopas;
            EntradaRopasViewer.Refresh();
        }
    }
}
