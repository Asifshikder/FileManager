using Project.Core.Domain.Media;
using Project.Services.Media.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Media
{
    public interface IFolderService
    {
        Task<FolderResultModel> CreateFolder(MediaFolder model);
        Task<FolderResultModel> RenameFolder(MediaFolder model);
        Task<bool> DeleteFolder(long id);
        Task<List<MediaFolder>> GetAllFolder();
    }
}
