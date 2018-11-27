using System;

namespace DeeplApi.Json.Request
{
    public abstract class Language
    {
        public const string Auto = "auto";
        public const string German = "DE";
        public const string English = "EN";
        public const string French = "FR";
        public const string Spanish = "ES";
        public const string Italian = "IT";
        public const string Dutch = "NL";
        public const string Polish = "PL";

        public static string Select(int langId)
        {
            switch (langId)
            {
                case 0:
                    return Auto;
                case 1:
                    return German;
                case 2:
                    return English;
                case 3:
                    return French;
                case 4:
                    return Spanish;
                case 5:
                    return Italian;
                case 6:
                    return Dutch;
                case 7:
                    return Polish;
            }
            return string.Empty;
        }

        public static string Select(string langId)
        {
            return Select(Convert.ToInt32(langId));
        }
    }
}