using System;
using System.Runtime.Serialization;

namespace SwissTransportPortableLibrary.NetworkDTOs
{
	[DataContract]
    public class StopDTO
    {
        [DataMember(Name = "station")]
        internal LocationDTO Station { get; set; }

		[DataMember(Name = "departure")]
        internal DateTime Departure { get; set; }

		[DataMember(Name = "delay")]
		internal int? Delay { get; set; }
    }
}
