using System;
namespace SwissTransportPortableLibrary.Models
{
    public class Stationboard
    {
		public Location Station { get; private set; }

		internal Stationboard(Location station)
		{
			Station = station;
		}
	}
}
