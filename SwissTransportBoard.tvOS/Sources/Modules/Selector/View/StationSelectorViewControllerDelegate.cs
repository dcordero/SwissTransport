using Foundation;
using UIKit;
using SwissTransportBoard.Modules.Selector.Presenter;

namespace SwissTransportBoard.Modules.Selector.View
{
    class StationSelectorViewControllerDelegate : UITableViewDelegate
    {
        private IStationSelectorPresenter Presenter { get; set; }

        internal StationSelectorViewControllerDelegate(IStationSelectorPresenter presenter)
        {
            this.Presenter = presenter;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Presenter.StationSelectedAt(indexPath);
        }
    }
}