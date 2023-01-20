using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentApi.Domain.Entities;

namespace PaymentApi.Data.Context;

public class DataContext : DbContext
{  
  public DataContext(DbContextOptions<DataContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    public DbSet<Product>? Products { get; set; }
    public DbSet<Seller>? Sellers { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }
    

}
