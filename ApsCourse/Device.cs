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
        public bool IsReady { get; private set; }

        private Random Random { get; init; } = new Random();

        public Device(int priority, double alpha, double beta)
        {
            Id = ID++;
            Priority = priority;
            Alpha = alpha;
            Beta = beta;
            IsReady = true;
        }

        private double GetInterval()
        {
            return Random.NextDouble() * (Beta - Alpha) + Alpha;
        }

        public async Task HandleRequest(Request request)
        {
            IsReady = false;
            Console.WriteLine($"Device ID:{this.Id} start handle Request ID:{request.Id}");
            await Task.Delay((int)GetInterval());
            Console.WriteLine($"Device ID:{this.Id} finish handle Request ID:{request.Id}");
            IsReady = true;
        }

        public int CompareTo(Device? other)
        { 
            if (other == null) throw new NullReferenceException();
            int byPriority = other.Priority - Priority;
            return byPriority == 0 ? Id - other.Id : byPriority;
        }
    }
}
