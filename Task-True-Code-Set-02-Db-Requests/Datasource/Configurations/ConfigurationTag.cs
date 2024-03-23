using Datasource.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Datasource.Configurations;
internal class ConfigurationTag : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder
            .HasMany(ptu => ptu.TagToUsers)
            .WithOne(t => t.Tag)            
            .HasForeignKey(ptu => ptu.TagId);
    }
}
