using PortManager.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PortManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static DataService dataService;
        public static DataService DataService
        {
            get
            {
                if (dataService == null)
                {
                    dataService = new DataService(new Database.Core.Database());
                }
                return dataService;
            }
        }
    }
}
