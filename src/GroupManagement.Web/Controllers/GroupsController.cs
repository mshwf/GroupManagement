using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupManagement.Web.Controllers
{
    //http://localhost:5000/groups
    [Route("groups")]
    public class GroupsController : Controller
    {
        [HttpGet,Route("")]
        public IActionResult Index()
        {
            return Content("3Hello dotnettttt!");
        }
    }
}
