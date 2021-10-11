using Microsoft.AspNetCore.Hosting;
using Project.Core.Domain.Media;
using Project.Infrastructure.Repository;
using Project.Services.Media;
using Project.Services.Media.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC.Services
{
    public class FolderService : IFolderService
    {
        private IWebHostEnvironment _webHost;
        private IEntityRepository<MediaFolder> _repository;

        public FolderService(IWebHostEnvironment webHost, IEntityRepository<MediaFolder> repository)
        {
            _webHost = webHost;
            _repository = repository;
        }
        public async Task<FolderResultModel> CreateFolder(MediaFolder model)
        {
            string folderurl = await GetFolderUrl(model);
            string dbpath = folderurl.Replace("~/", "").ToString();
            string uppath = dbpath.Replace("/", "\\").ToString();
            var wwwroot = _webHost.WebRootPath;
            var url = Path.Combine(wwwroot, uppath);

            if (!Directory.Exists(url))
            {
                Directory.CreateDirectory(url);
                FolderResultModel resultModel = new FolderResultModel()
                {
                    Success = true,
                    Message = "Folder created"
                };
                model.FolderUrl = folderurl;
                await _repository.AddAsync(model);
                return resultModel;
            }
            else
            {
                FolderResultModel resultModel = new FolderResultModel()
                {
                    Success = false,
                    Message = "Folder already exists ! try different name"
                };
                return resultModel;
            }
        }

        private async Task<string> GetFolderUrl(MediaFolder folder)
        {
            string url = string.Empty;
            long? parentid = folder.ParentId;
            if (parentid != null)
            {
                var parentfolder = await _repository.GetByIdAsync(parentid.Value);
                url = parentfolder.FolderUrl.Trim() + "/" + folder.FolderName.Trim();
            }
            else
            {
                url = "~/uploads/" + folder.FolderName + "";
            }
            return url;
        }

        public Task<bool> DeleteFolder(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MediaFolder>> GetAllFolder()
        {
            throw new NotImplementedException();
        }

    }
}
