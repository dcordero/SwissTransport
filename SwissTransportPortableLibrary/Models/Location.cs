using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SwissTransportPortableLibrary
{
    [DataContract]
	public class Location
	{
        [DataMember(Name = "id")]
        public String Id { get; set; }

        [DataMember(Name = "type")]
		public string Type { get; set; }

        [DataMember(Name = "name")]
		public string Name { get; set; }
	}
}
