// ReSharper disable InconsistentNaming

namespace DeeplApi.Json.Answer
{
    public class DeeplTranslation
    {
        public DeeplBeams[] beams;
        public long timeAfterPreprocessing;
        public long timeReceivedFromEndpoint;
        public long timeSentToEndpoint;
        public long total_time_endpoint;
    }
}