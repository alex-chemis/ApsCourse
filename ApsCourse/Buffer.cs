using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ApsCourse
{
    internal class Buffer
    {
        private BufferBlock<Request> Requests { get; init; }
        private int MaxSize { get; init; }

        public Buffer(BufferBlock<Request> requests, int maxSize)
        {
            Requests = requests;
            MaxSize = maxSize;
        }

        public async Task Add(Request request)
        {
            await Requests.SendAsync(request);
        }

        public async Task<Request> Get()
        {
            return await Requests.ReceiveAsync();
        }

        public bool IsEmpty()
        {
            return Requests.Count == 0;
        }

        public bool IsFull()
        {
            return Requests.Count == MaxSize;
        }

    }
}
