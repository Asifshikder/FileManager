using Project.Core.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Media.Models
{
  public  class PageModel
    {
        public long RootFolderId { get; set; }
        public List<MediaFolder> Folders { get; set; }
        public List<MediaFile> Files { get; set; }
    }
}
