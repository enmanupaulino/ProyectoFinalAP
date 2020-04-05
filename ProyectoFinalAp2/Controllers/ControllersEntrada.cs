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
    public class ControllersEntrada
    {
        public bool Guardar(Entradas entradas)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                if (entradas.IdEntrada == 0)
                {
                    paso = Insertar(entradas);

                }
                else
                {
                    paso = Modificar(entradas);

                }
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

        private bool Insertar(Entradas entradas)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                if (contexto.entradas.Add(entradas) != null)
                {
                    foreach (var item in entradas.Detalle)
                    {
                        contexto.productos.Find(item.IdProducto).Cantidad += item.Cantidad;
                    }
                }
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

        private bool Modificar(Entradas entradas)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Entradas EntradaAnterior = contexto.entradas.Where(e => e.IdEntrada == entradas.IdEntrada).Include(d => d.Detalle).FirstOrDefault();
                contexto = new Contexto();
                foreach (var item in EntradaAnterior.Detalle)
                {
                    if (!entradas.Detalle.Any(d => d.IdEntradaDetalle == item.IdEntradaDetalle))
                    {
                        contexto.productos.Find(item.IdProducto).Cantidad -= item.Cantidad;
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in entradas.Detalle)
                {
                    if (item.IdEntradaDetalle == 0)
                    {
                        contexto.productos.Find(item.IdProducto).Cantidad += item.Cantidad;
                        contexto.Entry(item).State = EntityState.Added;

                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;

                    }
                }
                contexto.Entry(entradas).State = EntityState.Modified;
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

        public Entradas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entradas entrada = new Entradas();

            try
            {
                entrada = contexto.entradas.Where(e => e.IdEntrada == id).Include(d => d.Detalle).FirstOrDefault();

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }
            return entrada;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Entradas entradas = contexto.entradas.Where(e => e.IdEntrada == id).Include(d => d.Detalle).FirstOrDefault();

                foreach (var item in entradas.Detalle)
                {
                    contexto.productos.Find(item.IdProducto).Cantidad -= item.Cantidad;

                }
                contexto.entradas.Remove(entradas);
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

        public List<Entradas> GetList(Expression<Func<Entradas, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Entradas> lista;

            try
            {
                lista = contexto.entradas.Where(expression).ToList();

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
