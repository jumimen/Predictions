using Microsoft.AspNetCore.Components;
using Predictions.Frontend.Repositories;
using Predictions.Shared.Entities;

namespace Predictions.Frontend.Pages.Countries
{
    public partial class CountriesIndex
    {
        [Inject]
        private IRepository Repository { get; set; } = null!;

        private List<Country>? Countries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repository.GetAsync<List<Country>>("api/countries");
            Countries = responseHttp.Response?.OrderBy(c => c.Id).ToList();
        }
    }
}