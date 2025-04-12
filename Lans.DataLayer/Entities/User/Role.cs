using System.ComponentModel.DataAnnotations;

namespace Lans.DataLayer.Entities.User;

public class Role
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "نقش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد")]
    public string RoleTitle { get; set; } = null!;

    #region Relations

    public virtual List<UserRole> UserRoles { get; set; } = null!;

    #endregion
}
