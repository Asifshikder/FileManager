using Project.Services.Media.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Media
{
    public interface IPageService
    {
       PageModel GetPageData(int routeid);
    }
}
