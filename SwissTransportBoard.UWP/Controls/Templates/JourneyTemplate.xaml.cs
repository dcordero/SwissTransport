using SwissTransportPortableLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SwissTransportBoard.UWP.Controls.Templates
{
    public sealed partial class JourneyTemplate : UserControl
    {
        public JourneyTemplate()
        {
            this.InitializeComponent();
            this.DataContextChanged += JourneyTemplate_DataContextChanged;
        }

        private void JourneyTemplate_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            if (this.DataContext != null && this.DataContext is Journey)
            {
                var journey = this.DataContext as Journey;
                txtDeparture.Text = journey.Stop.Departure?.ToString("hh:mm");
                txtName.Text = journey.Name.ToUpper().StartsWith("IR") ? "IR" : journey.Name.Replace(" ", "");

                if (journey.PassList != null & journey.PassList.Count > 1)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var item in journey.PassList.Skip(1).Take(3))
                    {
                        sb.Append(item.Station.Name);
                        sb.Append("   ");
                    }
                    //sb.Append(journey.To);

                    txtTo.Text = sb.ToString();
                }
                else
                {
                    txtTo.Text = journey.To;
                }

                var x = journey.PassList;
            }
        }
    }
}
