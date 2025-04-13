using System.ComponentModel.DataAnnotations;

namespace BeFit.Models.ViewModels
{
    public class ExerciseStatsViewModel
    {
        [Key]
        public int Id { get; set; }

        public string ExerciseName { get; set; }
        public int TotalReps { get; set; }
        public int TotalSets { get; set; }
        public int TotalLoad { get; set; }
    }

}
