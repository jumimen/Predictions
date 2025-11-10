using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Predictions.Frontend.Repositories;
using Predictions.Shared.Entities;
using Predictions.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace Predictions.Frontend.Pages.Countries
{
    public partial class CountriesIndex
    {
        [Inject]
        private IRepository Repository { get; set; } = null!;

        private List<Country>? Countries { get; set; }
        [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task LoadAsync()
        {
            var responseHttp = await Repository.GetAsync<List<Country>>("api/countries");
            if (!responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync(Localizer["Error"], message, SweetAlertIcon.Error);
                return;
            }
            Countries = responseHttp.Response?.OrderBy(c => c.Id).ToList();
        }

        private async Task DeleteCountryAsync(Country country)
        {
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = Localizer["Confirmation"],
                Text = string.Format(Localizer["DeleteConfirm"], Localizer["Country"], country.Name),
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
            });
            var confirm = string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }
            var responseHttp = await Repository.DeleteAsync<Country>($"api/countries/{country.Id}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    var messageError = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync(Localizer["Error"], messageError!, SweetAlertIcon.Error);
                }
                return;
            }

            await LoadAsync();

            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.TopEnd,
                ShowConfirmButton = true,
                Timer = 3000,
                ConfirmButtonText = Localizer["Yes"]
            });
            toast.FireAsync(message: Localizer["RecordDeletedOk"], icon: SweetAlertIcon.Success);
        }
    }
}