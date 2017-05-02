using System;
using SwissTransportPortableLibrary.Models;
using SwissTransportPortableLibrary.NetworkDTOs;

namespace SwissTransportPortableLibrary.Transformers
{
    class StopDTOToModel
    {
        internal static Stop Transform(StopDTO stopDTO)
        {
            return new Stop(LocationsDTOToModel.Transform(stopDTO.Station),
                            DateTime.Now, // Parse(stopDTO.Arrival, null, System.Globalization.DateTimeStyles.RoundtripKind),
                            DateTime.Now, // Parse(stopDTO.Departure, null, System.Globalization.DateTimeStyles.RoundtripKind),
                            stopDTO.Platform,
                            stopDTO.Delay);
        }
    }
}
