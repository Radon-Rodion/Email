using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using DataAcessLayer.Entities;

namespace DataAcessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Entities.File> Files { get; set; }
        public DbSet<Attachement> Attachements { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}
