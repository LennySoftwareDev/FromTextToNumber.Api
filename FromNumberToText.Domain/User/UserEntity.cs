using FromNumberToText.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FromNumberToText.Domain.User;

public class UserEntity : EntityBase
{
    [Key]
    [Column("IdUser")]
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
