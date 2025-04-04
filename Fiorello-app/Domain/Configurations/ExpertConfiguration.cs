using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public class ExpertConfiguration : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(255).IsRequired(false);
            builder.Property(m => m.Position).IsRequired(false);
            builder.Property(m => m.Image).IsRequired(false);
        }

    }
}
