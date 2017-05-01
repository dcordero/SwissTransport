using System;
using SwissTransportPortableLibrary.Models;
using SwissTransportPortableLibrary.NetworkDTOs;

namespace SwissTransportPortableLibrary.Transformers
{
    class StationboardDTOToModel
    {
        internal static Stationboard Transform(StationboardDTO stationboardDTO)
        {
            return new Stationboard(LocationsDTOToLocation.Transform(stationboardDTO.Station), 
                                    JourneyDTOToModel.Transform(stationboardDTO.Journeys));
        }
    }
}
