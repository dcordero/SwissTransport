using System;
using System.Collections.Generic;
using SwissTransportPortableLibrary.Models;
using SwissTransportPortableLibrary.NetworkDTOs;

namespace SwissTransportPortableLibrary.Transformers
{
    class StopDTOToModel
    {
		internal static List<Stop> Transform(List<StopDTO> stopsDTO)
		{
			List<Stop> stops = new List<Stop>();
			foreach (StopDTO stopDTO in stopsDTO)
			{
				stops.Add(Transform(stopDTO));
			}
			return stops;
		}

        internal static Stop Transform(StopDTO stopDTO)
        {
            return new Stop(LocationsDTOToModel.Transform(stopDTO.Station),
                            (stopDTO.Arrival == null) ? (DateTime?)null : DateTime.Parse(stopDTO.Arrival, null, System.Globalization.DateTimeStyles.RoundtripKind),
                            (stopDTO.Departure == null) ? (DateTime?)null : DateTime.Parse(stopDTO.Departure, null, System.Globalization.DateTimeStyles.RoundtripKind),
                            stopDTO.Platform,
                            stopDTO.Delay);
        }
    }
}
