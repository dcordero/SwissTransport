using System;
using UIKit;
using SwissTransportBoard.Presenter;
using SwissTransportBoard.View;
using System.Collections.Generic;
using SwissTransportBoard.Sources.View.Model;

namespace SwissTransportBoard
{
    public class StationboardViewController : UIViewController, IStationboardUI
    {
        public IStationboardPresenter Presenter { get; set; }
        public StationboardViewControllerDataSource DataSource { get; set; }

        private UITableView TableView;

        #region UIViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetUpView();
            Presenter.ViewDidLoad();
        }

		#endregion

		#region IStationboardUI

		public void Configure(List<JourneyViewModel> journeys)
        {
            DataSource.Items = journeys;
            TableView.ReloadData();
        }

        #endregion

        #region Private

        private void SetUpView()
        {
            View.BackgroundColor = UIColor.Blue;

            TableView = new UITableView();
            TableView.UserInteractionEnabled = false;
            TableView.DataSource = DataSource;
            StationboardCell.RegisterCellForReuse(TableView);
            View.AddSubview(TableView);

            TableView.TranslatesAutoresizingMaskIntoConstraints = false;
            TableView.LeadingAnchor.ConstraintEqualTo(this.View.LeadingAnchor).Active = true;
            TableView.TrailingAnchor.ConstraintEqualTo(this.View.TrailingAnchor).Active = true;
            TableView.TopAnchor.ConstraintEqualTo(this.View.TopAnchor).Active = true;
            TableView.BottomAnchor.ConstraintEqualTo(this.View.BottomAnchor).Active = true;
        }

        #endregion
    }
}
