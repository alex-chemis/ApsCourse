using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsCourse
{
    internal class RequestHandler
    {

        private SortedSet<Device> _readyDevices = new SortedSet<Device>();
        private List<Device> _notReadyDevices = new List<Device>();

        public List<Device> Devices { get; set; }
        public InputBufferDispatcher InputBufferDispatcher { get; init; }
        public OutputBufferDispatcher OutputBufferDispatcher { get; init; }

        public RequestHandler(List<Device> devices, InputBufferDispatcher inputBufferDispatcher, OutputBufferDispatcher outputBufferDispatcher)
        {
            Devices = devices;
            InputBufferDispatcher = inputBufferDispatcher;
            OutputBufferDispatcher = outputBufferDispatcher;
        }

        private void AddToReady()
        {
            foreach (var item in Devices)
            {
                _readyDevices.Add(item);
            }
        }

        public async Task Handle()
        {
            AddToReady();
            while (true)
            {
                var request = await OutputBufferDispatcher.Get();
                if (_readyDevices.Count == 0)
                {
                    await InputBufferDispatcher.Add(request);
                }
                else
                {
                    var device = _readyDevices.First();
                    _readyDevices.Remove(device);
                    _notReadyDevices.Add(device);
                    device.HandleRequest(request).ContinueWith(x => 
                    { 
                        _notReadyDevices.Remove(device);
                        _readyDevices.Add(device);
                    }).Start();
                }
            }
        }
    }
}
