using Project.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Demo.Employee.Models
{
   public class EmployeeViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long? ProfileImageId { get; set; }
        public long CountryId { get; set; }
        public long SateId { get; set; }
        public long CityId { get; set; }
        public int GenderId { get; set; }
    }
}
