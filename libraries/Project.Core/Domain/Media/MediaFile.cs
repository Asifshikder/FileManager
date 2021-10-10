using Project.Core.Domain.Demo;
using Project.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Domain.Media
{
    public partial class MediaFile : BaseEntity
    {
        public MediaFile()
        {
            Employees = new HashSet<Employee>();
        }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public long MediaFolderId { get; set; }
        public MediaType MediaType { get; set; }
        public long FileSize { get; set; }
        public virtual MediaFolder MediaFolder { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
