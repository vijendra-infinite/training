<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CC9_MVC_SOLUTION2.Models
{
    public class MoviesContext :DbContext
    {
        public MoviesContext() : base("MoviesConnection")
        { }
        public DbSet<Movies> movies { get; set; }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CC9_MVC_SOLUTION2.Models
{
    public class MoviesContext :DbContext
    {
        public MoviesContext() : base("MoviesConnection")
        { }
        public DbSet<Movies> movies { get; set; }
    }
>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
}