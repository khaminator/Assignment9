using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment9_2.Models;

namespace Assignment9_2.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        } */

        //Private Variable to bring MovieListContext into the Constructor
        private MovieListContext context { get; set; }

        //Constructor
        public HomeController(MovieListContext cont)
        {
            context = cont;
        }


        //Connect View for Index 
        public IActionResult Index()
        {
            return View();
        }

        //Connect for EnterFilm
        [HttpGet]
        public IActionResult EnterFilm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterFilm(Movies m)
        {
            if (ModelState.IsValid)
            {
                //Update Database
                context.Movie.Add(m);
                context.SaveChanges();
                return View("FilmList", context.Movie);

            }

            //Otherwise (if not valid)
            return View();
        }

        //Connect View for Podcasts
        public IActionResult Podcasts()
        {
            return View();
        }

        //Connect View for FilmList
        public IActionResult FilmList()
        {
            //pass in the DB object to populate the page
            return View(context.Movie);

            //If you wanted to fiter do something like this:
            //return View(context.Movie.Where(Movies => Movies.Title != "Independent Day"));
        }

        [HttpPost]
        public IActionResult Edit1(int MovieId)
        {
            Movies m = context.Movie.Single(x => x.MovieId == MovieId);
            return View("Update", m);
        }

        [HttpPost]
        public IActionResult Edit2(Movies m, int MovieId)
        {
            if (ModelState.IsValid)
            {
                var mov = context.Movie.SingleOrDefault(x => x.MovieId == m.MovieId);

                context.Entry(mov).Property(x => x.Category).CurrentValue = m.Category;
                context.Entry(mov).Property(x => x.Title).CurrentValue = m.Title;
                context.Entry(mov).Property(x => x.Year).CurrentValue = m.Year;
                context.Entry(mov).Property(x => x.Director).CurrentValue = m.Director;
                context.Entry(mov).Property(x => x.Rating).CurrentValue = m.Rating;
                context.Entry(mov).Property(x => x.Edited).CurrentValue = m.Edited;
                context.Entry(mov).Property(x => x.LentTo).CurrentValue = m.LentTo;
                context.Entry(mov).Property(x => x.Notes).CurrentValue = m.Notes;

                context.SaveChanges();

                return RedirectToAction("FilmList");
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult Remove(int MovieId)
        {
            Movies m = context.Movie.Single(x => x.MovieId == MovieId);
            context.Remove(m);
            context.SaveChanges();
            return RedirectToAction("FilmList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
