using System;
using UIKit;

namespace SwissTransportBoard
{
    public class StationboardCell : UITableViewCell
    {
        public UILabel TitleLabel;
        public static string ReusableIdentifier = nameof(StationboardCell);

        public StationboardCell(IntPtr p) : base(p)
        {
            TitleLabel = new UILabel();
            TitleLabel.Frame = this.Bounds;
            BackgroundColor = UIColor.Blue;
        }

        public static void RegisterCellForReuse(UITableView tableView)
        {
            tableView.RegisterClassForCellReuse(typeof(StationboardCell), ReusableIdentifier);
        }
    }
}
