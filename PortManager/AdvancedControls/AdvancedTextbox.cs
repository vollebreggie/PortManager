using PortManager.AdvancedControls.ControlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PortManager.AdvancedControls
{
    public class AdvancedTextbox : Grid
    {
        public AdvancedTextbox(TextBoxModel textBoxModel)
        {
            Label label = new Label();
            label.SetBinding(Label.BackgroundProperty, "LabelColor");
            label.SetBinding(Label.ContentProperty, "LabelText");
            label.DataContext = textBoxModel;
            TextBox textBox = new TextBox();
            textBox.SetBinding(TextBox.TextProperty, "Text");
            textBox.DataContext = textBoxModel;

            Children.Add(label);
            Children.Add(textBox);


        }

       
    }
}
