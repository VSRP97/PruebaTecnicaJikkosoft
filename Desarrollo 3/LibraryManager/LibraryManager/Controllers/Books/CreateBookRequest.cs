namespace LibraryManager.Controllers.Books
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string Isbn { get; set; }
    }
}
