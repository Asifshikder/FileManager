using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Services.Media.Models;
using Project.Services.Media;

namespace Project.MVC.Controllers
{
    public class FilesController : Controller
    {
        private IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpPost]
        public JsonResult Upload([FromForm]IFormCollection form)
        {
            FileUploadModel transaction = JsonConvert.DeserializeObject<FileUploadModel>(form["UploadModel"]);
            List<IFormFile> formfiles = form.Files.ToList();
            var res = _fileService.UploadFile(transaction, formfiles);
            return Json(new { success= true});
        }
    }
}
