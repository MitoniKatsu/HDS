using HDS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Data
{
    public class HDSContext : DbContext
    {
        public HDSContext()
        {
        }
        public HDSContext(DbContextOptions<HDSContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreRole> StoreRole { get; set; }
        public virtual DbSet<EntityAddress> EntityAddress { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<ContactMethod> ContactMethod { get; set; }
        public virtual DbSet<ContactMethodType> ContactMethodType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
                .HasMany(o => o.Addresses)
                .WithOne()
                .HasForeignKey(o => o.EntityID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Employee>()
                .HasMany(o => o.Addresses)
                .WithOne()
                .HasForeignKey(o => o.EntityID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Store>()
                .HasMany(o => o.Addresses)
                .WithOne()
                .HasForeignKey(o => o.EntityID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
