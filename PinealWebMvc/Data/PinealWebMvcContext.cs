using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PinealWebMvc.Models;

namespace PinealWebMvc.Data
{
    public class PinealWebMvcContext : DbContext
    {
        public PinealWebMvcContext (DbContextOptions<PinealWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<PinealWebMvc.Models.Projeto> Projeto { get; set; }

        public DbSet<PinealWebMvc.Models.Track> Track { get; set; }

        public DbSet<PinealWebMvc.Models.Tipo> Tipo { get; set; }

        public DbSet<PinealWebMvc.Models.Vertente> Vertente { get; set; }
        public DbSet<PinealWebMvc.Models.Imagem> Imagem { get; set; }
    }
}
