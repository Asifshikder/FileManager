using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public bool IsSoftDeleted { get; set; } = false;
    }
}
