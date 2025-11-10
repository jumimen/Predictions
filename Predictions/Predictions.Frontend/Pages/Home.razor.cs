using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Predictions.Shared.Resources;

namespace Predictions.Frontend.Pages.Countries
{
    public partial class Home
    {
        [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    }
}