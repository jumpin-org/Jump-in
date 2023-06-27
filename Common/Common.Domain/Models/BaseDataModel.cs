using System.ComponentModel.DataAnnotations.Schema;

namespace JumpIn.Common.Domain.Models
{
    public class BaseDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}