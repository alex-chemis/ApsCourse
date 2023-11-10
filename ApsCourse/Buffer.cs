using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ApsCourse
{
    internal class Buffer
    {
        private class StackItem
        {
            public Request Request { get; set; }
            public Boolean IsRemoved { get; private set; }
            public void Remove() => IsRemoved = true;

            public StackItem(Request request)
            {
                Request = request;
                IsRemoved = false;
            }
        }

        private ConcurrentStack<StackItem> Requests { get; init; } = new ConcurrentStack<StackItem>();

        public int MaxSize { get; init; }
        public int NumberFailure { get; private set; }
        public int Count { get { return Requests.Count - NumberFailure; } }
        public bool IsEmpty { get { return Count == 0; } }
        public bool IsFull { get { return Requests.Count - NumberFailure > MaxSize; } }

        public Buffer(int maxSize)
        {
            MaxSize = maxSize;
            NumberFailure = 0;
        }

        public async Task Add(Request request)
        {
            TaskCompletionSource tcs = new TaskCompletionSource();
            
            _ = Task.Factory.StartNew(() =>
            {
                Requests.Push(new StackItem(request));
                if (IsFull)
                {
                    var r = Requests.ElementAt(Requests.Count - NumberFailure - 1);
                    r.Remove();
                    Console.WriteLine($"Request ID:{r.Request.Id} of SourceID:{r.Request.SourceId} was removed!");
                    NumberFailure++;
                }
                tcs.SetResult();
            });

            await tcs.Task;
        }

        public async Task<Request> Get()
        {
            var tcs = new TaskCompletionSource<Request>();

            _ = Task.Factory.StartNew(() =>
            {
                StackItem r;
                bool isPoped = false;
                do
                {
                    isPoped = Requests.TryPop(out r);
                    if (isPoped && r.IsRemoved)
                    {
                        isPoped = false;
                        NumberFailure--;
                    }    
                } while (!isPoped);
                tcs.SetResult(r.Request);
            });

            return await tcs.Task;
        }
    }
}
