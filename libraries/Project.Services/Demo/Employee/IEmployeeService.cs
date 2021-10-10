using Project.Core.Miscellaneous;
using Project.Services.Demo.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Demo.Employee
{
   public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModel>> GetAllAsync();
        Task<EmployeeViewModel> GetByIdAsync(long id);
        Task<bool> AddAsync(EmployeeViewModel model);
        Task<bool> UpdateAsync(EmployeeViewModel model);
        Task<int> TotalCountAsync();
        Task<bool> SoftDeleteByIdAsync(long id);
        Task<PagedModel<EmployeeViewModel>> GetPagedListAsync(int page, int pageSize);
    }
}
