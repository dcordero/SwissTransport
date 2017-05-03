using System;
using System.Runtime.Serialization;

namespace SwissTransportPortableLibrary.NetworkDTOs
{
    [DataContract]
    public class StopDTO
    {
        [DataMember(Name = "station")]
        internal LocationDTO Station { get; set; }

        [DataMember(Name = "arrival")]
        internal String Arrival { get; set; }

        [DataMember(Name = "arrivalTimestamp")]
        internal int? ArrivalTimestamp { get; set; }

        [DataMember(Name = "departure")]
        internal String Departure { get; set; }

        [DataMember(Name = "departureTimestamp")]
        internal int? DepartureTimeStamp { get; set; }

        [DataMember(Name = "platform")]
        internal String Platform { get; set; }

        [DataMember(Name = "delay")]
        internal int? Delay { get; set; }
    }
}
