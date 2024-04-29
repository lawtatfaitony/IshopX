using Ishop.Context;
using Ishop.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Ishop.Models;

namespace Ishop.Controllers
{
    [Authorize(Roles = "Admin,Supervisor")]
    public class RolesController : Controller
    {
        private Ishop.Context.ApplicationDbContext _db = new Ishop.Context.ApplicationDbContext();

        public ActionResult Index()
        {
            var rolesList = new List<RoleViewModel>();
            foreach (var role in _db.AspNetRoles)
            {
                var roleModel = new RoleViewModel(role);
                rolesList.Add(roleModel);
            }
            return View(rolesList);
        }


         [Authorize(Roles = "Admin,Supervisor")]
        public ActionResult Create(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Supervisor")]
        public ActionResult Create([Bind(Include =
            "RoleName,Description")]RoleViewModel model)
        {
            string message = "That role name has already been used";
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole(model.RoleName, model.Description);
                ApplicationRoleManager _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
                if (_db.RoleExists(_roleManager, model.RoleName))
                {
                    return View(message);
                }
                else
                {
                    _db.CreateRole(_roleManager, model.RoleName, model.Description);
                    return RedirectToAction("Index", "Roles");
                }
            }
            return View();
        }


        [Authorize(Roles = "Admin,Supervisor")]
        public ActionResult Edit(string id)
        {
            // It's actually the Role.Name tucked into the id param:
            var role = _db.AspNetRoles.First(r => r.Name == id);
            var roleModel = new EditRoleViewModel(role);
            return View(roleModel);
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Supervisor")]
        public ActionResult Edit([Bind(Include =
            "RoleName,OriginalRoleName,Description")] EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = _db.AspNetRoles.First(r => r.Name == model.OriginalRoleName);
                role.Name = model.RoleName;
                role.Description = model.Description;
                _db.Entry(role).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [Authorize(Roles = "Supervisor")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var role = _db.AspNetRoles.First(r => r.Name == id);
            var model = new RoleViewModel(role);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        [Authorize(Roles = "Supervisor")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            var role = _db.AspNetRoles.First(r => r.Name == id);
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db)); 
            _db.DeleteRole(_db, userManager, role.Id);
            return RedirectToAction("Index");
        }
    }
}