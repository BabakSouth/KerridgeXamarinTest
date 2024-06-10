using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerridgeTask.Classes
{
    public class OnePlace
    {
        public string? placeId { get; set; }
        public string? description { get; set; }
        public string? mainText { get; set; }
        public string? secondaryText { get; set; }
        public List<Term>? terms { get; set; }
        public List<int>? types { get; set; }
    }

}
