using System;
namespace SwissTransportPortableLibrary.Models
{
    public class Stationboard
    {
		public Location Station { get; private set; }

		public Stationboard(Location station)
		{
			Station = station;
		}
	}
}
