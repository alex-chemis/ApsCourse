using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsCourse
{
    internal class RequestHandler
    {
        public SortedSet<Device> Devices { get; init; } = new SortedSet<Device>();
        public InputBufferDispatcher InputBufferDispatcher { get; init; }
        public OutputBufferDispatcher OutputBufferDispatcher { get; init; }
        private List<int> l = new List<int>();

        public RequestHandler(List<Device> devices, InputBufferDispatcher inputBufferDispatcher, OutputBufferDispatcher outputBufferDispatcher)
        {
            foreach (var device in devices)
            {
                Devices.Add(device);
            }
            InputBufferDispatcher = inputBufferDispatcher;
            OutputBufferDispatcher = outputBufferDispatcher;
        }

        public async Task Handle(Task generator)
        {
            while (!generator.IsCompleted || !OutputBufferDispatcher.Buffer.IsEmpty)
            {
                foreach (var device in Devices)
                {
                    if (device.IsReady)
                    {
                        var request = await OutputBufferDispatcher.Get();
                        var _ = device.HandleRequest(request);
                        break;
                    }
                }
            }
            await Task.Delay(1000);
        }
    }
}
