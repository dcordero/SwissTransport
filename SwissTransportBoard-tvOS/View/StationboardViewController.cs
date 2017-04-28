using System;
using UIKit;

namespace SwissTransportBoard
{
	public class StationboardViewController : UIViewController
	{

		private UITableView tableView;
		private UITableViewDataSource dataSource = new StationboardViewControllerDataSource();

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			SetUpView();


            View.BackgroundColor = UIColor.Red;
		}

		private void SetUpView()
		{
			tableView = new UITableView();
			tableView.DataSource = dataSource;
			StationboardCell.RegisterCellForReuse(tableView);
			View.AddSubview(tableView);

			tableView.TranslatesAutoresizingMaskIntoConstraints = false;
			tableView.LeadingAnchor.ConstraintEqualTo(this.View.LeadingAnchor).Active = true;
			tableView.TrailingAnchor.ConstraintEqualTo(this.View.TrailingAnchor).Active = true;
			tableView.TopAnchor.ConstraintEqualTo(this.View.TopAnchor).Active = true;
			tableView.BottomAnchor.ConstraintEqualTo(this.View.BottomAnchor).Active = true;
		}
	}

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
