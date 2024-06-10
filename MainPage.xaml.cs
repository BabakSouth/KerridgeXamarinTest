using KerridgeTask.Services;
using KerridgeTask.Pages;
using Microsoft.Maui.Controls;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using KerridgeTask.Classes;

using KerridgeTask.Interface;
using KerridgeTask.ViewModels;
namespace KerridgeTask
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
          

        }


        private async void OnPlaceSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is OnePlace selectedPlace)
            {
                // Clear the selection
                PlacesListView.SelectedItem = null;

                // Navigate to the PlaceDetailsPage with the selected place ID
                await Navigation.PushAsync(new PlaceDetailsPage(selectedPlace.placeId));
            }

        }
    }
}

