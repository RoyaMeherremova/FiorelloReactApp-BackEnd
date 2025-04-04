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
  
    public class SayConfiguration : IEntityTypeConfiguration<Say>
    {
        public void Configure(EntityTypeBuilder<Say> builder)
        {
            builder.Property(m => m.Title).HasMaxLength(255).IsRequired(false);
            builder.Property(m => m.Description).IsRequired(false);
            builder.Property(m => m.Position).HasMaxLength(255).IsRequired(false);
            builder.Property(m => m.Image).IsRequired(false);
        }

    }
}
