using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsCourse
{
    internal class InputBufferDispatcher
    {
        private Random Random { get; init; } = new Random();
        public Buffer Buffer { get; init; }

        public InputBufferDispatcher(Buffer buffer)
        {
            Buffer = buffer;
        }   

        public async Task Add(Request request)
        {
            await Buffer.Add(request);
            Console.WriteLine($"Request ID:{request.Id} of SourceID:{request.SourceId} has been sent to buffer");
        }
    }
}
