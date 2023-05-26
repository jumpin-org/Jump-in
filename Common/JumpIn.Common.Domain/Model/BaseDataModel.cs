using System.ComponentModel.DataAnnotations.Schema;

namespace JumpIn.Common.Domain.Model
{
    public class BaseDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}