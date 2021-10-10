using Project.Core.Domain.Media;
using Project.Infrastructure.Repository;
using Project.Services.Media.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Media
{
    public class PageService : IPageService
    {
        private IEntityRepository<MediaFolder> _folderRepository;
        private IEntityRepository<MediaFile> _fileRepository;

        public PageService(IEntityRepository<MediaFolder> folderRepository,IEntityRepository<MediaFile> fileRepository)
        {
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
        }
        public PageModel GetPageData(int routeid)
        {
            PageModel model = new PageModel();
            var allsubfolders = _folderRepository.AllIQueryableAsync().Where(s => s.ParentId == routeid).ToList();
            var files = _fileRepository.AllIQueryableAsync().Where(s => s.MediaFolderId == routeid).ToList();
            model.RootFolderId = routeid;
            model.Folders = allsubfolders;
            model.Files = files;
            return model;
        }
    }
}
