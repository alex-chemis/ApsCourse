using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsCourse
{
    internal class Request
    {
        static private int ID = 0;
        public int Id { get; init; }
        public int SourceId { get; init; }

        public Request(int sourceId)
        {
            Id = ID;
            Interlocked.Increment(ref ID);
            SourceId = sourceId;
        }


    }
}
