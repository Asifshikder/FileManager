using Microsoft.AspNetCore.Mvc;
using Project.Core.Domain.Media;
using Project.MVC.Models;
using Project.Services.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC.Controllers
{
    public class FolderController : Controller
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpPost]
        public async Task<JsonResult> Create(FolderModel model)
        {
            MediaFolder folder = new MediaFolder()
            {
                ParentId = model.ParentId ==0?null:model.ParentId,
                FolderName = model.Name
            };
            var result = await _folderService.CreateFolder(folder);
            return Json(result);
        }

    }
}
