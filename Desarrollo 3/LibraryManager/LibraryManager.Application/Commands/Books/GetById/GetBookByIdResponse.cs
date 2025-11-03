namespace LibraryManager.Application.Commands.Books.GetById
{
    public class GetBookByIdResponse
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}