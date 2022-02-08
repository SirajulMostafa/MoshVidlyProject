using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using MoshVidlyProject.Models;
using MoshVidlyProject.ViewModel;

namespace MoshVidlyProject.Controllers
{
    public class MoviesController : Controller
    {
        private ServicesContext db = new ServicesContext();

        // GET: Movies
       
        public ActionResult Index()
        {
            return User.IsInRole("canManageMovies") ? View("Index") : View("ReadOnlyMovieList");
        }

        // GET: Movies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        
        // GET: Movies/Create
        [Authorize(Roles = "canManageMovies")]
        public ActionResult Create()
        {


            var genres = db.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View("Create", viewModel);
        }
        
        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canManageMovies")]
        public async Task<ActionResult> Create(Movie movie)
        {
            var genres = db.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres

            };

            if (ModelState.IsValid)
            {

                  movie.DateAdded = DateTime.Now;
                  db.Movies.Add(movie);
                 await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

           // return Redirect("Details");
            return View(viewModel);
        }
        
        // GET: Movies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var genres = db.Genres.ToList();
            var viewModel = new MovieFormViewModel(movie) { Genres = genres };

            return View(viewModel);
        }
        
       // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Movie movie)
        {
            if (!ModelState.IsValid)
            {

                var genres = db.Genres.ToList();
                var viewModel = new MovieFormViewModel(movie);
                return View(viewModel);
               
            }

            var movieInDb = db.Movies.FindAsync(movie.Id);
            if (movieInDb == null)
            {
                return HttpNotFound();
            }

            movieInDb.Result.Name = movie.Name;
            movieInDb.Result.GenreId = movie.GenreId;
            movieInDb.Result.ReleaseDate = movie.ReleaseDate;
            movieInDb.Result.NumberAvailable = movie.NumberAvailable;
            movieInDb.Result.NumberInStock = movie.NumberInStock;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        
        // GET: Movies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie);

            return View(viewModel);
        }
        
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
           var movie = await db.Movies.FindAsync(id);
            db.Movies.Remove(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
