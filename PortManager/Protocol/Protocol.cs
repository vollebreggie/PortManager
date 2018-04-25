using PortManager.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Reader
{
    public class Protocol
    {
        public List<Component> Protocols { get; set; }
        public string Name { get; set; }

        public string Serialize(string protocol, string sequence)
        {
            Component format = Protocols.Find(x => x.Name == protocol);
            List<Element> requestParts = format.Request;
            return "";
        }

        public string DeSerialize(string protocol, string sequence)
        {
            Component format = Protocols.Find(x => x.Name == protocol);
            List<Element> responseParts = format.Response;
            return "";
        }

     
    }
}
