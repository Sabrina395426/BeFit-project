using BeFit.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BeFit.Models.ViewModels;

namespace BeFit.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<ExerciseType> ExerciseType { get; set; }
        public DbSet<TrainingSession> TrainingSession { get; set; }
        public DbSet<ExerciseInSession> ExercisesInSession { get; set; }
        public DbSet<BeFit.Models.ExerciseType> ExerciseTypes { get; set; }
        public DbSet<BeFit.Models.ViewModels.ExerciseStatsViewModel> ExerciseStatsViewModel { get; set; } = default!;

    }



}

