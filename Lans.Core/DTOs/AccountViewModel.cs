using System.ComponentModel.DataAnnotations;

namespace Lans.Core.DTOs;

public class RegisterViewModel
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

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "کلمه عبور اجباری میباشد")]
    [MaxLength(100, ErrorMessage = "طول کلمه عبور نمیتواند از {0} بیشتر باشد")]
    [Compare("Password", ErrorMessage = "کلمه عبور مطابقت ندارد")]
    public string ReEnterPassword { get; set; } = null!;
}
