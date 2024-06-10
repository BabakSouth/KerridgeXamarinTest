using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using KerridgeTask.Services;
using Microsoft.Maui.Controls;
using KerridgeTask.Classes;
using System.Numerics;
using KerridgeTask.Interface;
namespace KerridgeTask.ViewModels
{
    public class PlaceDetailViewModel : BindableObject
    {
        public readonly TokenService _tokenService;
        private readonly LocationService _locationService;
        private readonly LoadingService _loadingService;
        private ObservableCollection<OnePlace> _places;
        private readonly AlertService _alertService;
        private string _searchQuery;
        private bool _isBusy;

        public PlaceDetailViewModel()
        {
            _tokenService = App.Services.GetService<TokenService>();
            _alertService = App.Services.GetService<AlertService>();
            _loadingService = App.Services.GetService<LoadingService>();
            _locationService = App.Services.GetService<LocationService>();
            SearchCommand = new Command(async () => await OnSearchAsync());
            Places = new ObservableCollection<OnePlace>();
        }
     


        public ObservableCollection<OnePlace> Places
        {
            get => _places;
            set
            {
                _places = value;
                OnPropertyChanged();
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; }

        private async Task OnSearchAsync()
        {
            if (IsBusy) return;
            await _loadingService.ShowLoadingAsync();
            try
            {
                IsBusy = true;
                Places.Clear();
                var result = await _locationService.GetPlacesAsync(SearchQuery);
                if (result.Item1.data == null || result.Item1.data.Count == 0)
                {
                  
                    await _alertService.DisplayAlert("No Places Found", "No places were found matching the search criteria.", "OK");
                }


               // if (result.Item2 != "Success" && result.Item2 !="Empty") await DisplayAlert("Error", result.Item2, "OK");

                if (result.Item1.data != null)
                {
                    foreach (var place in result.Item1.data)
                    {
                        Places.Add(place);
                    }
                }
               

               
            }
            finally
            {
                await _loadingService.HideLoadingAsync();
                IsBusy = false;
            }
        }
    }
}
