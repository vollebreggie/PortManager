
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Models
{
    public class Protocol
    {

        public Protocol()
        {

        }

        public Protocol(string name)
        {
            Name = name;
        }
        
        [PrimaryKey]
        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Component> Components { get; set; }

        public string Serialize(string protocol, string sequence)
        {
            Component format = Components.Find(x => x.Name == protocol);
            List<RequestElement> requestParts = format.Request;
            return "";
        }

        public string DeSerialize(string protocol, string sequence)
        {
            Component format = Components.Find(x => x.Name == protocol);
            List<ResponseElement> responseParts = format.Response;
            return "";
        }

     
    }
}
