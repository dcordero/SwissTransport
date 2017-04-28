using System;
using UIKit;
using SwissTransportBoard.Presenter;
using SwissTransportBoard.View;

namespace SwissTransportBoard
{
    public class StationboardViewController : UIViewController, IStationboardUI
    {
        public IStationboardPresenter Presenter { get; set; }
		public UITableViewDataSource DataSource { get; set; }

		private UITableView tableView;

        #region UIViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetUpView();
            Presenter.ViewDidLoad();
        }

        #endregion

        #region IStationboardUI

        public void Configure()
        {
            View.BackgroundColor = UIColor.Purple;
        }

        #endregion

        #region Private

        private void SetUpView()
        {
            tableView = new UITableView();
            tableView.DataSource = DataSource;
            StationboardCell.RegisterCellForReuse(tableView);
            View.AddSubview(tableView);

            tableView.TranslatesAutoresizingMaskIntoConstraints = false;
            tableView.LeadingAnchor.ConstraintEqualTo(this.View.LeadingAnchor).Active = true;
            tableView.TrailingAnchor.ConstraintEqualTo(this.View.TrailingAnchor).Active = true;
            tableView.TopAnchor.ConstraintEqualTo(this.View.TopAnchor).Active = true;
            tableView.BottomAnchor.ConstraintEqualTo(this.View.BottomAnchor).Active = true;
        }

        #endregion
    }
}
