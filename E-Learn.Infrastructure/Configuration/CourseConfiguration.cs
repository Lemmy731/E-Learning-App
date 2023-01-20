using E_Learn.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learn.Infrastructure.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>

    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.SubTitle).IsRequired();
            builder.Property(p => p.Language).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Instructor).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.Rating).HasColumnType("decimal(18,1)");
           // builder.HasOne(b => b.Category).WithMany().HasForeignKey(p => p.CategoryId);
          

        }
    }
}
