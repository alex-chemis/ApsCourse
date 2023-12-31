﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsCourse
{
    internal class Source
    {
        static private int ID = 0;

        public int Id { get; init; }

        public double Lambda { get; init; }

        private Random Random { get; init; } = new Random();

        public Source(double lambda)
        {
            Id = ID++;
            Lambda = lambda;
        }
        private double GetInterval()
        {
            return -1.0 / Lambda * Math.Log(Random.NextDouble());
        }

        public async Task<Request> GenerateRequest()
        {
            await Task.Delay((int)(GetInterval()));
            var ret = new Request(Id);
            Console.WriteLine($"Source ID:{this.Id} generate Request ID:{ret.Id}, SorceID:{ret.SourceId}");
            return ret;
        }
    }
}
