namespace aspnetcore_reygel_robbe.Entities
{
    public class AuthorBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}