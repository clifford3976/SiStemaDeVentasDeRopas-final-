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
    public class FacturasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Facturas facturas = new Facturas();
            facturas.ClienteId = 1;
            facturas.FacturaId = 2;
            facturas.Fecha = DateTime.Now;
            facturas.ITBIS = 108;
            facturas.SubTotal = 500;
            facturas.Total = 608;
            facturas.Recibido = 1000;
            facturas.Devuelta = 392;
            
            paso = FacturasBLL.Guardar(facturas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {

            bool paso = false;
            Facturas facturas = new Facturas();
            facturas.ClienteId = 4;
            facturas.FacturaId = 3;
            facturas.Fecha = DateTime.Now;
            facturas.ITBIS = 250;
            facturas.SubTotal = 5000;
            facturas.Total = 5250;
            facturas.Recibido = 6000;
            facturas.Devuelta = 750;

            paso = FacturasBLL.Modificar(facturas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 3;
            Facturas facturas = new Facturas();
            facturas = FacturasBLL.Buscar(id);
            Assert.IsNotNull(facturas);
        }

       
        [TestMethod()]
        public void GetListTest()
        {
           
            var Lista = FacturasBLL.GetList(x => true);
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            int id = 3;
            paso = FacturasBLL.Eliminar(id);
            Assert.AreEqual(paso, false);
        }

    }
}