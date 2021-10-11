using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Services.Media.Models;

namespace Project.MVC.Controllers
{
    public class FilesController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm]IFormCollection form)
        {
            FileUploadModel transaction = JsonConvert.DeserializeObject<FileUploadModel>(form["UploadModel"]);
            List<IFormFile> formfiles = form.Files.ToList();
            var res = 
            return View();
        }
    }
}
