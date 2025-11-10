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

        public ICollection<Team>? Teams { get; set; }

        //asignación propiedad de lectura con =>, solo se puesde obtener
        public int TeamsCount => Teams == null ? 0 : Teams.Count;
    }
}