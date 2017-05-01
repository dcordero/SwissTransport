using System;
using System.Runtime.Serialization;

namespace SwissTransportPortableLibrary.NetworkDTOs
{
    [DataContract]
    public class StationboardDTO
    {
		[DataMember(Name = "station")]
        public LocationDTO Station { get; set; } 
    }
}
