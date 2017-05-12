using System;
using System.Collections.Generic;
using SwissTransportBoard.Sources.View.Model;
using UIKit;

namespace SwissTransportBoard.View
{
    public class StationboardViewControllerDataSource : UITableViewDataSource
    {
        public List<JourneyViewModel> Items { get; set; }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return Items?.Count ?? 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            StationboardCell cell = (StationboardCell)tableView.DequeueReusableCell(StationboardCell.ReusableIdentifier, indexPath);
            cell.TitleLabel.Text = Items[indexPath.Row].Name;
            return cell;
        }
    }
}
