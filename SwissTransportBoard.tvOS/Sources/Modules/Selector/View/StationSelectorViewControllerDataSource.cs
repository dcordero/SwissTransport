using System;
using System.Collections.Generic;
using SwissTransportBoard.Modules.Selector.View.Model;
using UIKit;

namespace SwissTransportBoard.Modules.Selector.View
{
    class StationSelectorViewControllerDataSource : UITableViewDataSource
    {
        internal List<StationViewModel> Items { get; set; }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return Items?.Count ?? 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            StationSelectorCell cell = (StationSelectorCell)tableView.DequeueReusableCell(StationSelectorCell.ReusableIdentifier, indexPath);

            if (indexPath.Row < Items.Count)
            {
                var item = Items[indexPath.Row];
                cell.NameLabel.Text = item.Name;
            }

            return cell;
        }
    }
}
