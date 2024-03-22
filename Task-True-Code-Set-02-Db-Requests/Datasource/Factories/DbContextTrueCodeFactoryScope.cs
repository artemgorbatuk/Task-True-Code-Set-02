using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datasource.Factories;
public class DbContextTrueCodeFactoryScope : IServiceScopeFactory
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public DbContextTrueCodeFactoryScope(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public IServiceScope CreateScope()
    {
        return _serviceScopeFactory.CreateScope();
    }
}
