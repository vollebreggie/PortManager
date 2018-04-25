
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Models
{
    public class Protocol
    {
        
        [PrimaryKey]
        public string Name { get; set; }

        public List<Component> Protocols { get; set; }

        public string Serialize(string protocol, string sequence)
        {
            Component format = Protocols.Find(x => x.Name == protocol);
            List<RequestElement> requestParts = format.Request;
            return "";
        }

        public string DeSerialize(string protocol, string sequence)
        {
            Component format = Protocols.Find(x => x.Name == protocol);
            List<ResponseElement> responseParts = format.Response;
            return "";
        }

     
    }
}
