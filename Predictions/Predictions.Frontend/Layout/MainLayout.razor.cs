using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Predictions.Shared.Resources;

namespace Predictions.Frontend.Layout
{
    public partial class MainLayout
    {
        [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    }
}