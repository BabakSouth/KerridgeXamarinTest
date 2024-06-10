using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using KerridgeTask.Classes;
using Newtonsoft.Json;
using KerridgeTask.Classes.PlaceDetail;
using System.Numerics;
using KerridgeTask.Interface;
namespace KerridgeTask.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenService _tokenService;

        public LocationService(TokenService tokenService)
        {
            _httpClient = new HttpClient();
            _tokenService = tokenService;

        }


       //Search a Place according to one single input
        public async Task<Tuple<Place,string>> GetPlacesAsync(string query)
        {
            try
            {
                //Token must be generated one time before expiration. As this is not the ordered of task, so I hit it everytime.
                GlobalVAR.token = await _tokenService.GetAccessTokenAsync();
              

                var request = new HttpRequestMessage(HttpMethod.Get, ConstParam.BaseURL +$"/location/api/v1/locations/places?criteria={query}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVAR.token);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Place places = JsonConvert.DeserializeObject<Place>(jsonResponse);
                    Tuple<Place, string> tuple = new Tuple<Place, string> ( places, "Success" );
                    return tuple;
                }
                else
                {
                    Tuple<Place, string> tuple = new Tuple<Place, string>(new Place { data = new List<OnePlace>() }, "Empty"); // Return an empty result
                    return tuple;
                }
            }
            catch (Exception ex)
            {
               
                Tuple<Place, string> tuple = new Tuple<Place, string>(new Place { data = new List<OnePlace>() }, "Fail!"); 
                return tuple; 
            }
        }



        //Get a single place detail according to place id
        public async Task<Tuple<PlaceDetail,string>> GetPlaceDetailsAsync(string placeId)
        {

            try
            {
                //Token must be generated one time before expiration. As this is not the ordered of task, so I hit it everytime.
                GlobalVAR.token = await _tokenService.GetAccessTokenAsync();


                var request = new HttpRequestMessage(HttpMethod.Get, ConstParam.BaseURL + $"/location/api/v1/locations/places/{placeId}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVAR.token);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    PlaceDetail placeDetail = JsonConvert.DeserializeObject<PlaceDetail>(jsonResponse);
                    Tuple<PlaceDetail, string> tuple = new Tuple<PlaceDetail, string>(placeDetail, "Success");
                    return tuple;

                }
                else
                {
                    Tuple<PlaceDetail, string> tuple = new Tuple<PlaceDetail, string>(new PlaceDetail(), "Empty"); // Return an empty result
                    return tuple; // Return an empty result
                }
            }
            catch (Exception ex) 
            {
                Tuple<PlaceDetail, string> tuple = new Tuple<PlaceDetail, string>(new PlaceDetail(), "Fail!");
                return tuple;
            }
        }

    }
}
