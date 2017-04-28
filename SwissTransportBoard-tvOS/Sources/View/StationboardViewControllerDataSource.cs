using System;
using UIKit;

namespace SwissTransportBoard.View
{
	public class StationboardViewControllerDataSource : UITableViewDataSource
	{
		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return 10;
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			StationboardCell cell = (StationboardCell)tableView.DequeueReusableCell(StationboardCell.ReusableIdentifier, indexPath);
			return cell;
		}
	}
}
