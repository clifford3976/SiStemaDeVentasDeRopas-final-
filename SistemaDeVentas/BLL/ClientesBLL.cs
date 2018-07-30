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
    public class ClientesBLL
    {
        public static bool Guardar(Clientes Cliente)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.Cliente.Add(Cliente) != null)
                {
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
                Clientes Cliente = contexto.Cliente.Find(id);

                if (Cliente != null)
                {
                    contexto.Entry(Cliente).State = EntityState.Deleted;
                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }


            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }



        public static bool Modificar(Clientes Cliente)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Cliente).State = EntityState.Modified;

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



        public static Clientes Buscar(int id)
        {

            Clientes Cliente = new Clientes();
            Contexto contexto = new Contexto();

            try
            {
                Cliente = contexto.Cliente.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Cliente;

        }



        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> expression)
        {
            List<Clientes> Cliente = new List<Clientes>();
            Contexto contexto = new Contexto();

            try
            {
                Cliente = contexto.Cliente.Where(expression).ToList();
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return Cliente;
        }
    }
}
