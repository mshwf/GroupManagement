using GroupManagement.Web.Models;
using GroupManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GroupManagement.Web.Controllers
{
    //http://localhost:5000/Groups
    //[Route("Groups")]
    public class GroupsController : Controller
    {
        private IGenerateId generateId;
        public GroupsController(IGenerateId _generateId)
        {
            generateId = _generateId;
        }
        private static List<GroupViewModel> Groups = new List<GroupViewModel>
        {
            new GroupViewModel { Id = 1, Name = "Group 1"},
            new GroupViewModel { Id = 2, Name = "Group 2"}
        };
        //[Route("Index")]
        public IActionResult Index()
        {
            return View(Groups);
        }
        [Route("Edit/{groupId}"), HttpGet]
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
            model.Id = generateId.Next();
            Groups.Add(model);
            return RedirectToAction("Index");
        }
    }
}
