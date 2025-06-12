namespace Bookiby.Domain.Users;

public sealed class Permission(int id, string name)
{
    public int Id { get; init; } = id;
    public string Name { get; set; } = name;
    
    public static readonly Permission UsersRead = new(1, "users:read");
}