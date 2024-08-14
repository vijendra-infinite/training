using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC9_MVC_SOLUTION2.Models
{
    public class Movies
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Mid { get; set; }
        public string MovieName { get; set; }
        public DateTime DateOfRelease { get; set; }
    }
}