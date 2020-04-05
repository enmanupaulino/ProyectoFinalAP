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
    public class ControllersTrabajo
    {
        public bool Guardar(Trabajos trabajos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            if (trabajos.IdTrabajo== 0)
            {
                Insertar(trabajos);
            }
            else if (Buscar(trabajos.IdTrabajo) == null)
            {
                paso = false;
            }
            else
            {
                Modificar(trabajos);
            }
            return paso;
        }
        public bool Insertar(Trabajos trabajos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.trabajos.Add(trabajos);
                paso = db.SaveChanges() > 0;

            }
            catch (Exception) { throw; }

            return paso;
        }
        public Trabajos Buscar(int Id)
        {
            Contexto db = new Contexto();
            Trabajos trabajo = new Trabajos();


            trabajo = db.trabajos.Where(A => A.IdTrabajo == Id)
                .Include(A => A.Detalles).FirstOrDefault();


            return trabajo;
        }
        public bool Modificar(Trabajos trabajos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            var anterior = Buscar(trabajos.IdTrabajo);

            foreach (var item in trabajos.Detalles)
            {
                if (item.Id == 0)
                {
                    db.Entry(item).State = EntityState.Added;
                }
            }

            foreach (var item in anterior.Detalles)
            {
                if (!trabajos.Detalles.Any(A => A.Id == item.Id))
                {
                    db.Entry(item).State = EntityState.Deleted;
                }
            }

            db.Entry(trabajos).State = EntityState.Modified;
            paso = db.SaveChanges() > 0;


            return paso;
        }
        public bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();



            Trabajos trabajo = db.trabajos.Find(Id);
            if (trabajo != null)
            {
                db.Entry(trabajo).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }

            return paso;
        }
        public List<Trabajos> GetRegistros(Expression<Func<Trabajos, bool>> expression)
        {
            List<Trabajos> lista;
            Contexto db = new Contexto();
            try
            {
                lista = db.trabajos.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

    }
}
