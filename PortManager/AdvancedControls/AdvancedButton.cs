using PortManager.AdvancedControls.ControlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PortManager.AdvancedControls
{
    public class AdvancedButton : Grid
    {
        ButtonModel buttonModel;
        public AdvancedButton(ButtonModel buttonModel)
        {
            this.buttonModel = buttonModel;
            Width = 160;
            Height = 40;

            Image icon = new Image();
            Label text = new Label();

            text.VerticalAlignment = VerticalAlignment.Center;
            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.SetBinding(Label.ContentProperty, "Name");
            text.DataContext = buttonModel;
            text.Foreground = Brushes.White;
            text.FontFamily = new FontFamily("Falling sky");
            text.FontSize = 15;
            text.FontStretch = FontStretches.Normal;
            text.FontWeight = FontWeights.Bold;

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("C:\\Users\\m.vollebregt\\Desktop\\Gui\\test.PNG", UriKind.Absolute);
            bi3.EndInit();

            icon.Source = bi3;
            //icon.SetBinding(Image.SourceProperty, "Image");
            icon.HorizontalAlignment = HorizontalAlignment.Center;
            icon.VerticalAlignment = VerticalAlignment.Center;
            icon.Width = 30;
            icon.Height = 30;
            icon.DataContext = buttonModel;

            Border border = new Border()
            {
                BorderThickness = new Thickness()
                {
                    Bottom = 5,
                    Left = 5,
                    Right = 5,
                    Top = 5

                },
            };
            border.CornerRadius = new CornerRadius(8, 8, 8, 8);
            border.SetBinding(Border.BorderBrushProperty, "Color");
            border.DataContext = buttonModel;

            Grid grid = new Grid();
            grid.SetBinding(Grid.BackgroundProperty, "Color");
            grid.DataContext = buttonModel;

            Grid.SetColumn(icon, 0);
            Grid.SetRow(icon, 0);
            Grid.SetColumn(text, 1);
            Grid.SetRow(text, 0);

            ColumnDefinition col = new ColumnDefinition();
            col.Width = new GridLength(75);

            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(1, GridUnitType.Star);

            grid.ColumnDefinitions.Add(col);
            grid.ColumnDefinitions.Add(col2);
            grid.RowDefinitions.Add(new RowDefinition());
            grid.Children.Add(icon);
            grid.Children.Add(text);

            border.Child = grid;
            Children.Add(border);

            
        }
    }
}
