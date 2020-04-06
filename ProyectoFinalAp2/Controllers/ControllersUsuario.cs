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
    public class ControllersUsuarios
    {
        public bool Guardar(Usuarios usuarios)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (usuarios.IdUsuario == 0)
                {
                    paso = Insertar(usuarios);

                }
                else
                {
                    paso = Modificar(usuarios);

                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Insertar(Usuarios usuarios)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.usuarios.Add(usuarios);
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


        public static bool InicioSesion(string Usuario, string psw)
        {
            
                bool paso = false;
                Contexto db = new Contexto();

                try
                {

                    paso = db.usuarios.Any(A => A.Usuario.Equals(Usuario) && A.Contrasena.Equals(psw) );
                }
                catch (Exception)
                {

                    throw;
                }

                return paso;

            }

        private bool Modificar(Usuarios usuarios)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                Usuarios usuario = contexto.usuarios.Find(usuarios.IdUsuario);
                if (usuario != null)
                {
                    contexto = new Contexto();
                    contexto.Entry(usuarios).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuarios = new Usuarios();

            try
            {
                usuarios = contexto.usuarios.Find(id);

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();

            }

            return usuarios;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Usuarios usuarios = new Usuarios();

            try
            {
                usuarios = contexto.usuarios.Find(id);
                contexto.Entry(usuarios).State = EntityState.Deleted;
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

        public List<Usuarios> GetList(Expression<Func<Usuarios, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Usuarios> lista;

            try
            {
                lista = contexto.usuarios.Where(expression).ToList();
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
