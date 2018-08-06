using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SistemaDeVentas.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = 1;
            usuarios.Nombre = "Jay";
            usuarios.NombreUsuario = "Clifford";
            usuarios.Contrasena = "123456";

            paso = UsuariosBLL.Guardar(usuarios);
            Assert.AreEqual(paso, true);
        }


        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = 2;
            usuarios.Nombre = "CIJAY";
            usuarios.NombreUsuario = "Millien";
            usuarios.Contrasena = "023489";

            paso = UsuariosBLL.Modificar(usuarios);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Usuarios usuarios = new Usuarios();
            usuarios = UsuariosBLL.Buscar(id);
            Assert.IsNotNull(usuarios);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var Lista = UsuariosBLL.GetList(x => true);
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 3;
            paso = UsuariosBLL.Eliminar(id);
            Assert.AreEqual(paso, false);
        }

    }
}