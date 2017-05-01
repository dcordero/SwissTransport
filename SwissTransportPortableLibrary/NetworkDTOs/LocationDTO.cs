using System;
using System.Runtime.Serialization;

namespace SwissTransportPortableLibrary.NetworkDTOs
{
    [DataContract]
	public class LocationDTO
	{
        [DataMember(Name = "id")]
        public String Id { get; set; }

        [DataMember(Name = "type")]
		public string Type { get; set; }

        [DataMember(Name = "name")]
		public string Name { get; set; }
	}
}
