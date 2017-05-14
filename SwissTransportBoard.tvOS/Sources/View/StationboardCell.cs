﻿using System;
using UIKit;

namespace SwissTransportBoard
{

    class StationboardCell : UITableViewCell
    {
        private UIFont cellFont = UIFont.BoldSystemFontOfSize(48);

        internal UILabel NameLabel;
        internal UILabel DepartureTimeLabel;
        internal UILabel PassListLabel;
        internal UILabel PlatformLabel;
        internal UIView SeparatorView;

        internal static nfloat RowHeight = 100;
        internal static string ReusableIdentifier = nameof(StationboardCell);

        internal StationboardCell(IntPtr p) : base(p)
        {
            SetUpView();
        }

        internal static void RegisterCellForReuse(UITableView tableView)
        {
            tableView.RegisterClassForCellReuse(typeof(StationboardCell), ReusableIdentifier);
        }

        public override void PrepareForReuse()
        {
            base.PrepareForReuse();
            NameLabel.Text = "";
            DepartureTimeLabel.Text = "";
            PassListLabel.Text = "";
            PlatformLabel.Text = "";
        }

        #region Private

        private void SetUpView()
        {
            SetUpBackground();
            SetUpNameLabel();
            SetUpDepartureTimeLabel();
            SetUpPassListLabel();
            SetUpPlatformLabel();
            SetUpSeparatorView();

            SetUpConstraints();
        }

        private void SetUpBackground()
        {
            BackgroundColor = UIColor.Clear;
        }

        private void SetUpNameLabel()
        {
            NameLabel = new UILabel();
            NameLabel.Font = cellFont;
            NameLabel.TextColor = UIColor.Black;
            NameLabel.TextAlignment = UITextAlignment.Center;
            NameLabel.BackgroundColor = UIColor.White;

            AddSubview(NameLabel);
        }

        private void SetUpDepartureTimeLabel()
        {
            DepartureTimeLabel = StationboardCellLabel();
            AddSubview(DepartureTimeLabel);
        }

        private void SetUpPassListLabel()
		{
            PassListLabel = StationboardCellLabel();
            PassListLabel.TextAlignment = UITextAlignment.Left;
            AddSubview(PassListLabel);
        }

        private void SetUpPlatformLabel()
        {
            PlatformLabel = StationboardCellLabel();
            AddSubview(PlatformLabel);
        }

        private void SetUpSeparatorView()
        {
            SeparatorView = new UIView();
            SeparatorView.BackgroundColor = UIColor.White;

            AddSubview(SeparatorView);
        }

        private UILabel StationboardCellLabel()
        {
            var Label = new UILabel();
            Label.Font = cellFont;
            Label.TextAlignment = UITextAlignment.Center;
            Label.TextColor = UIColor.White;

            return Label;
        }

        private void SetUpConstraints()
        {
            NameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NameLabel.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 70).Active = true;
            NameLabel.CenterYAnchor.ConstraintEqualTo(CenterYAnchor).Active = true;
            NameLabel.HeightAnchor.ConstraintEqualTo(80).Active = true;
            NameLabel.WidthAnchor.ConstraintEqualTo(200).Active = true;

            DepartureTimeLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            DepartureTimeLabel.LeadingAnchor.ConstraintEqualTo(NameLabel.TrailingAnchor).Active = true;
            DepartureTimeLabel.CenterYAnchor.ConstraintEqualTo(CenterYAnchor).Active = true;
            DepartureTimeLabel.WidthAnchor.ConstraintEqualTo(200).Active = true;

            PassListLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            PassListLabel.LeadingAnchor.ConstraintEqualTo(DepartureTimeLabel.TrailingAnchor).Active = true;
            PassListLabel.CenterYAnchor.ConstraintEqualTo(CenterYAnchor).Active = true;
            PassListLabel.WidthAnchor.ConstraintEqualTo(900).Active = true;

            PlatformLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            PlatformLabel.LeadingAnchor.ConstraintEqualTo(PassListLabel.TrailingAnchor).Active = true;
            PlatformLabel.CenterYAnchor.ConstraintEqualTo(CenterYAnchor).Active = true;
            PlatformLabel.WidthAnchor.ConstraintEqualTo(200).Active = true;

            SeparatorView.TranslatesAutoresizingMaskIntoConstraints = false;
            SeparatorView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;
            SeparatorView.WidthAnchor.ConstraintEqualTo(WidthAnchor).Active = true;
            SeparatorView.HeightAnchor.ConstraintEqualTo(1).Active = true;
        }

        #endregion
    }
}
