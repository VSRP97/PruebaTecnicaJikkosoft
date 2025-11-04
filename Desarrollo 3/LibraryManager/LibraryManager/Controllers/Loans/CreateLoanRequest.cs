namespace LibraryManager.Controllers.Loans
{
    public class CreateLoanRequest
    {
        //Guid LibraryBookId,
        //Guid MemberId,
        //int LoanQuantity,
        //DateTime ExpectedReturnDate
        public Guid LibraryBookId { get; set; }
        public Guid MemberId { get; set; }
        public int LoanQuantity { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }
}