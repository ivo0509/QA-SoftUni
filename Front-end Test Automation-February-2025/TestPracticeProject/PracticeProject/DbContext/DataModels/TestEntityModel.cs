using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeProject.DbContext.DataModels
{
    public class TestEntityModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public long Count { get; set; }
    }
}
