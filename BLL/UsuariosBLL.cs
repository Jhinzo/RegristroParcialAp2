using Microsoft.EntityFrameworkCore;
using ProyectoFinal.DAL;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProyectoFinalAP2.BLL
{
    public class UsuariosBLL
    {
        private readonly ApplicationDbContext ApplicationDbContext;

        public UsuariosBLL(ApplicationDbContext _ApplicationDbContext)
        {
            ApplicationDbContext = _ApplicationDbContext;
        }

        public async Task<List<Usuarios>> GetList(Expression<Func<Usuarios, bool>> usuarios)
        {
            _ = new List<Usuarios>();
            List<Usuarios> Lista;
            try
            {
                Lista = await ApplicationDbContext.Usuarios.Where(usuarios).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}
