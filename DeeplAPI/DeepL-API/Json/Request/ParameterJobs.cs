// ReSharper disable InconsistentNaming
namespace DeeplApi.Json.Request
{
    public class ParameterJobs
    {
        public string kind;
        public string raw_en_sentence;
        public string quality;

        //TODO Usage of multiple requests for longer texts
        //Sentences must first be split via text instead of job
        //then add every job as array
        public ParameterJobs(string kind, string raw_en_sentence, string quality)
        {
            this.kind = kind;
            this.raw_en_sentence = raw_en_sentence;
            this.quality = quality;
        }
    }
}