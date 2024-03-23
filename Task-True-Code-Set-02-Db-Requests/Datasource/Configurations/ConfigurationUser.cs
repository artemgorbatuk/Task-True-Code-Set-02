using Datasource.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datasource.Configurations;
internal class ConfigurationUser : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany(ptu => ptu.TagToUsers)
            .WithOne(t => t.User)
            .HasForeignKey(ptu => ptu.UserId);
    }
}
