using SistemaDeVentas.DAL;
using SistemaDeVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SistemaDeVentas.BLL
{
    public class FacturasBLL
    {
        private static Usuarios user = new Usuarios();

        public static bool Guardar(Facturas Factura)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            Clientes Cliente = new Clientes();
            try
            {
                if (contexto.Factura.Add(Factura) != null)
                {

                    foreach (var item in Factura.Detalle)
                    {
                        contexto.Ropa.Find(item.RopaId).Inventario -= item.Cantidad;
                    }


                    contexto.Cliente.Find(Factura.ClienteId).Devuelta += Factura.Recibido - Factura.Total;

                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }



        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Facturas Factura = contexto.Factura.Find(id);


                if (Factura != null)
                {
                    foreach (var item in Factura.Detalle)
                    {
                        contexto.Ropa.Find(item.RopaId).Inventario += item.Cantidad;

                    }
                    contexto.Cliente.Find(Factura.ClienteId).Devuelta -= Factura.Recibido - Factura.Total;

                    Factura.Detalle.Count();
                    contexto.Factura.Remove(Factura);
                }




                if (contexto.SaveChanges() > 0)
                {

                    paso = true;
                }
                contexto.Dispose();


            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }




        public static Facturas Buscar(int id)
        {
            Facturas Factura = new Facturas();
            Contexto contexto = new Contexto();

            try
            {
                Factura = contexto.Factura.Find(id);
                if (Factura != null)
                {
                    Factura.Detalle.Count();

                    foreach (var item in Factura.Detalle)
                    {

                        string s = item.Ropas.Descripcion;
                    }

                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Factura;
        }


        public static bool Modificar(Facturas Factura)
        {

            bool paso = false;
            Contexto contexto = new Contexto();



            try
            {
                var factura = BLL.FacturasBLL.Buscar(Factura.FacturaId);


                if (factura != null)
                {


                    foreach (var item in factura.Detalle)
                    {

                        contexto.Ropa.Find(item.RopaId).Inventario += item.Cantidad;



                        if (!Factura.Detalle.ToList().Exists(v => v.Id == item.Id))
                        {
                            

                            item.Ropas = null;
                            contexto.Entry(item).State = EntityState.Deleted;
                        }



                    }


                    foreach (var item in Factura.Detalle)
                    {
                        contexto.Ropa.Find(item.RopaId).Inventario -= item.Cantidad;



                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }





                    Facturas Anterior = BLL.FacturasBLL.Buscar(Factura.FacturaId);


                    //identificar la diferencia ya sea restada o sumada
                    decimal diferencia;

                    diferencia = Factura.Devuelta - Anterior.Devuelta;

                    //aplicar diferencia al inventario
                    Clientes Cliente = BLL.ClientesBLL.Buscar(Factura.ClienteId);
                    Cliente.Devuelta += diferencia;
                    BLL.ClientesBLL.Modificar(Cliente);





                    contexto.Entry(Factura).State = EntityState.Modified;
                }



                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return paso;


        }



        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Facturas> Factura = new List<Facturas>();

            try
            {
                Factura = contexto.Factura.Where(expression).ToList();

                foreach (var item in Factura)
                {
                    item.Detalle.Count();
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Factura;

        }

        public static void NombreLogin(string nombre, int id)
        {
            user.Nombre = nombre;
            user.UsuarioId = id;
        }

        public static Usuarios returnUsuario()
        {
            return user;
        }

        public static decimal CalcularImporte(decimal precio, int cantidad)
        {
            return Convert.ToDecimal(precio) * Convert.ToInt32(cantidad);
        }

        public static decimal CalcularITBIS(decimal subtotal)
        {
            return Convert.ToDecimal(subtotal) * Convert.ToDecimal(0.18);
        }

        public static decimal Total(decimal subtotal, decimal ITBIS)
        {
            return Convert.ToDecimal(subtotal) + Convert.ToDecimal(ITBIS);
        }

      
    }
}
