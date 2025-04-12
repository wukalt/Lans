using System.ComponentModel.DataAnnotations;

namespace Lans.DataLayer.Entities.User;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "نام اجباری میباشد")]
    [MaxLength(200, ErrorMessage = "طول نام نمیتواند بیشتر از {0} باشد")]
    public string UserName { get; set; } = null!;

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "ایمیل اجباری میباشد")]
    [MaxLength(200, ErrorMessage = "طول ایمیل نمیتواند از {0} بیشتر باشد")]
    [EmailAddress(ErrorMessage = "فرمت وارد شده درست نمیباشد")]
    public string Email { get; set; } = null!;

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "کلمه عبور اجباری میباشد")]
    [MaxLength(100, ErrorMessage = "طول کلمه عبور نمیتواند از {0} بیشتر باشد")]
    public string Password { get; set; } = null!;

    [Display(Name = "کد فعالسازی")]
    [MaxLength(50, ErrorMessage = "طول کد فعالسازی نمیتواند از {0} بیشتر باشد")]
    public string? ActiveCode { get; set; }

    [Display(Name = "وضعیت")]
    public bool IsActive { get; set; }

    [Display(Name = "آواتار")]
    [MaxLength(200, ErrorMessage = "طول آواتار نمیتواند از {0} بیشتر باشد")]
    public string? UserAvatar { get; set; }

    [Display(Name = "تاریخ ثبت نام")]
    public DateTime RegisterDate { get; set; }

    #region Relations

    public virtual List<UserRole> UserRoles { get; set; } = null!;

    #endregion
}
