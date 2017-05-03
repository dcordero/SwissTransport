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
        internal StopDTO Stop { get; set; }

        [DataMember(Name = "passList")]
        internal List<StopDTO> PassList { get; set; }
    }
}
