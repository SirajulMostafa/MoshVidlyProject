using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using MoshVidlyProject.Models;

namespace MoshVidlyProject.Controllers.Api
{
    public class MoviesController : ApiController
    {
        // private ServicesContext db = new ServicesContext();
        //
        // // GET: Movies
        // public async Task<IHttpActionResult> Index()
        // {
        //     var movies = db.Movies.Include(m => m.Genre);
        //     return View(await movies.ToListAsync());
        // }
        //
        // // GET: Movies/Details/5
        // public async Task<IHttpActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return BadRequest();
        //     }
        //     // {
        //     //     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //     // }
        //     Movie movie = await db.Movies.FindAsync(id);
        //     if (movie == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(movie);
        // }
        //
        // // GET: Movies/Create
        // public ActionResult Create()
        // {
        //     ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name");
        //     return View();
        // }
        //
        // // POST: Movies/Create
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // [System.Web.Http.HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<ActionResult> Create([Bind(Include = "Id,Name,GenreId,ReleaseDate,NumberInStock,NumberAvailable")] Movie movie)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         movie.DateAdded = DateTime.Now;
        //         db.Movies.Add(movie);
        //         await db.SaveChangesAsync();
        //         return RedirectToAction("Index");
        //     }
        //
        //     ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
        //     return View(movie);
        // }
        //
        // // GET: Movies/Edit/5
        // public async Task<ActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //     }
        //     Movie movie = await db.Movies.FindAsync(id);
        //     if (movie == null)
        //     {
        //         return HttpNotFound();
        //     }
        //     ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
        //     return View(movie);
        // }
        //
        // // POST: Movies/Edit/5
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // [System.Web.Http.HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<ActionResult> Edit([Bind(Include = "Id,Name,GenreId,DateAdded,ReleaseDate,NumberInStock,NumberAvailable")] Movie movie)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         db.Entry(movie).State = EntityState.Modified;
        //         await db.SaveChangesAsync();
        //         return RedirectToAction("Index");
        //     }
        //     ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
        //     return View(movie);
        // }
        //
        // // GET: Movies/Delete/5
        // public async Task<ActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //     }
        //     Movie movie = await db.Movies.FindAsync(id);
        //     if (movie == null)
        //     {
        //         return HttpNotFound();
        //     }
        //     return View(movie);
        // }
        //
        // // POST: Movies/Delete/5
        // [System.Web.Http.HttpPost, System.Web.Http.ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<ActionResult> DeleteConfirmed(int id)
        // {
        //     Movie movie = await db.Movies.FindAsync(id);
        //     db.Movies.Remove(movie);
        //     await db.SaveChangesAsync();
        //     return RedirectToAction("Index");
        // }
        //
        // protected override void Dispose(bool disposing)
        // {
        //     if (disposing)
        //     {
        //         db.Dispose();
        //     }
        //     base.Dispose(disposing);
        // }
    }
}
