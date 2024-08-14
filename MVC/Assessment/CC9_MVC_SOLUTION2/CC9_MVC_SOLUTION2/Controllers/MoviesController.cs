using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC9_MVC_SOLUTION2.Models;
using CC9_MVC_SOLUTION2;
using CC9_MVC_SOLUTION2.Repository;

namespace CC9_MVC_SOLUTION2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository<Movies> _movieRepository;

        public MoviesController()
        {
            _movieRepository = new MovieRepository<Movies>();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movie = _movieRepository.GetAll();
            return View(movie);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movies p)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Insert(p);
                _movieRepository.Save();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public ActionResult Edit(int Id)
        {
            var movie = _movieRepository.GetById(Id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movies p)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Update(p);
                _movieRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }
        public ActionResult Details(int id)
        {
            var movie = _movieRepository.GetById(id);
            return View(movie);
        }

        public ActionResult Delete(int Id)
        {
            var movie = _movieRepository.GetById(Id);
            return View(movie);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int Id)
        {
            var movie = _movieRepository.GetById(Id);
            _movieRepository.Delete(Id);
            _movieRepository.Save();
            return RedirectToAction("Index");
        }
    }
}