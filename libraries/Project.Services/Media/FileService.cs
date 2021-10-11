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
    public class FileService : IFileService
    {
        private IEntityRepository<MediaFolder> _folderRepository;
        private IMediaFileService _mediaFileService;

        public FileService(IEntityRepository<MediaFolder> folderRepository, IMediaFileService mediaFileService)
        {
            _folderRepository = folderRepository;
            _mediaFileService = mediaFileService;
        }
        public async Task<bool> UploadFile(FileUploadModel model, List<IFormFile> FormFiles)
        {
            var folder = await _folderRepository.GetByIdAsync(model.folderid);
            foreach(var item in FormFiles)
            {
                _mediaFileService.UploadFile(folder, item);
            }
            return true;
        }
    }
}
