using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SwissTransportPortableLibrary.NetworkDTOs
{
    [DataContract]
    class StationboardDTO
    {
		[DataMember(Name = "station")]
        internal LocationDTO Station { get; set; }

		[DataMember(Name = "stationboard")]
        internal List<JourneyDTO> Journeys { get; set; }
	}
}
