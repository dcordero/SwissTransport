using System;
using System.Collections.Generic;
using SwissTransportBoard.Modules.Selector.View;
using SwissTransportBoard.Modules.Selector.View.Model;

namespace SwissTransportBoard.Modules.Selector.View
{
    interface IStationSelectorUI
    {
        void Configure(List<StationViewModel> stations);
    }
}
