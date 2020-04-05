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
    public class ControllersProductos
    {
        public bool Guardar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (productos.IdProducto == 0)
                {
                    paso = Insertar(productos);

                }
                else
                {
                    paso = Modificar(productos);

                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Insertar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.productos.Add(productos);
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

        private bool Modificar(Productos productos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Productos producto= contexto.productos.Find(productos.IdProducto);
                if (producto != null)
                {
                    contexto = new Contexto();
                    contexto.Entry(productos).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos producto= new Productos();

            try
            {
                producto = contexto.productos.Find(id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return producto;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Productos producto = new Productos();

            try
            {
                producto = contexto.productos.Find(id);
                contexto.Entry(producto).State = EntityState.Deleted;
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

        public List<Productos> GetList(Expression<Func<Productos, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Productos> lista;

            try
            {
                lista = contexto.productos.Where(expression).ToList();
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
