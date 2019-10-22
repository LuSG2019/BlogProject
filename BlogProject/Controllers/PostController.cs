using BlogProject.Models;
using BlogProject.Models.EF;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class PostController : Controller
    {
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(Blog blog)
        {
            
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var post = db.Blogs.Create();
                    post.UserId.Id = User.Identity.GetUserId();
                    post.Title = blog.Title;
                    post.PostDate = DateTime.Today;
                    post.BlogBody = blog.BlogBody;
                }
            }

            return RedirectToAction("Home", "Index");
        }
    }
}