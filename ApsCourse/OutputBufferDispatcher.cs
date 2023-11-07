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
            return await Buffer.Get();
        }
    }
}
