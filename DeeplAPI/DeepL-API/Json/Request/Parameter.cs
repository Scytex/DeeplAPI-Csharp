// ReSharper disable InconsistentNaming

namespace DeeplApi.Json.Request
{
    public class Parameter
    {
        public ParameterJobs[] jobs;
        public ParameterLanguage lang;
        public int priority;
        public long timestamp;

        public Parameter(ParameterJobs[] jobs, ParameterLanguage lang, int priority, long timestamp)
        {
            this.jobs = jobs;
            this.lang = lang;
            this.priority = priority;
            this.timestamp = timestamp;
        }


    }
}