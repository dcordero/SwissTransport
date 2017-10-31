using System;
using System.Collections.Generic;
using SwissTransportBoard.Modules.Board.View.Model;

namespace SwissTransportBoard.Modules.Board.View
{
    interface IStationboardUI
    {
        void Configure(String stationName, List<JourneyViewModel> journeys);
    }
}
