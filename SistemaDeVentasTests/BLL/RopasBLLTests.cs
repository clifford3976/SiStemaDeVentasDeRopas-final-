using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeVentas.BLL;
using SistemaDeVentas.DAL;
using SistemaDeVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaDeVentas.BLL.Tests
{
    [TestClass()]
    public class RopasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Ropas ropas = new Ropas();
            ropas.RopaId = 1;
            ropas.Descripcion = "tshirt";
            ropas.Size = "XL";
            ropas.Marca = "Levis";
            ropas.Precio = 250;
            ropas.Inventario = 5;

            paso = RopasBLL.Guardar(ropas);
            Assert.AreEqual(paso, true);
        }

      

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Ropas ropas = new Ropas();
            ropas.RopaId = 4;
            ropas.Descripcion = "tshirt";
            ropas.Size = "XL";
            ropas.Marca = "Levis";
            ropas.Precio = 450;
            ropas.Inventario = 9;

            paso = RopasBLL.Modificar(ropas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 4;
            Ropas ropas = new Ropas();
            ropas = RopasBLL.Buscar(id);
            Assert.IsNotNull(ropas);
        }

        [TestMethod()]
        public void GetListTest()
        {
            

            var Lista = RopasBLL.GetList(x => true);
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 4;
            paso = RopasBLL.Eliminar(id);
            Assert.AreEqual(paso, false);
        }

    }
}