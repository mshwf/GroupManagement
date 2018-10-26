using GroupManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GroupManagement.Web.Controllers
{
    //http://localhost:5000/Groups
    [Route("Groups")]
    public class GroupsController : Controller
    {
        //private int CurrentId = 1;
        private static List<GroupViewModel> Groups = new List<GroupViewModel> {
            new GroupViewModel { Id = 1, Name = "Sample Group"},
            new GroupViewModel { Id = 2, Name = "Sample Group2"}
        };
        [Route("Index")]
        public IActionResult Index()
        {
            return View(Groups);
        }
        [Route("Edit/{groupId}"),HttpGet]
        public IActionResult Edit(int groupId)
        {
            var group = Groups.SingleOrDefault(g => g.Id == groupId);
            if (group == null)
                return NotFound();
            return View(group);
        }

        [Route("Edit/{id}"), ValidateAntiForgeryToken, HttpPost]
        public IActionResult Edit(int id, GroupViewModel model)
        {
            var group = Groups.SingleOrDefault(g => g.Id == id);
            if (group == null)
                return NotFound();
            group.Name = model.Name;
            return RedirectToAction("Index", "Groups");
        }

        [HttpGet, Route("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Route("Create")]
        public IActionResult Create(GroupViewModel model)
        {
            model.Id = Groups.Max(x => x.Id) + 1;
            Groups.Add(model);
            return RedirectToAction("Index");
        }
    }
}
