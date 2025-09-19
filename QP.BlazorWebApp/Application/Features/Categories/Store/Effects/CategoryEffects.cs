using Fluxor;
using Microsoft.AspNetCore.Components;
using MP;
using MudBlazor;
using static QP.BlazorWebApp.Application.Features.Categories.Store.Actions.CategoryActions;

namespace QP.BlazorWebApp.Application.Features.Categories.Store.Effects
{
    public class CategoryEffects
    {
        private readonly IMPApi _api;
        private readonly ISnackbar _snackbar;
        private readonly NavigationManager _nav;

        public CategoryEffects(IMPApi api, ISnackbar snackbar, NavigationManager nav)
        {
            _api = api;
            _snackbar = snackbar;
            _nav = nav;
        }

        [EffectMethod]
        public async Task HandleLoadCategories(LoadCategories action, IDispatcher dispatcher)
        {
            try
            {
                var response = await _api.CategoriesAllAsync(null, null, null, null, null, null);
                dispatcher.Dispatch(new LoadCategoriesSuccess(response));

            }
            catch (ApiException ex)
            {
                _snackbar.Add("Error al recuperar categories", Severity.Error);
                dispatcher.Dispatch(new LoadCategoriesError(ex.Message));
            }
        }

        [EffectMethod]
        public async Task HandleCreateCategory(CreateCategory action, IDispatcher dispatcher)
        {
            try
            {
                CreateCategoryCommand command = new()
                {
                    Slug = action.Category.Slug,
                    Name = action.Category.Name,
                    Description = action.Category.Description,
                };
                var category = await _api.CategoriesPOSTAsync(command);
                dispatcher.Dispatch(new CreateCategorySuccess(category));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new CreateCategoryError(ex.Message));
            }
        }
    }
}
