using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SwissTransportPortableLibrary.NetworkDTOs
{
    [DataContract]
    public class ListOfLocationsDTO
    {
        [DataMember(Name = "stations")]
        public List<LocationDTO> Locations { get; set; }
    }
}
