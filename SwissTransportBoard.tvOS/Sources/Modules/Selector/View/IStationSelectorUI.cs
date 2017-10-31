using System;
using System.Collections.Generic;
using SwissTransportBoard.Modules.Selector.View;
using SwissTransportBoard.Modules.Selector.View.Model;
using UIKit;

namespace SwissTransportBoard.Modules.Selector.View
{
    interface IStationSelectorUI
    {
        UIViewController ViewController();
        void Configure(List<StationViewModel> stations);
    }
}
