
using ApsCourse;

var buffer = new ApsCourse.Buffer(1000000);
var input = new InputBufferDispatcher(buffer);

var rg = new RequestGenerator(20, new List<Source> { new Source(0.01), new Source(0.01) }, input);

await rg.Generate();