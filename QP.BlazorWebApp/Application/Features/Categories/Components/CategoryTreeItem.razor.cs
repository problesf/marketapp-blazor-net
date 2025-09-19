using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MP;

namespace QP.BlazorWebApp.Application.Features.Categories.Components
{
    public partial class CategoryTreeItem : FluxorComponent
    {
        [Parameter] public CategoryDto Node { get; set; } = default!;
        [Parameter] public List<CategoryDto> Children { get; set; } = new();
        [Parameter] public string? Search { get; set; }

        private IEnumerable<CategoryDto> FilteredChildren =>
            string.IsNullOrWhiteSpace(Search) || Match(Node.Name) || Match(Node.Slug)
              ? Children
              : Children.Where(c => Match(c.Name) || Match(c.Slug));

        private bool Match(string? s) =>
            !string.IsNullOrWhiteSpace(s)
            && s.Contains(Search!, StringComparison.OrdinalIgnoreCase);

        private static string Desc(string? d) =>
            string.IsNullOrWhiteSpace(d) ? "Sin descripción" : d!;
    }
}
