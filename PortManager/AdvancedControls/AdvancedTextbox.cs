using PortManager.AdvancedControls.ControlModels;
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
    public class AdvancedTextbox : Grid
    {
        TextBoxModel textBoxModel;

        public AdvancedTextbox(TextBoxModel textBoxModel)
        {
            this.textBoxModel = textBoxModel;
            Width = 250;
            Height = 30;

            Border border = new Border()
            {
                BorderThickness = new Thickness()
                {
                    Bottom = 5,
                    Left = 5,
                    Right = 0,
                    Top = 5

                }, 
            };

            border.CornerRadius = new CornerRadius(8,0,0,8);
            border.SetBinding(Border.BorderBrushProperty, "LabelColor");
            border.DataContext = textBoxModel;

            Label label = new Label();
            label.SetBinding(Label.BackgroundProperty, "LabelColor");
            label.SetBinding(Label.ContentProperty, "LabelText");
            label.DataContext = textBoxModel;
            label.Width = 70;
            label.Height = 20;
            label.MinWidth = 70;
            label.VerticalAlignment = VerticalAlignment.Center; 
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            label.VerticalContentAlignment = VerticalAlignment.Center;
            label.FontFamily = new FontFamily("Falling sky");
            label.FontSize = 15;
            label.FontStretch = FontStretches.Normal;
            //label.FontStyle = FontStyles.Oblique;
            label.FontWeight = FontWeights.Bold;

            TextBox textBox = new TextBox();
            textBox.SetBinding(TextBox.TextProperty, "Text");
            textBox.DataContext = textBoxModel;
            textBox.Width = 175;
            textBox.VerticalContentAlignment = VerticalAlignment.Center;
            textBox.HorizontalAlignment = HorizontalAlignment.Center;
            

            SetColumn(label, 0);
            SetRow(label, 0);
            SetColumn(textBox, 1);
            SetRow(textBox, 0);

         

            ColumnDefinition col = new ColumnDefinition();
            col.Width = new GridLength(75);

            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(1, GridUnitType.Star);

            ColumnDefinitions.Add(col);
            ColumnDefinitions.Add(col2);
            RowDefinitions.Add(new RowDefinition());

            border.Child = label;
            Children.Add(border);
            Children.Add(textBox);


        }

        public TextBoxModel TextBoxModel {
            get
            {
                return textBoxModel;
            }
            set
            {
                textBoxModel = value;
            } }
       
    }
}
