using PracticeProject.DbContext.DataModels;
using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models
{
    public class EntityViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string? Description { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [Range(typeof(long), "1", "9223372036854775806")]
        public long Count { get; set; }
    }
}
