using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsCourse
{
    internal class RequestGenerator
    {
        private List<Source> Sources { get; init; }
        private InputBufferDispatcher InputBufferDispatcher { get; init; }
        
        public RequestGenerator(List<Source> sources, InputBufferDispatcher inputBufferDispatcher)
        {
            Sources = sources;
            InputBufferDispatcher = inputBufferDispatcher;
        }

        public async Task Generate()
        {
            foreach (var source in Sources) 
            {
                await InputBufferDispatcher.Add(new Request(1, source.Id, new TimeSpan(1)));
            }
        }

    }
}
