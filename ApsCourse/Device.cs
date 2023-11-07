using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsCourse
{
    internal class Device
    {
        public int Id { get; init; }
        public int Priority { get; init; }

        public Device(int id, int priority)
        {
            Id = id;
            Priority = priority;
        }

        public async Task Start(TimeSpan interval)
        {
            await Task.Delay(interval);
        }
    }
}
