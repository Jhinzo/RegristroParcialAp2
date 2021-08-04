using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProyectoFinal.DAL
{
    public class ApplicationDbContext : IdentityDbContext<Usuarios, IdentityRole<int>, int>
    {

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<MatchGame> MatchGame { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data/MatchGame.db");
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }
    }
}
