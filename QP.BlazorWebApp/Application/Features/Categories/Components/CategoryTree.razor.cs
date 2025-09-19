using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MP;

namespace QP.BlazorWebApp.Application.Features.Categories.Components
{
    public partial class CategoryTree : FluxorComponent
    {
        [Parameter] public List<CategoryDto> Categories { get; set; } = new();
        private string search = string.Empty;

        private bool IncludeRoot(CategoryDto root, List<CategoryDto> children)
            => string.IsNullOrWhiteSpace(search)
               || Match(root.Name) || Match(root.Slug)
               || children.Any(c => Match(c.Name) || Match(c.Slug));

        private bool Match(string? s)
            => !string.IsNullOrWhiteSpace(s)
               && s.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
