using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Domain.Media
{
    public partial class MediaFolder : BaseEntity
    {
        public MediaFolder()
        {
            MediaFiles = new HashSet<MediaFile>();
        }
        public string FolderName { get; set; }
        public string FolderUrl { get; set; }
        public long? ParentId { get; set; }
        public virtual ICollection<MediaFile> MediaFiles { get; set; }
    }
}
