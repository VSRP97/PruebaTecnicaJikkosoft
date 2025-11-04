namespace LibraryManager.Application.Commands.LibraryBooks.GetById
{
    public class GetLibraryBookByIdResponse
    {
        public Guid Id { get; set; }
        public Guid LibraryId { get; set; }
        public Guid BookId { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public string LibraryName { get; set; }
        public string BookTitle { get; set; }
    }
}