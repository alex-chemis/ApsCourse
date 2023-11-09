using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsCourse
{
    internal class RequestGenerator
    {
        public int NumberOfRequests { get; set; }
        public List<Source> Sources { get; set; }
        public InputBufferDispatcher InputBufferDispatcher { get; init; }
        
        public RequestGenerator(int numberOfRequests, List<Source> sources, InputBufferDispatcher inputBufferDispatcher)
        {
            NumberOfRequests = numberOfRequests;
            Sources = sources;
            InputBufferDispatcher = inputBufferDispatcher;
        }

        private async Task StartSource(Source source)
        {
            for (int i = 0; i < NumberOfRequests; i++)
            {
                var request = await source.GenerateRequest();
                await InputBufferDispatcher.Add(request);
            }
        }

        public async Task Generate()
        {
            var tasks = new List<Task>();
            foreach (var source in Sources) 
            {
                tasks.Add(StartSource(source));
            }
            await Task.WhenAll(tasks);
        }

    }
}
