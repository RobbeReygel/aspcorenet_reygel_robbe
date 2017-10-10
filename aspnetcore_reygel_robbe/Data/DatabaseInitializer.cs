using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_reygel_robbe.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace aspnetcore_reygel_robbe.Data
{
    public class DatabaseInitializer
    {
        public static void InitializeDatabase(EntityContext entityContext)
        {
            if (((entityContext.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)?.Exists()).GetValueOrDefault(false))
            {
                return;
            }
            var authors = new List<Author>();
            for (var i = 0; i < 20; i++)
            {
                authors.Add(new Author {FirstName = $"Author First Name {i}", LastName = $"Author Last Name {i}"});
            }

            var books = new List<Book>();
            for (var i = 0; i < 20; i++)
            {
                var authorBook = new AuthorBook()
                {
                    Author = authors[i]
                };
                Random r = new Random();
                books.Add(new Book {Title = $"Book {i}", GenreId = r.Next(1, 5), Authors = new List<AuthorBook> {authorBook}});
            }

            var genres = new List<Genre>();
            for (var i = 0; i < 5; i++)
            {
                genres.Add(new Genre { Name = $"Genre {i}" });
            }

            var me = new Author {FirstName = "Raf", LastName = "Ceuls"};
            books[0].Authors.Add(new AuthorBook() { Author = me});

            entityContext.Database.EnsureCreated();
            entityContext.Authors.AddRange(authors);
            entityContext.Books.AddRange(books);
            entityContext.Genres.AddRange(genres);
            entityContext.SaveChanges();
        }
    }
}