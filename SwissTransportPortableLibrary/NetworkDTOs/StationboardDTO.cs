using System;
using System.Runtime.Serialization;

namespace SwissTransportPortableLibrary.NetworkDTOs
{
    [DataContract]
    class StationboardDTO
    {
		[DataMember(Name = "station")]
        internal LocationDTO Station { get; set; } 
    }
}
