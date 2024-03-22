using Datasource.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datasource.Factories;
public class DbContextTrueCodeFactoryDesignTime : IDesignTimeDbContextFactory<DbContextTrueCode>
{
    public DbContextTrueCode CreateDbContext(string[] args)
    {
        var pathtoApi = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Api"));

        var configuration = new ConfigurationBuilder()
            .SetBasePath(pathtoApi)
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Docker");

        var optionsBuilder = new DbContextOptionsBuilder<DbContextTrueCode>();

        optionsBuilder.UseSqlServer(connectionString);

        return new DbContextTrueCode(optionsBuilder.Options);
    }
}
