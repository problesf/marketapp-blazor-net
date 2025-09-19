using Fluxor;
using QP.BlazorWebApp.Application.Features.Categories.Store.State;
using static QP.BlazorWebApp.Application.Features.Categories.Store.Actions.CategoryActions;

namespace QP.BlazorWebApp.Application.Features.Categories.Store.Reducers
{
    public class CategoryReducer
    {
        [ReducerMethod]
        public static CategoryState ReduceLoadCategories(CategoryState state, LoadCategories Action)
        {
            return state with { CategoriesLoading = true };


        }
        [ReducerMethod]
        public static CategoryState ReduceLoadCategoriesSuccess(CategoryState state, LoadCategoriesSuccess Action)
        {
            return state with
            {
                CategoriesLoading = false,
                Categories = Action.Categories
            };
        }


        [ReducerMethod]
        public static CategoryState ReduceLoadCategoriesError(CategoryState state, LoadCategoriesError Action)
        {
            return state with { CategoriesLoading = false };

        }

        [ReducerMethod]
        public static CategoryState ReduceCreateCategory(CategoryState state, CreateCategory Action)
        {
            return state with { CategoriesLoading = true };


        }
        [ReducerMethod]
        public static CategoryState ReduceCreateCategorySuccess(CategoryState state, CreateCategorySuccess Action)
        {
            return state with
            {
                CategoriesLoading = false,
                Categories = [.. state.Categories, Action.Category]
            };
        }


        [ReducerMethod]
        public static CategoryState ReduceCreateCategoryError(CategoryState state, CreateCategoryError Action)
        {
            return state with { CategoriesLoading = false };

        }
    }
}
