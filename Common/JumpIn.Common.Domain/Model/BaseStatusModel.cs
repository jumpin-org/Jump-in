using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JumpIn.Common.Domain.Model
{
    public class BaseStatusModel
    {
        public BaseStatusModel(string description)
        {
            Description = description;
        }

        protected BaseStatusModel()
        {
        }

        [StringLength(25, ErrorMessage = "The Name value cannot exceed 25 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(128, ErrorMessage = "The Description value cannot exceed 128 characters.")]
        public string Description { get; set; }
    }
}