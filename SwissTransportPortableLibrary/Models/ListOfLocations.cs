using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransportPortableLibrary
{
    [DataContract]
    public class ListOfLocations
    {
        [DataMember(Name = "stations")]
        public List<Location> Locations { get; set; }
    }
}
