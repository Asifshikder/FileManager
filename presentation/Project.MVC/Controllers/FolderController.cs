using Microsoft.AspNetCore.Mvc;
using Project.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MVC.Controllers
{
    public class FolderController : Controller
    {

        [HttpPost]
        public async Task<JsonResult> Create(FolderModel model)
        {
            
            return Json(false);
        }
    }
}
