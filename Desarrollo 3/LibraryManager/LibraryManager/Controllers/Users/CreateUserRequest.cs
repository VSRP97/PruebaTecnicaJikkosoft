namespace LibraryManager.Controllers.Users
{
    public record CreateUserRequest(
        string FirstName,
        string? SecondName,
        string LastName,
        string? SecondLastName,
        string Email);
}
