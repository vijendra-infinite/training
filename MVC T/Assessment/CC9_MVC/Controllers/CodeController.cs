<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC9_MVC.Models;

namespace CC9_MVC.Controllers
{
    public class CodeController : Controller
    {
        private NorthWindEntities db = new NorthWindEntities();
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CustomerOfGerman()
        {
            var Germanlist = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(Germanlist);
        }

        // GET: Customer details with orderId == 10248
        public ActionResult CustomerOrder()
        {
            var OrderId = db.Customers.Where(c => c.Orders.Any(o => o.OrderID == 10248)).FirstOrDefault();

            return View(OrderId);
        }

    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC9_MVC.Models;

namespace CC9_MVC.Controllers
{
    public class CodeController : Controller
    {
        private NorthWindEntities db = new NorthWindEntities();
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CustomerOfGerman()
        {
            var Germanlist = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(Germanlist);
        }

        // GET: Customer details with orderId == 10248
        public ActionResult CustomerOrder()
        {
            var OrderId = db.Customers.Where(c => c.Orders.Any(o => o.OrderID == 10248)).FirstOrDefault();

            return View(OrderId);
        }

    }
>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
}