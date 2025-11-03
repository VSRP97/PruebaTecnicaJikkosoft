namespace LibraryManager.Controllers.Loans
{
    public class GetLoansPaginatedRequest
    {
        public Guid? BookId { get; set; }
        public Guid? MemberId { get; set; }
    }
}
