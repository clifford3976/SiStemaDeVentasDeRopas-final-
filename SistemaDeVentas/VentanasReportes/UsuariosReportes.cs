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
    public partial class UsuariosReportes : Form
    {
        List<Usuarios> datos = null;
        public UsuariosReportes(List<Usuarios> usuarios)
        {
            InitializeComponent();
            datos = usuarios;
        }

        private void UsuariosViewer_Load(object sender, EventArgs e)
        {
            ReportesDeUsuarios reportesDeUsuarios = new ReportesDeUsuarios();
            reportesDeUsuarios.SetDataSource(datos);

            UsuariosViewer.ReportSource = reportesDeUsuarios;
            UsuariosViewer.Refresh();
        }
    }
}
