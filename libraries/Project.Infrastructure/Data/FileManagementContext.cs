using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Core.Domain.Demo;

namespace Project.Infrastructure.Data
{
   public class FileManagementDbContext : DbContext
    {
        public FileManagementDbContext(DbContextOptions<FileManagementDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        public virtual DbSet<Employee> Employee { get; set; }



    }
}
