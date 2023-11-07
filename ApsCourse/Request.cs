using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsCourse
{
    internal class Request
    {
        public int Id { get; init; }
        public int SourceId { get; init; }
        public TimeSpan ProcessingTime { get; init; }

        public Request(int id, int sourceId, TimeSpan processingTime)
        {
            Id = id;
            SourceId = sourceId;
            ProcessingTime = processingTime;
        }


    }
}
