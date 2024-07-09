using FromNumberToText.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FromNumberToText.Domain.FromNumberToText;

public class FromNumberToTextEntity : EntityBase
{
    [Key]
    [Column("IdNumber")]
    public int NumberId { get; set; }

    public string Number { get; set; }
}
