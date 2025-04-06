using System.ComponentModel.DataAnnotations;

namespace Toplearn.DataLayer.Entities.User;

public class UserRole
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    #region Relations 

    public virtual User User { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;

    #endregion
}
