using PortManager.Database;
using PortManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Services
{
    public class DataService
    {
        
        IRepository<Component> componentRepository;

        public DataService(Database.Core.Database database)
        {
            ProtocolRepository = new Repository<Protocol>(database);
            componentRepository = new Repository<Component>(database);
        }

        public IRepository<Protocol> ProtocolRepository { get; set; }


    }
}
