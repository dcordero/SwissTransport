using System;
using UIKit;
using SwissTransportBoard.Modules.Board.Presenter ;
using SwissTransportBoard.Modules.Board.View;
using SwissTransportBoard.Modules.Board.View.Model;
using System.Collections.Generic;


namespace SwissTransportBoard.Modules.Board.View
{
    class StationboardViewController : UIViewController, IStationboardUI
    {
        internal IStationboardPresenter Presenter { get; set; }
        internal StationboardViewControllerDataSource DataSource { get; set; }

        StationboardHeaderView HeaderView;
        UITableView TableView;

        #region UIViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetUpView();
            Presenter.ViewDidLoad();
        }

		#endregion

		#region IStationboardUI

		public void Configure(String stationName, List<JourneyViewModel> journeys)
        {
            HeaderView.StationNameLabel.Text = stationName;
            DataSource.Items = journeys;
            TableView.ReloadData();
        }

        #endregion

        #region Private

        private void SetUpView()
        {
            SetUpBackground();
            SetUpHeaderView();
            SetUpTableView();

            SetUpConstraints();
        }

        private void SetUpBackground()
        {
            View.BackgroundColor = UIColor.Clear.FromHex(0x0D2B88);
        }

        private void SetUpHeaderView()
        {
            HeaderView = new StationboardHeaderView();

            View.AddSubview(HeaderView);
        }

        private void SetUpTableView() 
        {
            TableView = new UITableView();
            TableView.UserInteractionEnabled = false;
            TableView.DataSource = DataSource;
            TableView.SeparatorInset = UIEdgeInsets.Zero;
            TableView.RowHeight = StationboardCell.RowHeight;
            StationboardCell.RegisterCellForReuse(TableView);

            View.AddSubview(TableView);
        }

        private void SetUpConstraints()
        {
            HeaderView.TranslatesAutoresizingMaskIntoConstraints = false;
            HeaderView.LeadingAnchor.ConstraintEqualTo(this.View.LeadingAnchor).Active = true;
            HeaderView.TrailingAnchor.ConstraintEqualTo(this.View.TrailingAnchor).Active = true;
            HeaderView.TopAnchor.ConstraintEqualTo(this.View.TopAnchor).Active = true;

            TableView.TranslatesAutoresizingMaskIntoConstraints = false;
            TableView.LeadingAnchor.ConstraintEqualTo(this.View.LeadingAnchor).Active = true;
            TableView.TrailingAnchor.ConstraintEqualTo(this.View.TrailingAnchor).Active = true;
            TableView.TopAnchor.ConstraintEqualTo(this.View.TopAnchor, 250).Active = true;
            TableView.BottomAnchor.ConstraintEqualTo(this.View.BottomAnchor).Active = true;
        }

        #endregion
    }
}

static class UIColorExtensions
    {
        internal static UIColor FromHex(this UIColor color,int hexValue)
        {
            return UIColor.FromRGB(
                (((float)((hexValue & 0xFF0000) >> 16))/255.0f),
                (((float)((hexValue & 0xFF00) >> 8))/255.0f),
                (((float)(hexValue & 0xFF))/255.0f)
            );
        }
    }
