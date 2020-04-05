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
    public class ControllersProveedor
    {
        public bool Guardar(Proveedores proveedores)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (proveedores.IdProveedor == 0)
                {
                    paso = Insertar(proveedores);

                }
                else
                {
                    paso = Modificar(proveedores);

                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Insertar(Proveedores proveedores)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.proveedores.Add(proveedores);
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

        private bool Modificar(Proveedores proveedores)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Proveedores proveedor = contexto.proveedores.Find(proveedores.IdProveedor);
                if (proveedores != null)
                {
                    contexto = new Contexto();
                    contexto.Entry(proveedores).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Proveedores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Proveedores proveedores = new Proveedores();

            try
            {
                proveedores = contexto.proveedores.Find(id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return proveedores;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Proveedores proveedores = new Proveedores();

            try
            {
                proveedores = contexto.proveedores.Find(id);
                contexto.Entry(proveedores).State = EntityState.Deleted;
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

        public List<Proveedores> GetList(Expression<Func<Proveedores, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Proveedores> lista;

            try
            {
                lista = contexto.proveedores.Where(expression).ToList();
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
