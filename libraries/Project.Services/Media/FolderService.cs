using Microsoft.AspNetCore.Http;
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
    public class FolderService : IFileService
    {
        private IEntityRepository<MediaFile> _repository;
        private IEntityRepository<MediaFolder> _folderrepo;

        public FolderService(IEntityRepository<MediaFolder> folderrepo, IEntityRepository<MediaFile> repository)
        {
            _repository = repository;
            _folderrepo = folderrepo;
        }
        public async Task<bool> UploadFile(FileUploadModel model, List<IFormFile> FormFiles)
        {
            foreach(var item in FormFiles)
            {
                var mediaFolder = await _folderrepo.GetByIdAsync(model.folderid);

            }
        }
    }
}
