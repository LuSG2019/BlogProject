using BlogProject.Models;
using BlogProject.Models.Data;
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
        [Authorize(Roles = "Admin")]
        public ActionResult PendingPost()
        {

            BlogRepo repo = new BlogRepo();
            List<Blog> blogs = repo.GetAll().Where(b => b.Pending == true).ToList();
            return View(blogs);
        }
        [HttpPost]
        public ActionResult PendingPost(Blog blog)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    blog.Pending = false;

                    db.Entry(blog).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }

            BlogRepo repo = new BlogRepo();
            List<Blog> blogs = repo.GetAll().Where(b => b.Pending == true).ToList();
            return View(blogs);
        }
        [Authorize(Roles = "Manager , Admin")]
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
                    //post.UserId.Id = User.Identity.GetUserId();
                    post.Title = blog.Title;
                    post.PostDate = DateTime.Today;
                    post.BlogBody = blog.BlogBody;
                    post.Pending = true;

                    db.Blogs.Add(post);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}