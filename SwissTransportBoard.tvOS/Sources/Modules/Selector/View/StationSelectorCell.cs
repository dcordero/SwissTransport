using System;
using UIKit;

namespace SwissTransportBoard.Modules.Selector.View
{

    class StationSelectorCell : UITableViewCell
    {
        private UIFont cellFont = UIFont.BoldSystemFontOfSize(48);

        internal UILabel NameLabel;

        internal static nfloat RowHeight = 100;
        internal static string ReusableIdentifier = nameof(StationSelectorCell);
        internal static nfloat CellWidth = 1200;
        internal static nfloat CellHeight = 80;

        internal StationSelectorCell(IntPtr p) : base(p)
        {
            SetUpView();
        }

        internal static void RegisterCellForReuse(UITableView tableView)
        {
            tableView.RegisterClassForCellReuse(typeof(StationSelectorCell), ReusableIdentifier);
        }

        public override void PrepareForReuse()
        {
            base.PrepareForReuse();
            NameLabel.Text = "";
            NameLabel.BackgroundColor = UIColor.White;
        }

        public override void DidUpdateFocus(UIFocusUpdateContext context, UIFocusAnimationCoordinator coordinator)
        {
            coordinator.AddCoordinatedAnimations(() => { 
                if (this.Focused)
                {
                    ApplyFocusedStyle();
                }
                else
                {
                    ApplyUnfocusedStyle();
                }
            }, null);

        }

        #region Private

        private void SetUpView()
        {
            SetUpBackground();
            SetUpNameLabel();

            SetUpConstraints();
        }

        private void SetUpBackground()
        {
            BackgroundView = new UIView();
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

        private void SetUpConstraints()
        {
            NameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NameLabel.CenterXAnchor.ConstraintEqualTo(CenterXAnchor).Active = true;
            NameLabel.CenterYAnchor.ConstraintEqualTo(CenterYAnchor).Active = true;
            NameLabel.HeightAnchor.ConstraintEqualTo(CellHeight).Active = true;
            NameLabel.WidthAnchor.ConstraintEqualTo(CellWidth).Active = true;
        }

        private void ApplyFocusedStyle()
        {
            NameLabel.BackgroundColor = UIColor.Red;

        }

        private void ApplyUnfocusedStyle()
        {
            NameLabel.BackgroundColor = UIColor.White;
        }

        #endregion
    }
}
