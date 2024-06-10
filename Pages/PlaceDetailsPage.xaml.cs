
using KerridgeTask.Services;
using Microsoft.Maui.Controls;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using KerridgeTask.Interface;
using KerridgeTask.ViewModels;
namespace KerridgeTask.Pages
{
    public partial class PlaceDetailsPage : ContentPage
    {
        private readonly LocationService _locationService;
      
        private readonly string _placeId;

        public PlaceDetailsPage(string placeId)
        {
            InitializeComponent();
            _locationService = App.Services.GetService<LocationService>();
            _placeId = placeId;
            LoadPlaceDetails();
           
        }

        private async Task LoadPlaceDetails()
        {
            var placeDetails = await _locationService.GetPlaceDetailsAsync(_placeId);
            NameLabel.Text = placeDetails.Item1.data.name?.ToString();
            AddressLabel.Text = placeDetails.Item1.data.formattedAddress?.ToString();
            VicinityLabel.Text = placeDetails.Item1.data.vicinity?.ToString();
            UrlLabel.Text = placeDetails.Item1.data.url?.ToString();
            LatLngLabel.Text = $"Lat: {placeDetails.Item1.data.latitude}, Lng: {placeDetails.Item1.data.longitude}";
            UtcOffsetLabel.Text = placeDetails.Item1.data.utcOffset.ToString();
        }
     
    }
}