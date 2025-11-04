using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Predictions.Shared.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = null!;
    }
}