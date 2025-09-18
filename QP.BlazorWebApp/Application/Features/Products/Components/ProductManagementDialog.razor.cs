using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MP;
using MudBlazor;
using QP.BlazorWebApp.Application.Features.Products.Model;

namespace QP.BlazorWebApp.Application.Features.Products.Components
{
    public partial class ProductManagementDialog : FluxorComponent
    {
        [Parameter] public ProductDto? ProductParam { get; set; }

        [CascadingParameter] public IMudDialogInstance? MudDialog { get; set; }

        private ProductEditModel _model = new();
        private MudForm? _form;
        private bool IsEdit => ProductParam is not null;
        private string[] _currencies = { "USD", "EUR", "YEN" };
        protected override void OnParametersSet()
        {
            if (IsEdit)
            {
                _model = new ProductEditModel
                {
                    Id = ProductParam!.Id,
                    Name = ProductParam.Name,
                    Price = ProductParam.Price.HasValue
                            ? ProductParam.Price.Value
                            : null
                };
            }
            else
            {
                _model = new ProductEditModel();
            }
        }

        private async Task Save()
        {
            if (_form is null) return;
            await _form.Validate();
            if (!_form.IsValid) return;

            var result = new ProductDto
            {
                Id = _model.Id,
                Name = _model.Name?.Trim(),
                Price = _model.Price.HasValue ? _model.Price.Value : null,
                Code = _model.Code,
                Categories = null,
                Currency = _model.Currency,
                Description = _model.Description,
                Stock = _model.Stock,
                TaxRate = _model.TaxRate
            };

            MudDialog?.Close(DialogResult.Ok(result));
        }

        private void Cancel() => MudDialog?.Cancel();

        private async Task<IEnumerable<string>> Search(string value, CancellationToken token)
        {
            await Task.Delay(5, token);

            if (string.IsNullOrEmpty(value))
            {
                return _currencies;
            }

            return _currencies.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
