﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogProject.Models.EF
{
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }
        public DateTime PostDate { get; set; }
        public string Title { get; set; }
        public string BlogBody { get; set; }
        public ApplicationUser UserId { get; set; }
        
    }
}