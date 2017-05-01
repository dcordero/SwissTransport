using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SwissTransportPortableLibrary.NetworkDTOs
{
	[DataContract]
	public class JourneyDTO
	{
		[DataMember(Name = "name")]
		internal String Name { get; set; }

		[DataMember(Name = "to")]
		internal String To { get; set; }

        [DataMember(Name = "stop")]
        internal StopDTO stop { get; set; }
	}
}
