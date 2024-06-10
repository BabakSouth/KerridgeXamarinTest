using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KerridgeTask.Classes;
using KerridgeTask.Classes.PlaceDetail;
namespace KerridgeTask.Interface
{
    public interface ILocationService
    {
        Task<Tuple<Place, string>> GetPlacesAsync(string query);
        Task<Tuple<PlaceDetail, string>> GetPlaceDetailsAsync(string placeId);
    }
}
