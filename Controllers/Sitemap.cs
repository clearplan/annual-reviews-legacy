using CP.AnnualReviews.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.AnnualReviews.Controllers
{
    public class Sitemap : Controller
    {
        private readonly ReviewContext db;
        public Sitemap(ReviewContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
