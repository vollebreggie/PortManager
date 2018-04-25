using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Models
{
    public class Component : BasicModel
    {
        string name;

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
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<RequestElement> Request { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ResponseElement> Response { get; set; }
    }
}
