using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PortManager.AdvancedControls
{
    public class AdvancedButton : Button
    {
        public AdvancedButton()
        {
            Background = new SolidColorBrush(Color.FromRgb(57, 85, 135));
            Opacity = 0.8;
            Foreground = Brushes.White;
         
        }
    }
}
