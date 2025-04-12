using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
    public string PasswordHash { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}