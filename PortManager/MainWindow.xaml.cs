using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PortManager.Managers;
using FirstFloor.ModernUI.Presentation;
using System.Reflection;
using PortManager.AdvancedControls;
using PortManager.AdvancedControls.ControlModels;
using System.Windows.Media;
using System.Collections.ObjectModel;
using PortManager.Models;

namespace PortManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            AppearanceManager.Current.ThemeSource = AppearanceManager.DarkThemeSource;
            GUITitle.Title = "Protocol Thingy " + AssemblyVersion;
            PortService portService = new PortService();

            CreateProtocol();

            //BitmapImage bi3 = new BitmapImage();
            //bi3.BeginInit();
            //bi3.UriSource = new Uri("C:\\Users\\mike\\Desktop\\PortManager\\deleteIcon.PNG", UriKind.Absolute);
            //bi3.EndInit();



            ButtonModel buttonmodel = new ButtonModel();
            buttonmodel.Color = new SolidColorBrush(Color.FromRgb(43, 86, 128));
            buttonmodel.Name = "test";
            //buttonmodel.Image = bi3;

            //buttonmodel.Image 
            
           
            ObservableCollection<RequestElement> list = new ObservableCollection<RequestElement>();
            list.Add(new RequestElement() { Name = "test1", Lenght = 4 });
            list.Add(new RequestElement() { Name = "test2", Lenght = 8 });
            list.Add(new RequestElement() { Name = "test3", Lenght = 12 });

            testGrid.Children.Add(new AdvancedDataGrid<RequestElement>(list));
            //replaceGrid.Children.Add(new AdvancedButton(buttonmodel));
        }


        private async void CreateProtocol()
        {


            List<Protocol> list = await App.DataService.ProtocolRepository.Get();

            TextBoxModel testmodel = new TextBoxModel();
            testmodel.LabelColor = new SolidColorBrush(Color.FromRgb(43, 86, 128));
            testmodel.LabelText = "Name";
            testmodel.Text = "";

            ItemModel itemmodel = new ItemModel();
            itemmodel.Color = new SolidColorBrush(Color.FromRgb(43, 86, 128));
            itemmodel.Name = "Protocol";
            //itemmodel.Image = blob;
            protocolList.SetBinding(ListView.NameProperty, "Name");
            protocolList.DataContext = await App.DataService.ProtocolRepository.Get();
            //protocolList.Items.Add(new AdvancedListItem(itemmodel));
            //protocolList.Items.Add(new AdvancedListItem(itemmodel));
            protocolTextBoxGrid.Children.Add(new AdvancedTextbox(testmodel));
        }
        public string AssemblyVersion
        {
            get
            {
                if (Assembly.GetExecutingAssembly().GetName().Version.Revision == 0)
                {
                    return Assembly.GetExecutingAssembly().GetName().Version.Major + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor + "." + Assembly.GetExecutingAssembly().GetName().Version.Build;
                }
                else
                {
                    return Assembly.GetExecutingAssembly().GetName().Version.Major + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor + "." + Assembly.GetExecutingAssembly().GetName().Version.Build + "b" + Assembly.GetExecutingAssembly().GetName().Version.Revision;
                }
            }
        }
    }
}
