using System;
using SwissTransportPortableLibrary.Models;
using SwissTransportPortableLibrary.NetworkDTOs;

namespace SwissTransportPortableLibrary.Transformers
{
    public class StationboardDTOToModel
    {
        public static Stationboard Transform(StationboardDTO stationboardDTO)
        {
            return new Stationboard(LocationsDTOToLocation.Transform(stationboardDTO.Station));
        }
    }
}
