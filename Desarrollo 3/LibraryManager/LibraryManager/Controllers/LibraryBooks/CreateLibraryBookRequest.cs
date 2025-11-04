namespace LibraryManager.Controllers.LibraryBooks
{
    public class CreateLibraryBookRequest
    {
        public Guid LibraryId { get; set; }
        public Guid BookId { get; set; }
        public int TotalCopies { get; set; }
    }
}
