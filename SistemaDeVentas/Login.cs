using SistemaDeVentas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace SistemaDeVentas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            int paso = 0;
            Expression<Func<Usuarios, bool>> filtrar = x => true;
            List<Usuarios> user = new List<Usuarios>();

            limpiarError();

            if (UsuariologtextBox.Text == string.Empty)
            {
                paso = 1;
                LogInerrorProvider.SetError(UsuariologtextBox, "Incorrecto");

            }
            if (ClavetextBox.Text == string.Empty)
            {
                paso = 1;
                LogInerrorProvider.SetError(ClavetextBox, "Incorrecto");

            }
            if (paso == 1)
            {
                MessageBox.Show("Campos Vacios!!");
                return;
            }

            filtrar = t => t.NombreUsuario.Equals(UsuariologtextBox.Text);
            user = BLL.UsuariosBLL.GetList(filtrar);

            if (user.Exists(x => x.NombreUsuario == UsuariologtextBox.Text) && user.Exists(x => x.Contrasena == ClavetextBox.Text))
            {
                foreach (var item in BLL.UsuariosBLL.GetList(x => x.NombreUsuario == UsuariologtextBox.Text))
                {
                    BLL.FacturasBLL.NombreLogin(item.Nombre, item.UsuarioId);
                }

                MenuPrincipal abrir = new MenuPrincipal();
                abrir.Show();
                this.Hide();




            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrecta!!");
                LogInerrorProvider.SetError(ClavetextBox, "Incorrecto");
                LogInerrorProvider.SetError(UsuariologtextBox, "Incorrecto");

            }
            ClavetextBox.MaxLength = 15;

        }

        void limpiarError()
        {
            LogInerrorProvider.Clear();
            LogInerrorProvider.Clear();
        }
    }
}
