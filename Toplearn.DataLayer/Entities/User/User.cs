using System.ComponentModel.DataAnnotations;

namespace Toplearn.DataLayer.Entities.User;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Display(Name = "")]
    [Required(ErrorMessage = "")]
    [MaxLength(200, ErrorMessage = "")]
    public string UserName { get; set; } = null!;

    [Display(Name = "")]
    [Required(ErrorMessage = "")]
    [MaxLength(200, ErrorMessage = "")]
    [EmailAddress(ErrorMessage = "")]
    public string Email { get; set; } = null!;

    [Display(Name = "")]
    [Required(ErrorMessage = "")]
    [MaxLength(100, ErrorMessage = "")]
    public string Password { get; set; } = null!;

    [Display(Name = "")]
    [MaxLength(50, ErrorMessage = "")]
    public string? ActiveCode { get; set; }

    [Display(Name = "")]
    public bool IsActive { get; set; }

    [Display(Name = "")]
    [MaxLength(200, ErrorMessage = "")]
    public string? UserAvatar { get; set; }

    [Display(Name = "")]
    public DateTime RegisterDate { get; set; }

    #region Relations

    public virtual List<UserRole> UserRoles { get; set; } = null!;

    #endregion
}
