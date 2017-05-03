using System;
using System.Collections.Generic;
using SwissTransportBoard.Sources.View.Model;

namespace SwissTransportBoard.View
{
    public interface IStationboardUI
    {
        void Configure(List<JourneyViewModel> journeys);
    }
}
