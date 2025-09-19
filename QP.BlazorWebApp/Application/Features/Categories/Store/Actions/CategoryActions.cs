using MP;

namespace QP.BlazorWebApp.Application.Features.Categories.Store.Actions
{
    public class CategoryActions
    {
        public record LoadCategories();
        public record LoadCategoriesSuccess(ICollection<CategoryDto> Categories);
        public record LoadCategoriesError(string ErrorMessage);

        public record CreateCategory(CategoryDto Category);
        public record CreateCategorySuccess(CategoryDto Category);
        public record CreateCategoryError(string ErrorMessage);
    }
}
