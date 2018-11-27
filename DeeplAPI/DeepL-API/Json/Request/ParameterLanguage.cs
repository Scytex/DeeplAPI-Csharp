// ReSharper disable InconsistentNaming
namespace DeeplApi.Json.Request
{
    public class ParameterLanguage
    {
        public string[] user_preferred_langs;
        public string source_lang_user_selected;
        public string target_lang;

        public ParameterLanguage(string[] user_preferred_langs, string source_lang_user_selected, string target_lang)
        {
            this.user_preferred_langs = user_preferred_langs;
            this.source_lang_user_selected = source_lang_user_selected;
            this.target_lang = target_lang;
        }
    }
}