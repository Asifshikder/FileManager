using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Domain.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.ModelBuilders.Demo
    {
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(p => p.MediaFile)
             .WithMany(r => r.Employees)
             .HasForeignKey(d => d.ProfileImageId)
             .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
