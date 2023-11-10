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
        }
    }
}
