using System;
using System.Collections.Generic;
using System.Linq;
using aspnetcore_reygel_robbe.Data;
using aspnetcore_reygel_robbe.Models;
using aspnetcore_reygel_robbe.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_reygel_robbe.Controllers
{
    public class BookController : Controller
    {
        private readonly EntityContext _entityContext;

        public BookController(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }
        
        [HttpGet("/books")]
        public IActionResult Index()
        {
            var model = new BookListViewModel();
            model.Books = new List<BookDetailViewModel>();
            var allBooks = _entityContext.Books.Include(x => x.Authors).ThenInclude(x => x.Author).ToList();
            foreach (var book in allBooks)
            {
                var vm = ConvertBookDetailViewModel(book);
                model.Books.Add(vm);
            }
            return View(model);
        }

        private static BookDetailViewModel ConvertBookDetailViewModel(Book book)
        {
            var vm = new BookDetailViewModel();
            vm.Id = book.Id;
            vm.Title = book.Title;
            //vm.Genre = book.GenreId;
            vm.Author = String.Join(",", book.Authors.Select(x => x.Author.FullName));            
            return vm;
        }

        [HttpGet("/books/{id}")]
        public IActionResult Detail([FromRoute] int id)
        {   
            /*
            var vm = new BookDetailViewModel();
            var instance = _entityContext.Books.Include(x => x.Authors).FirstOrDefault(x => x.Id == id);
            if (instance == null)
            {
                return NotFound();
            }
            vm = ConvertBookDetailViewModel(instance);
            return View(vm);
            */
            var book = _entityContext.Books.Include(x => x.Authors).ThenInclude(x => x.Author).FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            var vm = new BookDetailViewModel();
            foreach (var ba in book.Authors)
            {
                vm.Author += $"{ba.Author.FullName}, ";
            }
            vm.Title = book.Title;
            vm.Id = book.Id;
            return View(vm);
        }
        
    }
}