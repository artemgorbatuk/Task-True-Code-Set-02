using Datasource.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Datasource.Contexts;
public class DbContextTrueCode : DbContext
{
    public DbContextTrueCode(DbContextOptions<DbContextTrueCode> options) : base(options) { }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<TagToUser> TagToUser { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.EnableSensitiveDataLogging(false);
        options.UseLazyLoadingProxies(false);
        options.UseChangeTrackingProxies(false);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasDefaultSchema("dto");
        base.OnModelCreating(modelBuilder);
    }
}
