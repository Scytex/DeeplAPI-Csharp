// ReSharper disable InconsistentNaming

namespace DeeplApi.Json.Answer
{
    public class DeeplResult
    {
        public string source_lang;
        public long source_lang_is_confident;
        public string target_lang;
        public DeeplTranslation[] translations;
    }
}