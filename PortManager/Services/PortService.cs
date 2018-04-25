using PortManager.Models;
using PortManager.Services;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Managers
{
    public class PortService
    {
        private SerialPort _ComPort;
        private Protocol _SelectedProtocol;
        private Component _SelectedComponent;
        private ProtocolService _ReaderService;

        public PortService()
        {
            _ComPort = new SerialPort();
            _ReaderService = new ProtocolService();
            _ComPort.DataReceived +=
              new SerialDataReceivedEventHandler(port_DataReceived);
        }


        public List<string> GetSerialPorts()
        {
            List<string> list = SerialPort.GetPortNames().ToList();
            return list;
        }

        

        public void SendData(string text)
        {
            _ComPort.Write(_SelectedProtocol.Serialize(_SelectedComponent.Name, text));
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine(_SelectedProtocol.Serialize(_SelectedComponent.Name, _ComPort.ReadLine()));
        }

    }
}
