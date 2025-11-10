using System.ComponentModel.DataAnnotations;

namespace Predictions.Shared.Entities
{
    public class Team
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = null!;

        public string? Image { get; set; }

        [Required]
        public Country Country { get; set; } = null!;

        public int CountryId { get; set; }
    }
}