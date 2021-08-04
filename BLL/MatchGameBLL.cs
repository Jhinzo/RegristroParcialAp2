using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using ProyectoFinal.DAL;
using ProyectoFinal.Models;
using System.Threading.Tasks;
namespace ProyectoFinal.BLL
{
    public class MatchGameBLL
    {
        public async static Task<bool> Guardar(MatchGame matchGame)
        {
            if (!await Existe(matchGame.MatchGameId))
                return await Insertar(matchGame);
            else
                return await Modificar(matchGame);
        }

        public async static Task<bool> Insertar(MatchGame matchGame)
        {
            bool paso = false;
            ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();

            try
            {
                ApplicationDbContext.MatchGame.Add(matchGame);
                paso = await ApplicationDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await ApplicationDbContext.DisposeAsync();
            }

            return paso;
        }

        public async static Task<bool> Modificar(MatchGame matchGame)
        {
            bool paso = false;
            ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();

            try
            {
                ApplicationDbContext.Entry(matchGame).State = EntityState.Modified;

                paso = await ApplicationDbContext.SaveChangesAsync() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                await ApplicationDbContext.DisposeAsync();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();

            try
            {
                var matchGame = ApplicationDbContext.MatchGame.Find(id);
                if (matchGame != null)
                {

                    ApplicationDbContext.MatchGame.Update(matchGame);//Visibilidad en el Sistema.
                    paso = ApplicationDbContext.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ApplicationDbContext.Dispose();
            }

            return paso;
        }

        public async static Task<MatchGame> Buscar(int id)
        {
            ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();
            MatchGame matchGame;

            try
            {
                matchGame = await ApplicationDbContext.MatchGame.Where(v => v.MatchGameId == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await ApplicationDbContext.DisposeAsync();
            }

            return matchGame;
        }

        public static List<MatchGame> GetList(Expression<Func<MatchGame, bool>> criterio)
        {
            List<MatchGame> lista = new List<MatchGame>();
            ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();

            try
            {
                lista = ApplicationDbContext.MatchGame.Where(criterio).ToList();//Visibilidad en el Sistema. (Consulta)
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ApplicationDbContext.Dispose();
            }

            return lista;
        }

        public async static Task<bool> Existe(int id)
        {
            ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();
            bool encontrado = false;

            try
            {
                encontrado = await ApplicationDbContext.MatchGame.AnyAsync(v => v.MatchGameId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await ApplicationDbContext.DisposeAsync();
            }

            return encontrado;
        }
    }
}
