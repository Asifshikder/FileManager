using Project.Core.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Media
{
    public interface IFolderService
    {
        public MediaFolder CreateFolder(MediaFolder model);
        public MediaFolder RenameFolder(MediaFolder model);
        public bool DeleteFolder(long id);
        public List<MediaFolder> GetAllFolder();
    }
}
