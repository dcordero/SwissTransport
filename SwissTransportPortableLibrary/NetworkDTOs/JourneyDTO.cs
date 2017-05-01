using System;
using System.Runtime.Serialization;

namespace SwissTransportPortableLibrary.NetworkDTOs
{
	[DataContract]
	public class JourneyDTO
	{
		[DataMember(Name = "name")]
		internal String Name { get; set; }

		[DataMember(Name = "to")]
		internal String To { get; set; }
	}
}
