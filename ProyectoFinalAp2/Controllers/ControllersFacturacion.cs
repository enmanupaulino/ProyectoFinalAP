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
    public class ControllersFacturacion
    {
        public bool Guardar(Facturacion facturacion)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (facturacion.IdFactura == 0)
                {
                    paso = Insertar(facturacion);

                }
                else
                {
                    paso = Modificar(facturacion);

                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Insertar(Facturacion facturacion)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                if (contexto.facturacion.Add(facturacion) != null)
                {
                    foreach (var item in facturacion.Detalle)
                    {
                        contexto.productos.Find(item.IdProducto).Cantidad -= item.Cantidad;
                    }
                }
                contexto.clientes.Find(facturacion.IdCliente).Deuda += facturacion.Total;
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

        private bool Modificar(Facturacion facturacion)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            ControllersClientes controllersClientes = new ControllersClientes();

            try
            {
                Facturacion Factura = contexto.facturacion.Where(e => e.IdFactura == facturacion.IdFactura).Include(d => d.Detalle).FirstOrDefault();
                Clientes Cliente = controllersClientes.Buscar(Factura.IdCliente);
                Cliente.Deuda -= Factura.Total;
                controllersClientes.Guardar(Cliente);

                contexto = new Contexto();
                foreach (var item in Factura.Detalle)
                {
                    if (!Factura.Detalle.Any(d => d.IdFacturaDetalle == item.IdFacturaDetalle))
                    {
                        contexto.productos.Find(item.IdProducto).Cantidad += item.Cantidad;
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in facturacion.Detalle)
                {
                    if (item.IdFacturaDetalle == 0)
                    {
                        contexto.productos.Find(item.IdProducto).Cantidad -= item.Cantidad;
                        contexto.Entry(item).State = EntityState.Added;

                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;

                    }
                }
                contexto.clientes.Find(facturacion.IdCliente).Deuda += Factura.Total;
                contexto.Entry(Factura).State = EntityState.Modified;
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

        public Facturacion Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Facturacion facturacion = new Facturacion();

            try
            {
                facturacion = contexto.facturacion.Where(e => e.IdFactura == id).Include(d => d.Detalle).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }
            return facturacion;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Facturacion facturacion = contexto.facturacion.Where(e => e.IdFactura == id).Include(d => d.Detalle).FirstOrDefault();

                foreach (var item in facturacion.Detalle)
                {
                    contexto.productos.Find(item.IdProducto).Cantidad += item.Cantidad;

                }
                contexto.clientes.Find(facturacion.IdCliente).Deuda -= facturacion.Total;
                contexto.facturacion.Remove(facturacion);
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

        public List<Facturacion> GetList(Expression<Func<Facturacion, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Facturacion> lista;

            try
            {
                lista = contexto.facturacion.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
