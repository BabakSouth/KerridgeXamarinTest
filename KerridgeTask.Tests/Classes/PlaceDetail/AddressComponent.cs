using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerridgeTask.Classes.PlaceDetail
{
    public class AddressComponent
    {
        public string? shortName { get; set; }
        public string? longName { get; set; }
        public List<int>? types { get; set; }
    }
}
