﻿using System;
using UIKit;

namespace SwissTransportBoard
{
    public class StationboardCell : UITableViewCell
    {
        public UILabel TitleLabel;

        public static string ReusableIdentifier = nameof(StationboardCell);

        public StationboardCell(IntPtr p) : base(p)
        {
			BackgroundColor = UIColor.Clear;

			TitleLabel = new UILabel();
            TitleLabel.Frame = this.Bounds;

            AddSubview(TitleLabel);
        }

        public static void RegisterCellForReuse(UITableView tableView)
        {
            tableView.RegisterClassForCellReuse(typeof(StationboardCell), ReusableIdentifier);
        }
    }
}
