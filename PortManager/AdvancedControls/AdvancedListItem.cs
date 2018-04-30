using PortManager.AdvancedControls.ControlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PortManager.AdvancedControls
{
    public class AdvancedListItem : Grid
    {
        ItemModel itemModel;
        public AdvancedListItem(ItemModel itemModel)
        {
            this.itemModel = itemModel;
            Width = 160;
            Height = 40;

            Image icon = new Image();
            Label text = new Label();

            text.VerticalAlignment = VerticalAlignment.Center;
            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.SetBinding(Label.ContentProperty, "Name");
            text.DataContext = itemModel;
            text.Foreground = Brushes.White;
            text.FontFamily = new FontFamily("Aleo");
            text.FontSize = 15;
            text.FontStretch = FontStretches.Normal;
            text.FontWeight = FontWeights.Bold;
            text.MouseDown += MouseDown_Button;
            MouseDown += MouseDown_Button;
            // += MouseOver;
            BitmapImage blob = new BitmapImage();
            blob.BeginInit();
            blob.UriSource = new Uri("C:\\Users\\mike\\Desktop\\PortManager\\deleteIcon.PNG", UriKind.Absolute);
            blob.EndInit();

             icon.Source = blob;
            //icon.SetBinding(Image.SourceProperty, "Image");
            icon.HorizontalAlignment = HorizontalAlignment.Center;
            icon.VerticalAlignment = VerticalAlignment.Center;
            icon.Width = 30;
            icon.Height = 30;
            //icon.DataContext = itemModel;
            icon.MouseDown += MouseDown_Image;
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
            border.CornerRadius = new CornerRadius(0, 0, 0, 0);
            border.SetBinding(Border.BorderBrushProperty, "Color");
            border.DataContext = itemModel;

            Grid grid = new Grid();
            grid.SetBinding(Grid.BackgroundProperty, "Color");
            grid.DataContext = itemModel;

            Grid.SetColumn(text, 0);
            Grid.SetRow(text, 0);
            Grid.SetColumn(icon, 1);
            Grid.SetRow(icon, 0);

            ColumnDefinition col = new ColumnDefinition();
            col.Width = new GridLength(1, GridUnitType.Star);

            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(50);

            grid.ColumnDefinitions.Add(col);
            grid.ColumnDefinitions.Add(col2);
            grid.RowDefinitions.Add(new RowDefinition());
            grid.Children.Add(icon);
            grid.Children.Add(text);

            border.Child = grid;
            Children.Add(border);


        }

        private void MouseDown_Image(object sender, MouseEventArgs e)
        {
            int i = 0;

        }

        private void MouseDown_Button(object sender, MouseEventArgs e)
        {
            int i = 0;

        }

        private void MouseOver(object sender, MouseEventArgs e)
        {
            int i = 0;

        }
    }
}
