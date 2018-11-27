// ReSharper disable InconsistentNaming

using System;

namespace DeeplApi.Json.Request
{
    internal class DeeplBody
    {
        public string jsonrpc;
        public string method;
        public Parameter @params;
        public int? id;

        public DeeplBody(string text, string sourceLanguage, string targetLanguage) : this(null, null, CreateParam(text, sourceLanguage, targetLanguage), null)
        {

        }

        public DeeplBody(string jsonrpc, string method, Parameter @params, int? id)
        {
            this.jsonrpc = jsonrpc ?? "2.0";
            this.method = method ?? "LMT_handle_jobs";
            this.@params = @params ?? CreateParam("empty Parameter", Language.English, Language.German);
            this.id = id ?? 1;
        }

        private static Parameter CreateParam(string text, string sourceLanguage, string targetLanguage, long timestamp)
        {
            var pLanguage = CreateParameterLanguage(sourceLanguage, targetLanguage);
            var pJobs = CreateParameterJobs(text);
            const int priority = -1;

            return new Parameter(pJobs, pLanguage, priority, timestamp);
        }


        private static Parameter CreateParam(string text, string sourceLanguage, string targetLanguage)
        {
            return CreateParam(text, sourceLanguage, targetLanguage, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() * 1000);
        }

        private static ParameterLanguage CreateParameterLanguage(string sourceLanguage, string targetLanguage)
        {
            var prefLanguages = new[]{"NL","ES","PL","DE","EN"};
            return new ParameterLanguage(prefLanguages,sourceLanguage, targetLanguage);
        }

        private static ParameterJobs[] CreateParameterJobs(string text)
        {
            //TODO splitting strings by sentence into multiple
            const string kind = "default";
            const string quality = "fast";
            var pJobs = new []
            {
                new ParameterJobs(kind, text, quality)
            };
            return pJobs;
        }
    }
}
