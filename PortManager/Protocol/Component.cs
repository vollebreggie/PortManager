using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Protocols
{
    public class Component
    {
        public string Name { get; set; }
        public List<Element> Request { get; set; }
        public List<Element> Response { get; set; }
    }
}
