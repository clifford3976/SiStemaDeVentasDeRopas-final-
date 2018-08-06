using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace BLL
{
    public class EntradaRopasBLL
    {
        public static bool Guardar(EntradaRopas EntradaRopa)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.EntradaRopa.Add(EntradaRopa) != null)
                {
                    Ropas ropa = BLL.RopasBLL.Buscar(EntradaRopa.RopaId);
                    ropa.Inventario += EntradaRopa.Cantidad;
                    BLL.RopasBLL.Modificar(ropa);

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
                EntradaRopas EntradaRopa = contexto.EntradaRopa.Find(id);

                if (EntradaRopa != null)
                {
                    Ropas ropa = BLL.RopasBLL.Buscar(EntradaRopa.RopaId);
                    ropa.Inventario -= EntradaRopa.Cantidad;
                    BLL.RopasBLL.Modificar(ropa);

                    contexto.Entry(EntradaRopa).State = EntityState.Deleted;
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



        public static bool Modificar(EntradaRopas EntradaRopa)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                EntradaRopas ant = BLL.EntradaRopasBLL.Buscar(EntradaRopa.EntradaId);
                int resta;
                resta = EntradaRopa.Cantidad - ant.Cantidad;

                Ropas ropa = BLL.RopasBLL.Buscar(EntradaRopa.RopaId);
                ropa.Inventario += resta;
                BLL.RopasBLL.Modificar(ropa);

                contexto.Entry(EntradaRopa).State = EntityState.Modified;

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




        public static EntradaRopas Buscar(int id)
        {

            EntradaRopas EntradaRopa = new EntradaRopas();
            Contexto contexto = new Contexto();

            try
            {
                EntradaRopa = contexto.EntradaRopa.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return EntradaRopa;

        }



        public static List<EntradaRopas> GetList(Expression<Func<EntradaRopas, bool>> expression)
        {
            List<EntradaRopas> EntradaRopa = new List<EntradaRopas>();
            Contexto contexto = new Contexto();

            try
            {
                EntradaRopa = contexto.EntradaRopa.Where(expression).ToList();
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return EntradaRopa;
        }


    }
}
