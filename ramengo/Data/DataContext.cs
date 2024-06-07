﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ramengo.Models;
using System.IO;

namespace ramengo.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Broth> Broths { get; set; }
        public DbSet<Protein> Proteins { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var secret = JObject.Parse(File.ReadAllText(@"C:\Users\michel.calil\Desktop\RamenGo\Backend\ramengo\ramengo\.secret.json"));
            Console.WriteLine(secret.ToString());

            optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                $"Username={Convert.ToString(secret["username"])};" + // Place in your Username for the DB
                $"Password={Convert.ToString(secret["password"])};" + // Place in your Password for the DB
                "Database=RamenGo;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(p => p.Broth)
                .WithMany()
                .HasForeignKey(p => p.BrothId);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.Protein)
                .WithMany()
                .HasForeignKey(p => p.ProteinId);
        }

    }
}
