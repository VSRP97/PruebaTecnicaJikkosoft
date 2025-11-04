namespace LibraryManager.Application.Commands.Members.GetById
{
    public class GetMemberByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}