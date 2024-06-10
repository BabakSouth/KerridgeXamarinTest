
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using KerridgeTask.Classes;
using KerridgeTask.Classes.PlaceDetail;
using System.Runtime.CompilerServices;

namespace KerridgeTask.Tests
{
    public class LocationTest
    {
       

        private readonly HttpClient _httpClient;
        private string _accessToken;
        private DateTime _tokenExpiration;
        public LocationTest()
        {
            
            _httpClient = new HttpClient();
        }

        [Fact]
        public async void GetPlacesAsyncExam_Mock_Rasht()
        {

            try
            {
                //Token must be generated one time before expiration. As this is not the ordered of task, so I hit it everytime.
                GlobalVAR.token = await GetAccessTokenAsync();


                var request = new HttpRequestMessage(HttpMethod.Get, ConstParam.BaseURL + $"/location/api/v1/locations/places?criteria=Rasht");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVAR.token);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Place places = JsonConvert.DeserializeObject<Place>(jsonResponse);
                    Tuple<Place, string> tuple = new Tuple<Place, string>(places, "Success");
                    Assert.Equal(tuple.Item1.data[0].mainText, "Rasht");
                    Assert.NotEmpty(tuple.Item1.data);
                }
                else
                {
                    Tuple<Place, string> tuple = new Tuple<Place, string>(new Place { data = new List<OnePlace>() }, "Empty"); // Return an empty result
                    Assert.Null(tuple);
                    Assert.Empty(tuple.Item1.data);                                                                                     //return tuple;

                }
            }
            catch (Exception ex)
            {

                Tuple<Place, string> tuple = new Tuple<Place, string>(new Place { data = new List<OnePlace>() }, "Fail!");
                Assert.NotNull(tuple);
                Assert.Empty(tuple.Item1.data);
            }

          
        }



        [Fact]
        public async void GetPlacesAsyncExam_Mock_lkhugkyfgkjhgv()
        {

            try
            {
                //Token must be generated one time before expiration. As this is not the ordered of task, so I hit it everytime.
                GlobalVAR.token = await GetAccessTokenAsync();


                var request = new HttpRequestMessage(HttpMethod.Get, ConstParam.BaseURL + $"/location/api/v1/locations/places?criteria=lkhugkyfgkjhgv");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVAR.token);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Place places = JsonConvert.DeserializeObject<Place>(jsonResponse);
                    Tuple<Place, string> tuple = new Tuple<Place, string>(places, "Success");
                    Assert.Null(tuple);
                    Assert.Empty(tuple.Item1.data);
                }
                else
                {
                    Tuple<Place, string> tuple = new Tuple<Place, string>(new Place { data = new List<OnePlace>() }, "Empty"); // Return an empty result
                    Assert.Null(tuple.Item1.data);
                    Assert.Empty(tuple.Item1.data);                                                                                     //return tuple;

                }
            }
            catch (Exception ex)
            {

                Tuple<Place, string> tuple = new Tuple<Place, string>(new Place { data = new List<OnePlace>() }, "Fail!");
                Assert.NotNull(tuple.Item1.data);
                Assert.Empty(tuple.Item1.data);
            }


        }


        [Fact]
        //Get a single place detail according to place id
        public async void GetPlaceDetailsAsync_Rasht()
        {

            try
            {
                //Token must be generated one time before expiration. As this is not the ordered of task, so I hit it everytime.
                GlobalVAR.token = await GetAccessTokenAsync();


                var request = new HttpRequestMessage(HttpMethod.Get, ConstParam.BaseURL + $"/location/api/v1/locations/places?criteria=Rasht");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVAR.token);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Place places = JsonConvert.DeserializeObject<Place>(jsonResponse);
                    Tuple<Place, string> tuple = new Tuple<Place, string>(places, "Success");

                    var placeId = tuple.Item1.data[0].placeId;


                    var requestr = new HttpRequestMessage(HttpMethod.Get, ConstParam.BaseURL + $"/location/api/v1/locations/places/{placeId}");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVAR.token);

                    var responser = await _httpClient.SendAsync(requestr);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponser = await response.Content.ReadAsStringAsync();
                        PlaceDetail placeDetail = JsonConvert.DeserializeObject<PlaceDetail>(jsonResponse);
                        Tuple<PlaceDetail, string> tupler = new Tuple<PlaceDetail, string>(placeDetail, "Success");
                        Assert.Equal(tupler.Item1.data.formattedAddress, "Rasht, Gilan Province, Iran");
                        

                    }
                    else
                    {
                        Tuple<PlaceDetail, string> tupler = new Tuple<PlaceDetail, string>(new PlaceDetail(), "Empty"); // Return an empty result
                        Assert.Null(tupler);
                        Assert.Empty(tupler.Item1.data.name);
                    }



                }
                else
                {
                    Tuple<Place, string> tupler = new Tuple<Place, string>(new Place { data = new List<OnePlace>() }, "Empty"); // Return an empty result
                    Assert.Null(tupler);
                    Assert.Empty(tupler.Item1.data);                                           //return tuple;

                }



             
            }
            catch (Exception ex)
            {
                Tuple<PlaceDetail, string> tuple = new Tuple<PlaceDetail, string>(new PlaceDetail(), "Fail!");
                Assert.Null(tuple.Item1.data);
               
            }
        }


        [Fact]
        //Get a single place detail according to place id
        public async void GetPlaceDetailsAsync_lkhugkyfgkjhgv()
        {

            try
            {
                //Token must be generated one time before expiration. As this is not the ordered of task, so I hit it everytime.
                GlobalVAR.token = await GetAccessTokenAsync();


                var request = new HttpRequestMessage(HttpMethod.Get, ConstParam.BaseURL + $"/location/api/v1/locations/places?criteria=lkhugkyfgkjhgv");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVAR.token);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Place places = JsonConvert.DeserializeObject<Place>(jsonResponse);
                    Tuple<Place, string> tuple = new Tuple<Place, string>(places, "Success");

                    var placeId = tuple.Item1.data[0].placeId;
                    Assert.Null(placeId);

                    if (placeId != null)
                    {

                        var requestr = new HttpRequestMessage(HttpMethod.Get, ConstParam.BaseURL + $"/location/api/v1/locations/places/{placeId}");
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GlobalVAR.token);

                        var responser = await _httpClient.SendAsync(requestr);

                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResponser = await response.Content.ReadAsStringAsync();
                            PlaceDetail placeDetail = JsonConvert.DeserializeObject<PlaceDetail>(jsonResponse);
                            Tuple<PlaceDetail, string> tupler = new Tuple<PlaceDetail, string>(placeDetail, "Success");
                            Assert.NotNull(tupler);
                            Assert.NotEmpty(tupler.Item1.data.name);

                        }
                        else
                        {
                            Tuple<PlaceDetail, string> tupler = new Tuple<PlaceDetail, string>(new PlaceDetail(), "Empty"); // Return an empty result
                            Assert.Null(tupler);
                            Assert.Empty(tupler.Item1.data.name);
                        }
                    }



                }
                else
                {
                    Tuple<Place, string> tupler = new Tuple<Place, string>(new Place { data = new List<OnePlace>() }, "Empty"); // Return an empty result
                    Assert.Null(tupler);
                    Assert.Empty(tupler.Item1.data);                                           //return tuple;

                }




            }
            catch (Exception ex)
            {
                Tuple<PlaceDetail, string> tuple = new Tuple<PlaceDetail, string>(new PlaceDetail(), "Fail!");
                Assert.Null(tuple.Item1.data);
               
            }
        }




        private async Task<string> GetAccessTokenAsync()
        {
            if (_accessToken != null && _tokenExpiration > DateTime.UtcNow)
            {
                return _accessToken;
            }

            var request = new HttpRequestMessage(HttpMethod.Post, ConstParam.identityURL + $"/token");

            var parameters = new Dictionary<string, string>
             {
                 { "client_id", "94eb850d-448f-48ef-a085-5fee4807606e.apps.kerridgecs.com" },
                 { "client_secret", "b609f130-2d13-43d4-93df-f8ab9f1cafde" },
                 { "grant_type", "client_credentials" },
                 { "scope", "eos.common.fullaccess" }
             };

            request.Content = new FormUrlEncodedContent(parameters);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tokenData = JObject.Parse(content);
                _accessToken = tokenData["access_token"]?.ToString();
                var expiresIn = tokenData["expires_in"]?.ToObject<int>() ?? 3600;
                _tokenExpiration = DateTime.UtcNow.AddSeconds(expiresIn);
                return _accessToken;
            }

            return "";

        }

    }
}
