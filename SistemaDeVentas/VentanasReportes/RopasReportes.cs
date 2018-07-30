using SistemaDeVentas.Entidades;
using SistemaDeVentas.UI.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaDeVentas.VentanasReportes
{
    public partial class RopasReportes : Form
    {
        List<Ropas> datos = null;

        public RopasReportes(List<Ropas> ropas)
        {
            InitializeComponent();
            datos = ropas;
        }

        private void RopasViewer_Load(object sender, EventArgs e)
        {
            ReportesDeRopas reportesDeRopas = new ReportesDeRopas();
            reportesDeRopas.SetDataSource(datos);

            RopasViewer.ReportSource = reportesDeRopas;
            RopasViewer.Refresh();
        }
    }
}
