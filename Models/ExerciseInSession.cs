using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeFit.Models
{
    public class ExerciseInSession
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Typ ćwiczenia")]
        public int ExerciseTypeId { get; set; }

        [ForeignKey("ExerciseTypeId")]
        public virtual ExerciseType? ExerciseType { get; set; }

        [Required]
        [Display(Name = "Sesja treningowa")]
        public int TrainingSessionId { get; set; }

        [ForeignKey("TrainingSessionId")]
        public virtual TrainingSession? TrainingSession { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Obciążenie (kg)")]
        public int Load { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Liczba serii")]
        public int Sets { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Liczba powtórzeń")]
        public int Reps { get; set; }
    }
}
