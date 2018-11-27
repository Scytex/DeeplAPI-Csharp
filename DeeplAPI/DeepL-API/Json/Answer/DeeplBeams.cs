// ReSharper disable InconsistentNaming
namespace DeeplApi.Json.Answer
{
    public class DeeplBeams
    {
        public long num_symbols;
        public string postprocessed_sentence;
        public double score;
        public double totalLogProb;
    }
}