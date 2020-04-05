using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp2.Data;
using ProyectoFinalAp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Controllers
{
    public class ControllersCategoria
    {
        public bool Guardar(Categorias categorias)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (categorias.IdCategoria == 0)
                {
                    paso = Insertar(categorias);

                }
                else
                {
                    paso = Modificar(categorias);

                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Insertar(Categorias categorias)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.categorias.Add(categorias);
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return paso;
        }

        private bool Modificar(Categorias categorias)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Categorias categoria = contexto.categorias.Find(categorias.IdCategoria);
                if (categoria != null)
                {
                    contexto = new Contexto();
                    contexto.Entry(categoria).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Categorias Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Categorias categoria = new Categorias();

            try
            {
                categoria = contexto.categorias.Find(id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return categoria;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Categorias categoria = new Categorias();

            try
            {
                categoria = contexto.categorias.Find(id);
                contexto.Entry(categoria).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return paso;
        }

        public List<Categorias> GetList(Expression<Func<Categorias, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Categorias> lista;

            try
            {
                lista = contexto.categorias.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return lista;
        }
    }
}
