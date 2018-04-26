using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PortManager.AdvancedControls.ControlModels
{
    public class TextBoxModel : BasicControlModel
    {
        string labelText;
        string text;
        Brush labelColor;

        public Brush LabelColor
        {
            get { return labelColor; }
            set
            {
                if (labelColor != value)
                {
                    labelColor = value;
                    RaisePropertyChanged("LabelColor");
                }
            }
        }

        public string LabelText
        {
            get { return labelText; }
            set
            {
                if (labelText != value)
                {
                    labelText = value;
                    RaisePropertyChanged("LabelText");
                }
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    RaisePropertyChanged("Text");
                }
            }
        }
    }
}
