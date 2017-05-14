using System;
using UIKit;

namespace SwissTransportBoard.Sources.View.Header
{
    class StationboardHeaderView: UIView
    {        
        internal UILabel StationNameLabel;

        UILabel ClockLabel;
        UILabel DestinationLabel;
        UILabel PlatformLabel;
        UILabel InformationLabel;
        UIView SeparatorView;

        internal StationboardHeaderView() {
            SetUpStationNameLabel();
            SetUpClockLabel();
            SetUpHeaderLabels();
            SetUpSeparatorView();

            SetUpConstraints();
        }

        #region Private

        private void SetUpStationNameLabel() 
        {
            StationNameLabel = HeaderLabelWithText("");
            AddSubview(StationNameLabel);
        }

        private void SetUpClockLabel()
        {
            ClockLabel = HeaderLabelWithText(DateTime.Now.ToString("HH:mm"));
            AddSubview(ClockLabel);
        }

        private void SetUpHeaderLabels()
        {
            DestinationLabel = ColumnLabelWithText("Nach");   
            PlatformLabel = ColumnLabelWithText("Gleis");  
            InformationLabel = ColumnLabelWithText("Hinweis");
      
     
            AddSubview(DestinationLabel);
            AddSubview(PlatformLabel);
            AddSubview(InformationLabel);
        }

        private void SetUpSeparatorView()
        {
            SeparatorView = new UIView();
            SeparatorView.BackgroundColor = UIColor.White;

            AddSubview(SeparatorView);
        }

        private UILabel HeaderLabelWithText(String text)
        {
            var HeaderLabel = new UILabel();
            HeaderLabel.Font = UIFont.BoldSystemFontOfSize(80);
            HeaderLabel.TextColor = UIColor.White;
            HeaderLabel.Text = text;

            return HeaderLabel;
        }

        private UILabel ColumnLabelWithText(String text)
        {
            var ColumnLabel = new UILabel();
            ColumnLabel.Font = UIFont.BoldSystemFontOfSize(38);
            ColumnLabel.TextColor = UIColor.White;
            ColumnLabel.Text = text;

            return ColumnLabel;
        }

        private void SetUpConstraints()
        {
            StationNameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            StationNameLabel.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 120).Active = true;
            StationNameLabel.TopAnchor.ConstraintEqualTo(TopAnchor, 50).Active = true;

            ClockLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            ClockLabel.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, -72).Active = true;
            ClockLabel.BottomAnchor.ConstraintEqualTo(StationNameLabel.BottomAnchor).Active = true;

            DestinationLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            DestinationLabel.TopAnchor.ConstraintEqualTo(TopAnchor, 200).Active = true;
            DestinationLabel.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 470).Active = true;

            PlatformLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            PlatformLabel.TopAnchor.ConstraintEqualTo(DestinationLabel.TopAnchor).Active = true;
            PlatformLabel.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 1450).Active = true;

            InformationLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            InformationLabel.TopAnchor.ConstraintEqualTo(DestinationLabel.TopAnchor).Active = true;
            InformationLabel.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 1600).Active = true;

            SeparatorView.TranslatesAutoresizingMaskIntoConstraints = false;
            SeparatorView.TopAnchor.ConstraintEqualTo(TopAnchor, 250).Active = true;
            SeparatorView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).Active = true;
            SeparatorView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).Active = true;
            SeparatorView.HeightAnchor.ConstraintEqualTo(1).Active = true;
        }

        #endregion
    }
}
