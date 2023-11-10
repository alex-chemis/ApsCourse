
using ApsCourse;
using System.Collections.Concurrent;

var stack = new ConcurrentStack<int>();

var buffer = new ApsCourse.Buffer(10);
var input = new InputBufferDispatcher(buffer);
var output = new OutputBufferDispatcher(buffer);

var rg = new RequestGenerator(20, new List<Source> { new Source(0.01), new Source(0.01) }, input);
var rh = new RequestHandler(new List<Device> { new Device(1, 1000, 500), new Device(2, 1000, 500) }, input, output);

var g = rg.Generate();
var h = rh.Handle();

await Task.WhenAll(g, h);

Console.ReadLine();