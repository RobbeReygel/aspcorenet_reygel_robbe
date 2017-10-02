using aspnetcore_reygel_robbe.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace aspnetcore_reygel_robbe.Controllers
{
    public class BookController : Controller
    {
        [HttpGet("books")]
        public IActionResult Index()
        {

            var model = new BookListViewModel();

            model.Books = new List<BookDetailViewModel>();


            model.Books.Add(new BookDetailViewModel() { Id = 1, Author = "Author 1", Title = "Title1", ISBN = "isbn1", CreationDate = new DateTime(2016, 3, 12) });
            model.Books.Add(new BookDetailViewModel() { Id = 2, Author = "Author 2", Title = "Title2", ISBN = "isbn2", CreationDate = new DateTime(2013, 7, 7) });
            model.Books.Add(new BookDetailViewModel() { Id = 3, Author = "Author 3", Title = "Title3", ISBN = "isbn3", CreationDate = new DateTime(2016, 11, 18) });
            model.Books.Add(new BookDetailViewModel() { Id = 4, Author = "Author 4", Title = "Title4", ISBN = "isbn4", CreationDate = new DateTime(2015, 9, 2) });

            return View(model);

            //Dictionary<int, BookDetailViewModel> Books = new Dictionary<int, BookDetailViewModel>();


            //Books.Add(1, new BookDetailViewModel() { Id = 1, Author = "Author 1", Title = "Title1", ISBN = "isbn1", CreationDate = new DateTime(2016, 3, 12) });
            //Books.Add(2, new BookDetailViewModel() { Id = 2, Author = "Author 2", Title = "Title2", ISBN = "isbn2", CreationDate = new DateTime(2013, 7, 7) });
            //Books.Add(3, new BookDetailViewModel() { Id = 3, Author = "Author 3", Title = "Title3", ISBN = "isbn3", CreationDate = new DateTime(2016, 11, 18) });
            //Books.Add(4, new BookDetailViewModel() { Id = 4, Author = "Author 4", Title = "Title4", ISBN = "isbn4", CreationDate = new DateTime(2015, 9, 2) });

            // ViewData["Books"] = Books;

            //return View(ViewData);

        }

        [HttpGet("/books/{id}")]
        public IActionResult Detail([FromRoute]int id)
        {

            var model = new BookListViewModel();

            model.Books = new List<BookDetailViewModel>();

            Dictionary<string, BookDetailViewModel> dic = new Dictionary<string, BookDetailViewModel>();

            model.Books.Add(new BookDetailViewModel() { Id = 1, Author = "Author 1", Title = "Title1", ISBN = "isbn1", CreationDate = new DateTime(2016, 3, 12) });
            model.Books.Add(new BookDetailViewModel() { Id = 2, Author = "Author 2", Title = "Title2", ISBN = "isbn2", CreationDate = new DateTime(2013, 7, 7) });
            model.Books.Add(new BookDetailViewModel() { Id = 3, Author = "Author 3", Title = "Title3", ISBN = "isbn3", CreationDate = new DateTime(2016, 11, 18) });
            model.Books.Add(new BookDetailViewModel() { Id = 4, Author = "Author 4", Title = "Title4", ISBN = "isbn4", CreationDate = new DateTime(2015, 9, 2) });

            if (id == 0)
            {
                return new NotFoundResult();
            }

            ViewBag.Message = id;

            return View(model);
        }
    }
}
