using System;
using System.Collections.Generic;
using SwissTransportBoard.Modules.Board.View.Model;
using UIKit;

namespace SwissTransportBoard.Modules.Board.View
{
    class StationboardViewControllerDataSource : UITableViewDataSource
    {
        internal List<JourneyViewModel> Items { get; set; }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return Items?.Count ?? 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            StationboardCell cell = (StationboardCell)tableView.DequeueReusableCell(StationboardCell.ReusableIdentifier, indexPath);

            if (indexPath.Row < Items.Count)
            {
                var item = Items[indexPath.Row];
                cell.NameLabel.Text = item.Name;
                cell.DepartureTimeLabel.Text = item.DepartureTime;
                cell.PassListLabel.Text = item.PassList;
                cell.PlatformLabel.Text = item.Platform;
            }

            return cell;
        }
    }
}
