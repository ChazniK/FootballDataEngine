using System.ComponentModel.DataAnnotations;

namespace FootballDataEngine.Api.Models.Match
{
    public class MatchDto: BaseDto
    {
        [Required]
        [StringLength(100)]
        public string MatchType { get; set; } = null!;

        [Required]
        public DateTime MatchDateTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string League { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string HomeTeam { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string AwayTeam { get; set; } = null!;

        [Required]
        public decimal AverageGoals { get; set; }

        public decimal? MatchTypeSuccessRate { get; set; }
    }
}
