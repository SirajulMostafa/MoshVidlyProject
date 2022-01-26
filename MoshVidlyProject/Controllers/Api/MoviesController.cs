using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using MoshVidlyProject.Dto;
using MoshVidlyProject.Models;
using MoshVidlyProject.ViewModel;

namespace MoshVidlyProject.Controllers.Api
{
    public class MoviesController : ApiController {        
        private readonly ServicesContext _db = new ServicesContext();

            // GET: Movies
            public IHttpActionResult GetMovies()
            {
            var movies = _db.Movies.
                Include(c => c.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movies);
        }
            
            // GET: api/Movies/5
            public IHttpActionResult GetMovie(int? id)
            {
                if (id == null)
                {
                    return BadRequest();
                }
                var movie = _db.Movies.Find(id);
                if (movie == null)
                {
                    return NotFound();
                }
                return Ok(Mapper.Map<Movie,MovieDto>(movie));
        }

            // {
            //     "name": "MD SIRAJUL",
            //     "genre": null,
            //     "genreId": 3,
            //     "dateAdded": "2020-01-01T00:00:00",
            //     "releaseDate": "2022-01-01T00:00:00",
            //     "numberInStock": 10,
            //     "numberAvailable": 5
            // }

        //POST /api/movies
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto,Movie>(movieDto);
            _db.Movies.Add(movie);
            _db.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        //PUT /api/customer/1
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _db.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            _db.SaveChanges();
            return Ok();
        }

        // DELETE /api/customers/1
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _db.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();
            _db.Movies.Remove(movieInDb);
            _db.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
    }
