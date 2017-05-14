using System;
using System.Collections.Generic;
using SwissTransportBoard.Sources.View.Model;

namespace SwissTransportBoard.View
{
    interface IStationboardUI
    {
        void Configure(String stationName, List<JourneyViewModel> journeys);
    }
}
