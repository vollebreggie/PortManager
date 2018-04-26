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
            var style = new Style(typeof(DataGridColumnHeader));
            style.Setters.Add(
                new Setter { Property = BackgroundProperty, Value = new SolidColorBrush(Color.FromRgb(43, 86, 128)) });
                //new Setter { Property = WidthProperty, Value =  });
            
            DataGridTextColumn nameColumn = new DataGridTextColumn();
            nameColumn.Header = "Name";
            nameColumn.Binding = new Binding("Name");
            Columns.Add(nameColumn);
            nameColumn.CanUserSort = false;
            nameColumn.HeaderStyle = style;
            nameColumn.Width = new DataGridLength(100, DataGridLengthUnitType.Auto);//TODO:: fix width

            DataGridTextColumn lenghtColumn = new DataGridTextColumn();
            lenghtColumn.Header = "Lenght";
            lenghtColumn.Binding = new Binding("Lenght");
            Columns.Add(lenghtColumn);
            lenghtColumn.CanUserSort = false;
            AllowDrop = true;
            lenghtColumn.HeaderStyle = style;
            lenghtColumn.Width = new DataGridLength(100, DataGridLengthUnitType.Auto);//TODO:: fix width

            foreach (T item in collection)
            {
                Items.Add(item);
            }
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
