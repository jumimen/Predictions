using System.ComponentModel.DataAnnotations;

namespace Predictions.Shared.Entities
{
    [Microsoft.EntityFrameworkCore.Index(nameof(Name), IsUnique = true)]
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = null!;
    }
}