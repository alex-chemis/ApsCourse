using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsCourse
{
    internal class Device: IComparable<Device>
    {
        static private int ID = 0;
        public int Id { get; init; }
        public int Priority { get; init; }
        public double Alpha { get; init; }
        public double Beta { get; init; }

        private Random Random { get; init; } = new Random();

        public Device(int priority, double alpha, double beta)
        {
            Id = ID++;
            Priority = priority;
            Alpha = alpha;
            Beta = beta;
        }

        private double GetInterval()
        {
            return Random.NextDouble() * (Beta - Alpha) + Alpha;
        }

        public async Task HandleRequest(Request request)
        {
            await Task.Delay((int)GetInterval());
            Console.WriteLine($"Device ID:{this.Id} handle Request ID:{request.Id}");
        }

        public int CompareTo(Device? other)
        { 
            if (other == null) throw new NullReferenceException();
            return other.Priority - Priority;
        }
    }
}
