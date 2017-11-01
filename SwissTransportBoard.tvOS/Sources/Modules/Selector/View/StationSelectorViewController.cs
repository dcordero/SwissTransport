using System;
using SwissTransportBoard.Modules.Selector.Presenter;
using SwissTransportBoard.Modules.Selector.View;
using SwissTransportBoard.Modules.Selector.View.Model;
using System.Collections.Generic;
using UIKit;

namespace SwissTransportBoard.Modules.Selector.View
{

    class StationSelectorViewController : UIViewController, IStationSelectorUI, IUISearchResultsUpdating
    {
        internal IStationSelectorPresenter Presenter { get; set; }
        internal StationSelectorViewControllerDataSource DataSource { get; set; }
        internal StationSelectorViewControllerDelegate Delegate { get; set; }

        UITableView TableView;

        #region UIViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetUpView();
            Presenter.ViewDidLoad();
        }

        #endregion

        #region IStationSelectorUI

        public UIViewController ViewController() {
            return this;
        }

        public void Configure(List<StationViewModel> stations)
        { 
            DataSource.Items = stations;
            TableView.ReloadData();
        }

        #endregion

        #region IUISearchResultUpdating

        public void UpdateSearchResultsForSearchController(UISearchController searchController) 
        {
            Presenter.SearchDidEndEditing(searchController.SearchBar.Text);
        }

        #endregion

        #region Private

        private void SetUpView()
        {
            SetUpBackground();
            SetUpTableView();

            SetUpConstraints();
        }

        private void SetUpBackground()
        {
            View.BackgroundColor = UIColor.Clear.FromHex(0x0D2B88);
        }

        private void SetUpTableView() 
        {
            TableView = new UITableView();
            TableView.DataSource = DataSource;
            TableView.Delegate = Delegate;
            TableView.SeparatorInset = UIEdgeInsets.Zero;
            TableView.RowHeight = StationSelectorCell.RowHeight;
            StationSelectorCell.RegisterCellForReuse(TableView);

            View.AddSubview(TableView);
        }

        private void SetUpConstraints()
        {
            TableView.TranslatesAutoresizingMaskIntoConstraints = false;
            TableView.LeadingAnchor.ConstraintEqualTo(this.View.LeadingAnchor).Active = true;
            TableView.TrailingAnchor.ConstraintEqualTo(this.View.TrailingAnchor).Active = true;
            TableView.TopAnchor.ConstraintEqualTo(this.View.TopAnchor, 30).Active = true;
            TableView.BottomAnchor.ConstraintEqualTo(this.View.BottomAnchor).Active = true;
        }

        #endregion
    }
}
