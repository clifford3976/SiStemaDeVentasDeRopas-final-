
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace BLL
{
    public class RopasBLL
    {
        public static bool Guardar(Ropas Ropa)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.Ropa.Add(Ropa) != null)
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
                Ropas Ropa = contexto.Ropa.Find(id);

                if (Ropa != null)
                {
                    contexto.Entry(Ropa).State = EntityState.Deleted;
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



        public static bool Modificar(Ropas Ropa)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Ropa).State = EntityState.Modified;

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



        public static Ropas Buscar(int id)
        {

            Ropas Ropa = new Ropas();
            Contexto contexto = new Contexto();

            try
            {
                Ropa = contexto.Ropa.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Ropa;

        }



        public static List<Ropas> GetList(Expression<Func<Ropas, bool>> expression)
        {
            List<Ropas> Ropa = new List<Ropas>();
            Contexto contexto = new Contexto();

            try
            {
                Ropa = contexto.Ropa.Where(expression).ToList();
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return Ropa;
        }

       public static string RetornarDescripcion(string nombre)
        {
            string descripcion = string.Empty;
            var lista = GetList(x => x.Descripcion.Equals(nombre));
            foreach (var item in lista)
            {
                descripcion = item.Descripcion;
            }

            return descripcion;
        }


    }
}
