using Foundation;
namespace SwissTransportBoard.Modules.Selector.Presenter
{
    internal interface IStationSelectorPresenter
    {
        void ViewDidLoad();
        void StationSelectedAt(NSIndexPath indexPath);
    }
}
