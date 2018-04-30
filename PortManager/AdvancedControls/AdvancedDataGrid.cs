using PortManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace PortManager.AdvancedControls
{
    public class AdvancedDataGrid<T> : DataGrid where T : class, new()
    {
        public delegate Point GetPosition(IInputElement element);
        int rowIndex = -1;
        ObservableCollection<T> collection;
        public AdvancedDataGrid(ObservableCollection<T> collection)
        {
            this.collection = collection;
            PreviewMouseLeftButtonDown += new MouseButtonEventHandler(DataGrid_PreviewMouseLeftButtonDown);
            Drop += new DragEventHandler(productsDataGrid_Drop);
            CellEditEnding += DataGridCellEditEnding;
            var style = new Style(typeof(DataGridColumnHeader));
            IsReadOnly = true;
            style.Setters.Add(new Setter { Property = BackgroundProperty, Value = new SolidColorBrush(Color.FromRgb(43, 86, 128) )});
            style.Setters.Add(new Setter { Property = ForegroundProperty, Value = Brushes.White });
            style.Setters.Add(new Setter { Property = FontFamilyProperty, Value = new FontFamily("Aleo") });
            //style.Setters.Add(new Setter { Property = FontSizeProperty, Value = 15 });
            style.Setters.Add(new Setter { Property = FontWeightProperty, Value = FontWeights.Bold });
            //new Setter { Property = WidthProperty, Value =  });
            style.Setters.Add(new Setter { Property = VerticalContentAlignmentProperty, Value = VerticalAlignment.Center });
            style.Setters.Add(new Setter { Property = HorizontalContentAlignmentProperty, Value = HorizontalAlignment.Center });
            DataGridTextColumn nameColumn = new DataGridTextColumn();
            nameColumn.Header = "Name";
            nameColumn.Binding = new Binding("Name");
            Columns.Add(nameColumn);
            nameColumn.CanUserSort = false;
            nameColumn.HeaderStyle = style;
            nameColumn.Foreground = Brushes.Black;
            nameColumn.FontFamily = new FontFamily("Aleo");
            nameColumn.FontSize = 15;
            nameColumn.FontWeight = FontWeights.Bold;

            Style columnstyle = new Style();
            columnstyle.Setters.Add(new Setter(DataGridCell.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
            columnstyle.Setters.Add(new Setter(DataGridCell.VerticalContentAlignmentProperty, VerticalAlignment.Center));
            CellStyle = columnstyle;
            //columnstyle.Setters.Add(new Setter { Property = HorizontalContentAlignmentProperty, Value = HorizontalAlignment.Center });
            nameColumn.CellStyle = columnstyle;
            nameColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            
            
            DataGridTextColumn lenghtColumn = new DataGridTextColumn();
            lenghtColumn.Header = "Lenght";
            lenghtColumn.Binding = new Binding("Lenght");
            lenghtColumn.CellStyle = columnstyle;
            Columns.Add(lenghtColumn);
            lenghtColumn.CanUserSort = false;
            AllowDrop = true;
            lenghtColumn.HeaderStyle = style;
            lenghtColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            //lenghtColumn.Foreground = Brushes.White;
            //lenghtColumn.FontFamily = new FontFamily("Aleo");
            //lenghtColumn.FontSize = 15;
            //lenghtColumn.FontWeight = FontWeights.Bold;

            foreach (T item in collection)
            {
                Items.Add(item);
            }
        }

        private void DataGridCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            e.Cancel = true;
        }

        void productsDataGrid_Drop(object sender, DragEventArgs e)
        {
            if (rowIndex < 0)
                return;
            int index = this.GetCurrentRowIndex(e.GetPosition);
            if (index < 0)
                return;
            if (index == rowIndex)
                return;
            if (index == Items.Count - 1)
            {
                MessageBox.Show("This row-index cannot be drop");
                return;
            }

            T changedItem = collection[rowIndex];
            collection.RemoveAt(rowIndex);
            collection.Insert(index, changedItem);
            Items.Clear();
            foreach (T item in collection)
            {
                
                Items.Add(item);
            }
        }

        void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rowIndex = GetCurrentRowIndex(e.GetPosition);
            if (rowIndex < 0)
                return;
            SelectedIndex = rowIndex;
            var selectedEmp = Items[rowIndex];
            if (selectedEmp == null)
                return;
            DragDropEffects dragdropeffects = DragDropEffects.Move;
            if (DragDrop.DoDragDrop(this, selectedEmp, dragdropeffects)
                                != DragDropEffects.None)
            {
                SelectedItem = selectedEmp;
            }
        }

        private bool GetMouseTargetRow(Visual theTarget, GetPosition position)
        {
            Rect rect = VisualTreeHelper.GetDescendantBounds(theTarget);
            Point point = position((IInputElement)theTarget);
            return rect.Contains(point);
        }

        private DataGridRow GetRowItem(int index)
        {
            if (ItemContainerGenerator.Status
                    != GeneratorStatus.ContainersGenerated)
                return null;
            return ItemContainerGenerator.ContainerFromIndex(index)
                                                            as DataGridRow;
        }

        private int GetCurrentRowIndex(GetPosition pos)
        {
            int curIndex = -1;
            for (int i = 0; i < Items.Count; i++)
            {
                DataGridRow itm = GetRowItem(i);
                if (GetMouseTargetRow(itm, pos))
                {
                    curIndex = i;
                    break;
                }
            }
            return curIndex;
        }
    }
}
