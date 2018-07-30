using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SistemaDeVentas.Entidades
{
    public class FacturaDetalle
    {
        [Key]
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int UsuarioId { get; set; }
        public int RopaId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int Importe { get; set; }
        public string Ropa { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey("RopaId")]
        public virtual Ropas Ropas { get; set; }

        public FacturaDetalle()
        {
            Id = 0;
            FacturaId = 0;
        }

        public FacturaDetalle(int id, int facturaId, int usuarioId, int ropaId, int cantidad, int precio,int importe, string ropa,int clienteId )
        {
            Id = id;
            FacturaId = facturaId;
            UsuarioId = usuarioId;
            RopaId = ropaId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
            Ropa = ropa;
            ClienteId = clienteId;

        }




    }
}

