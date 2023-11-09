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
        private ConcurrentStack<Request> Requests { get; init; } = new ConcurrentStack<Request>();
        private int MaxSize { get; init; }

        public Buffer(int maxSize)
        {
            MaxSize = maxSize;
        }

        public async Task Add(Request request)
        {
            TaskCompletionSource tcs = new TaskCompletionSource();

            _ = Task.Factory.StartNew(() =>
            {
                Requests.Push(request);
                tcs.SetResult();
            });

            await tcs.Task;
        }

        public async Task<Request> Get()
        {
            var tcs = new TaskCompletionSource<Request>();

            _ = Task.Factory.StartNew(() =>
            {
                Request r;
                while (!Requests.TryPop(out r));
                tcs.SetResult(r);
            });

            return await tcs.Task;
        }

        public bool IsEmpty()
        {
            return Requests.Count == 0;
        }

        public bool IsFull()
        {
            return Requests.Count == MaxSize;
        }

    }
}
