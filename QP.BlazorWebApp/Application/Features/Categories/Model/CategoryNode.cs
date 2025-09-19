namespace QP.BlazorWebApp.Application.Features.Categories.Model
{
    public class CategoryNode
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public List<CategoryNode> Children { get; set; } = new();
    }
}
