
namespace ApsCourse
{
    internal class Statistics
    {
        public Buffer Buffer { get; set; }
        public RequestGenerator RequestGenerator { get; set; }
        public RequestHandler RequestHandler { get; set; }

        public Statistics(Buffer buffer, RequestGenerator requestGenerator, RequestHandler requestHandler)
        {
            Buffer = buffer;
            RequestGenerator = requestGenerator;
            RequestHandler = requestHandler;
        }

        public async Task StartAutoMode()
        {
            var requestGeneratorTask = RequestGenerator.Generate();
            var requestHandlerTask = RequestHandler.Handle(requestGeneratorTask);

            await Task.WhenAll(requestGeneratorTask, requestHandlerTask);
        }
    }
}
