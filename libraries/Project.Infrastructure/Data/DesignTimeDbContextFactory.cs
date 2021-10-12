using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FileManagementDbContext>
    {
        public FileManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FileManagementDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-56KPLJG\\SQLEXPRESS;Database=filemgmtdb;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new FileManagementDbContext(optionsBuilder.Options);
        }
    }
}
