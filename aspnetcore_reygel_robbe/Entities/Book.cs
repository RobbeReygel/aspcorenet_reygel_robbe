using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetcore_reygel_robbe.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
        public virtual List<AuthorBook> Authors { get; set; }
    }
}
