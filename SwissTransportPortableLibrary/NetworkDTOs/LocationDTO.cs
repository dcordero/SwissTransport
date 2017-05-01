using System;
using System.Runtime.Serialization;

namespace SwissTransportPortableLibrary.NetworkDTOs
{
    [DataContract]
	class LocationDTO
	{
        [DataMember(Name = "id")]
        internal String Id { get; set; }

        [DataMember(Name = "type")]
		internal string Type { get; set; }

        [DataMember(Name = "name")]
		internal string Name { get; set; }
	}
}
