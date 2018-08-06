using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace SistemaDeVentas.BLL.Tests
{
    [TestClass()]
    public class EntradaRopasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            EntradaRopas entradaRopas = new EntradaRopas();
            entradaRopas.EntradaId = 1;
            entradaRopas.Fecha = DateTime.Now;
            entradaRopas.Cantidad = 10;
            entradaRopas.RopaId = 3;
            

            paso = EntradaRopasBLL.Guardar(entradaRopas);
            Assert.AreEqual(paso, true);
        }

       

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            EntradaRopas entradaRopas = new EntradaRopas();
            entradaRopas.EntradaId = 3;
            entradaRopas.Fecha = DateTime.Now;
            entradaRopas.Cantidad = 5;
            entradaRopas.RopaId = 10;
           

            paso = EntradaRopasBLL.Modificar(entradaRopas);
            Assert.AreEqual(paso, true);

        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 3;
            EntradaRopas entradaRopas = new EntradaRopas();
            entradaRopas = EntradaRopasBLL.Buscar(id);
            Assert.IsNotNull(entradaRopas);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var Lista = EntradaRopasBLL.GetList(x => true);
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 3;
            paso = EntradaRopasBLL.Eliminar(id);
            Assert.AreEqual(paso, false);
        }
    }
}