using System;
namespace SwissTransportPortableLibrary.Models
{
    public class Stop
    {
        public Location Station { get; private set; }
        public DateTime Arrival { get; private set; }
        public DateTime Departure { get; private set; }
        public String Platform { get; private set; }
        public int? Delay { get; private set; }


        internal Stop(Location station, DateTime arrival, DateTime departure, String platform, int? delay)
        {
            Station = station;
            Arrival = arrival;
            Departure = departure;
            Platform = platform;
            Delay = delay;
        }
    }
}
