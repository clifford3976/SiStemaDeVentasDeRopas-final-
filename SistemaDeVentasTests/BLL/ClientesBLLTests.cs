using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SistemaDeVentas.BLL.Tests
{
    [TestClass()]
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Clientes clientes = new Clientes();
            clientes.ClienteId = 1;
            clientes.Nombre = "Jay";
            clientes.Direccion = "Salcedo";
            clientes.Cedula = "005181282";
            clientes.Telefono = "2562265260";
            clientes.Devuelta = 500;

            paso = ClientesBLL.Guardar(clientes);
            Assert.AreEqual(paso, true);

        }

       

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Clientes clientes = new Clientes();
            clientes.ClienteId = 3;
            clientes.Nombre = "Jay";
            clientes.Direccion = "Castillo";
            clientes.Cedula = "05562160";
            clientes.Telefono = "2562265260";
            clientes.Devuelta = 450;

            paso = ClientesBLL.Modificar(clientes);
            Assert.AreEqual(paso, true);

           
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 3;
            Clientes clientes = new Clientes();
            clientes = ClientesBLL.Buscar(id);
            Assert.IsNotNull(clientes);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var Lista = ClientesBLL.GetList(x => true);
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 3;
            paso = ClientesBLL.Eliminar(id);
            Assert.AreEqual(paso,false);
        }
    }
}