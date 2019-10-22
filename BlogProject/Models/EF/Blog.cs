using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Models.EF
{
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }
        public DateTime PostDate { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        [UIHint("tinymce_jquery_full")]
        public string BlogBody { get; set; }
        public ApplicationUser UserId { get; set; }
        
    }
}