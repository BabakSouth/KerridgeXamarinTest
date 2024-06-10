using System.Threading.Tasks;
using KerridgeTask.Interface;
using Microsoft.Maui.Controls;
using KerridgeTask.Pages;
namespace KerridgeTask.Services
{
    public class LoadingService : ILoadingService
    {
        public async Task ShowLoadingAsync(string message = "Loading...")
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoadingPage(message));
        }

        public async Task HideLoadingAsync()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
