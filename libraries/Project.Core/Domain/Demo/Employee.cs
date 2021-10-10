using Project.Core.Common;
using Project.Core.Domain.Media;
using Project.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Domain.Demo
{
    public partial class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long? ProfileImageId { get; set; }
        public long CountryId { get; set; }
        public long SateId { get; set; }
        public long CityId { get; set; }
        public virtual MediaFile MediaFile { get; set; }
    }
}
