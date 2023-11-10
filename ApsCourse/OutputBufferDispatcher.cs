using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsCourse
{
    internal class OutputBufferDispatcher
    {
        public Buffer Buffer { get; init; }

        public OutputBufferDispatcher(Buffer buffer)
        {
            Buffer = buffer;
        }

        public async Task<Request> Get()
        {
            var request = await Buffer.Get();
            Console.WriteLine($"Request ID:{request.Id} of SourceID:{request.SourceId} has been sent to dispatcher");
            return request;
        }
    }
}
