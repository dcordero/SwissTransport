using System;
namespace SwissTransportPortableLibrary.Models
{
    public class Stop
    {
		public Location Station { get; private set; }
        public DateTime Departure { get; private set; }
		public int? Delay { get; private set; }


		internal Stop(Location station, DateTime departure, int? delay)
		{
			Station = station;
            Departure = departure;
            Delay = delay;
		}
    }
}
