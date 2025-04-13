using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeFit.Models
{
    public class TrainingSession
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data rozpoczęcia")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Data zakończenia")]
        public DateTime EndTime { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;
    }
}
