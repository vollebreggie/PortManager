using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Models
{

    public class ResponseElement : BasicModel
    {
        string name;
        int lenght;


        [ForeignKey(typeof(Component))]
        public int ComponentId { get; set; }

        [PrimaryKey]
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public int Lenght
        {
            get { return lenght; }
            set
            {
                if (lenght != value)
                {
                    lenght = value;
                    RaisePropertyChanged("Lenght");
                }
            }
        }
    }
}
