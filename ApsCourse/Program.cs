
using ApsCourse;
using System.Collections.Concurrent;

var stack = new ConcurrentStack<int>();

var buffer = new ApsCourse.Buffer(10000);
var input = new InputBufferDispatcher(buffer);
var output = new OutputBufferDispatcher(buffer);

var rg = new RequestGenerator(10, new List<Source> { new Source(0.01), new Source(0.01) }, input);
var rh = new RequestHandler(new List<Device> { new Device(1, 0.01, 0.02) }, input, output);

await rg.Generate();
await rh.Handle();
