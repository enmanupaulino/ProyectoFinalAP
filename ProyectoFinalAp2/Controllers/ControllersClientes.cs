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
    public class ControllersClientes
    {
        public bool Guardar(Clientes clientes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (clientes.IdCliente == 0)
                {
                    paso = Insertar(clientes);

                }
                else
                {
                    paso = Modificar(clientes);

                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Insertar(Clientes clientes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.clientes.Add(clientes);
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

        private bool Modificar(Clientes clientes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Clientes cliente = contexto.clientes.Find(clientes.IdCliente);
                if (cliente != null)
                {
                    contexto = new Contexto();
                    contexto.Entry(cliente).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes cliente = new Clientes();

            try
            {
                cliente = contexto.clientes.Find(id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return cliente;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Clientes clientes = new Clientes();

            try
            {
                clientes = contexto.clientes.Find(id);
                contexto.Entry(clientes).State = EntityState.Deleted;
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

        public List<Clientes> GetList(Expression<Func<Clientes, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Clientes> lista;

            try
            {
                lista = contexto.clientes.Where(expression).ToList();
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
