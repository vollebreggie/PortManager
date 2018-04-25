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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PortManager.Managers;
using FirstFloor.ModernUI.Presentation;
using System.Reflection;

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
            
            foreach(string item in portService.GetSerialPorts())
            dataGrid.Items.Add(item);
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
