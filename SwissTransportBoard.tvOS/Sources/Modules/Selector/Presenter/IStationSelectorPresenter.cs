using Foundation;
using System;

namespace SwissTransportBoard.Modules.Selector.Presenter
{
    internal interface IStationSelectorPresenter
    {
        void ViewDidLoad();
        void SearchDidEndEditing(String query);
        void StationSelectedAt(NSIndexPath indexPath);
    }
}
