using PortManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PortManager.AdvancedControls.ControlModels
{
    public class BasicControlModel : BasicModel
    {
        double up;
        double down;
        ICommand command;


        public ICommand Command
        {
            get { return command; }
            set
            {
                if (command != value)
                {
                    command = value;
                    RaisePropertyChanged("Command");
                }
            }
        }

        public double Up
        {
            get { return up; }
            set
            {
                if (up != value)
                {
                    up = value;
                    RaisePropertyChanged("Up");
                }
            }
        }
        public double Down
        {
            get { return down; }
            set
            {
                if (down != value)
                {
                    down = value;
                    RaisePropertyChanged("Down");
                }
            }
        }
    }
}
