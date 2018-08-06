using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace BLL
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios Usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.Usuario.Add(Usuario) != null)
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
                Usuarios Usuario = contexto.Usuario.Find(id);

                if (Usuario != null)
                {
                    contexto.Entry(Usuario).State = EntityState.Deleted;
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



        public static bool Modificar(Usuarios Usuario)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Usuario).State = EntityState.Modified;

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



        public static Usuarios Buscar(int id)
        {

            Usuarios Usuario = new Usuarios();
            Contexto contexto = new Contexto();

            try
            {
                Usuario = contexto.Usuario.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Usuario;

        }



        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> expression)
        {
            List<Usuarios> Usuario = new List<Usuarios>();
            Contexto contexto = new Contexto();

            try
            {
                Usuario = contexto.Usuario.Where(expression).ToList();
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return Usuario;
        }
    }
}
