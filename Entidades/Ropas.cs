using System.ComponentModel.DataAnnotations;


namespace Entidades
{
    public class Ropas
    {
        [Key]
        public int RopaId { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Size { get; set; }
        public string Marca { get; set; }
        public decimal Inventario { get; set; }

        public Ropas()
        {
            RopaId = 0;
            Descripcion = string.Empty;
            Precio = 0;
            Size = string.Empty;
            Marca = string.Empty;
            Inventario = 0;
        }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
