using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class EntradaRopas
    {
        [Key]
        public int EntradaId { get; set; }
        public DateTime Fecha { get; set; }
        public int RopaId { get; set; }
        public int Cantidad { get; set; }

        public EntradaRopas()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            RopaId = 0;
            Cantidad = 0;
        }
    }
}
