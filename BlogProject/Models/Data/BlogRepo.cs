using BlogProject.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Models.Data
{
    public class BlogRepo
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public List<Blog> GetAll()
        {
            return _db.Blogs.ToList();
        }
    }
}