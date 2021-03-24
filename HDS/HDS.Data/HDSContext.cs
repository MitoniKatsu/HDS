﻿using HDS.Domain.Models;
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
        public virtual DbSet<EntityType> EntityType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // EntityAddress
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

            // ContactMethod
            builder.Entity<Customer>()
                .HasMany(o => o.ContactMethods)
                .WithOne()
                .HasForeignKey(o => o.EntityID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Employee>()
                .HasMany(o => o.ContactMethods)
                .WithOne()
                .HasForeignKey(o => o.EntityID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Store>()
                .HasMany(o => o.ContactMethods)
                .WithOne()
                .HasForeignKey(o => o.EntityID)
                .OnDelete(DeleteBehavior.Restrict);

            // inventory
            builder.Entity<Store>()
                .HasMany(o => o.Inventory)
                .WithOne(o => o.Location)
                .HasForeignKey(o => o.LocationID)
                .OnDelete(DeleteBehavior.Restrict);

            #region DataTable Defaults
            // Address
            builder.Entity<Address>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<Address>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // AddressType
            builder.Entity<AddressType>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<AddressType>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // ContactMethod
            builder.Entity<ContactMethod>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<ContactMethod>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // ContactMethodType
            builder.Entity<ContactMethodType>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<ContactMethodType>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // Customer
            builder.Entity<Customer>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<Customer>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // Employee
            builder.Entity<Employee>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<Employee>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // EntityAddress
            builder.Entity<EntityAddress>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<EntityAddress>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // EntityType
            builder.Entity<EntityType>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");
            builder.Entity<EntityType>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // Inventory
            builder.Entity<Inventory>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<Inventory>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // Order
            builder.Entity<Order>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<Order>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // OrderDetail
            builder.Entity<OrderDetail>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<OrderDetail>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // Service
            builder.Entity<Service>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<Service>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // Store
            builder.Entity<Store>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<Store>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");
            // StoreRole
            builder.Entity<StoreRole>()
                .Property(o => o.Created)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<StoreRole>()
                .Property(o => o.Updated)
                .HasDefaultValueSql("GETUTCDATE()");


            #endregion

        }
    }
}
