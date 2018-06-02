#region

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Helpers;
using Touch.Models;
using Touch.Services;
using Touch.Views.Pages;

#endregion

namespace Touch.ViewModels
{
    internal class ObjectsViewModel : AcrylicGridViewModel
    {
        private readonly INavigationService _navigationService;

        public ObjectsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        /// <summary>
        ///     Load available objects from database
        /// </summary>
        /// <returns>Void Task</returns>
        public async Task LoadObjectsAsync()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(async () =>
            {
                using (var db = new Database())
                {
                    var distinctLabels = db.Labels.Select(label => label.Index).ToHashSet();
                    await LoadObjectsAsync(distinctLabels, (image, index) => image.IfContainsLabel(index),
                        index => new Category().Get(index));
                }
            });
        }

        /// <summary>
        ///     Navigate to <see cref="ObjectDetailsPage" />
        /// </summary>
        /// <param name="labelObject">Classification object</param>
        public void NavigateToDetailsage(object labelObject)
        {
            _navigationService.NavigateAsync(typeof(ObjectDetailsPage), labelObject);
        }
    }
}