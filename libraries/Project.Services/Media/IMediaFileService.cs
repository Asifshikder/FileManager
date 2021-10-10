using Microsoft.AspNetCore.Http;
using Project.Core.Domain.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Media
{
   public interface IMediaFileService
    {
        MediaFile UploadFile(IFormFile file);
        void UpdateFile(MediaFile media, IFormFile file);
        MediaFile GetById(long id);
        void DeleteFile(string fileurl, string thumburl, int mediaType);
        void DeleteFileWithMedia(MediaFile media);
    }
}
