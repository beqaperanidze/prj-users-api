using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models;

public class User(int id, string username, string email, string passwordHash, string firstName, string lastName)
{
    public int Id { get; set; } = id;

    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
    public string Username { get; set; } = username;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    public string Email { get; set; } = email;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
    public string PasswordHash { get; set; } = passwordHash;

    public string FirstName { get; set; } = firstName;

    public string LastName { get; set; } = lastName;
}