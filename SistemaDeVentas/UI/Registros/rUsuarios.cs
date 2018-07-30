using SistemaDeVentas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaDeVentas.UI.Registros
{
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
        }

        private bool validar(int error)
        {
            bool errores = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider1.SetError(IdnumericUpDown, "Llenar Id");
                errores = true;
            }

            if (error == 2 && string.IsNullOrEmpty(NombretextBox.Text))
            {
                errorProvider1.SetError(NombretextBox, "Llene Nombre");
                errores = true;
            }
            if (error == 2 && string.IsNullOrEmpty(NombreUsuariotextBox.Text))
            {
                errorProvider1.SetError(NombreUsuariotextBox, "Llene NombreUsuario");
                errores = true;
            }
            if (error == 2 && string.IsNullOrEmpty(ContrasenatextBox.Text))
            {
                errorProvider1.SetError(ContrasenatextBox, "Llene contrasena");
                errores = true;
            }

            return errores;

        }
        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Clear();
            NombreUsuariotextBox.Clear();
            ContrasenatextBox.Clear();


            errorProvider1.Clear();
        }
        private Usuarios Llenaclase()
        {
            Usuarios Usuario = new Usuarios();
            Usuario.UsuarioId = Convert.ToInt32(IdnumericUpDown.Value);
            Usuario.Nombre = NombretextBox.Text;
            Usuario.NombreUsuario = NombreUsuariotextBox.Text;
            Usuario.Contrasena = ContrasenatextBox.Text;


            return Usuario;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (validar(1))
            {
                MessageBox.Show("llenar campo");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                Usuarios Usuario = BLL.UsuariosBLL.Buscar(id);

                if (Usuario != null)
                {
                    IdnumericUpDown.Value = Usuario.UsuarioId;
                    NombretextBox.Text = Usuario.Nombre;
                    NombreUsuariotextBox.Text = Usuario.NombreUsuario;
                    ContrasenatextBox.Text = Usuario.Contrasena;



                }
                else
                {
                    MessageBox.Show("No Fue Encontrado!",
                        "buscar de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider1.Clear();

            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (validar(1))
            {
                MessageBox.Show("llenar campo");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);

                if (BLL.UsuariosBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!",
                        "Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No Pudo Eliminar!",
                        "tratar de nuevo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider1.Clear();
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Usuarios Usuario = Llenaclase();


            if (validar(2))
            {
                MessageBox.Show("llenar campo");
            }
            else
            {
                if (IdnumericUpDown.Value == 0)
                {
                    paso = BLL.UsuariosBLL.Guardar(Usuario);
                }
                else
                {
                    var P = BLL.UsuariosBLL.Buscar(Convert.ToInt32(IdnumericUpDown.Value));
                    if (P != null)
                    {
                        paso = BLL.UsuariosBLL.Modificar(Usuario);
                    }
                }
                Limpiar();
                errorProvider1.Clear();
                if (paso)
                {
                    MessageBox.Show("Guardado!",
                        "Exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No pudo Guardar!",
                        "tratar de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
