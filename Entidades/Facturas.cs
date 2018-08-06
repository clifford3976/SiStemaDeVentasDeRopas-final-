using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ITBIS { get; set; }
        public decimal Total { get; set; }
        public decimal Recibido { get; set; }
        public decimal Devuelta { get; set; }

        public virtual ICollection<FacturaDetalle> Detalle { get; set; }

        public Facturas()
        {
            this.Detalle = new List<FacturaDetalle>();

            FacturaId = 0;
            Fecha = DateTime.Now;
            SubTotal = 0;
            ITBIS = 0;
            Total = 0;
            Recibido = 0;
            Devuelta = 0;
        }

        public void AgregarDetalle(int id, int facturaId, int usuarioId, int ropaId, int cantidad, int precio, int importe, string ropa, int clienteId)
        {
            this.Detalle.Add(new FacturaDetalle(id, facturaId, usuarioId, ropaId, cantidad, precio, importe,ropa,clienteId));
        }

    }
}
