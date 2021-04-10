using HDS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HDS.Data
{
    public interface IHDSContext
    {
        DbSet<Address> Address { get; set; }
        DbSet<AddressType> AddressType { get; set; }
        DbSet<ContactMethod> ContactMethod { get; set; }
        DbSet<ContactMethodType> ContactMethodType { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Employee> Employee { get; set; }
        DbSet<EmployeePosition> EmployeePosition { get; set; }
        DbSet<EntityAddress> EntityAddress { get; set; }
        DbSet<EntityType> EntityType { get; set; }
        DbSet<Inventory> Inventory { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderDetail> OrderDetail { get; set; }
        DbSet<Service> Service { get; set; }
        DbSet<Store> Store { get; set; }
        DbSet<StoreRole> StoreRole { get; set; }

        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class; 
        int SaveChanges();
    }
}