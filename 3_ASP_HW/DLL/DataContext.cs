using DLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=3HWDataBase;Integrated Security=True;");
        //    }
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Surname)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.BirthDay)
                .IsRequired();
            modelBuilder.Entity<User>()
                .HasMany(u => u.Subscriptions)
                .WithOne()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Subscription>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Subscription>()
                .Property(s => s.Name)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Entity<Subscription>()
                .Property(s => s.Price)
                .IsRequired();
            modelBuilder.Entity<Subscription>()
                .Property(s => s.SubscriptionDate)
                .IsRequired();
            modelBuilder.Entity<Subscription>()
                .Property(s => s.ExpirationDate)
                .IsRequired();
            modelBuilder.Entity<Subscription>()
                .Property(s => s.Type)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
