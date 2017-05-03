using SwissTransportPortableLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            }
        }
    }
}
