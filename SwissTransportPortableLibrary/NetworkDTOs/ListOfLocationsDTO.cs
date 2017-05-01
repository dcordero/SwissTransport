using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SwissTransportPortableLibrary.NetworkDTOs
{
    [DataContract]
    class ListOfLocationsDTO
    {
        [DataMember(Name = "stations")]
        internal List<LocationDTO> Locations { get; set; }
    }
}
