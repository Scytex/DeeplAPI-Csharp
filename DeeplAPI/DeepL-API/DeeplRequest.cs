using System;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using DeeplApi.Json.Answer;
using DeeplApi.Json.Request;
using Newtonsoft.Json;
using RestSharp;

namespace DeeplApi
{
    public class DeeplRequest
    {
        private static readonly RestClient Client = new RestClient("https://www2.deepl.com/jsonrpc");
        private static readonly RestRequest Request = new RestRequest(Method.POST);

        /// <summary>
        /// Example testing method
        /// </summary>
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("0 = Auto, 1 = Deutsch, " +
                                  "2 = Englisch, " +
                                  "3 = French, " +
                                  "4 = Spanisch, " +
                                  "5 = Italienisch, " +
                                  "6 = Niederländisch, " +
                                  "7 = Polnisch");
                Console.WriteLine("Eingabesprache: ");
                var sourceLanguage = Console.ReadLine();
                Console.WriteLine("Ausgabesprache: ");
                var targetLanguage = Console.ReadLine();
                Console.WriteLine("Zu übersetzender Text: ");
                var text = Console.ReadLine();

                var result = CreateRequestSimple(text, Language.Select(sourceLanguage), Language.Select(targetLanguage));
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// Create a new DeepL Request with a DeeplAnswer return.
        /// For a string return see CreateRequestSimple()
        /// </summary>
        /// <param name="text">Text to translate</param>
        /// <param name="sourceLanguage">Language of the text</param>
        /// <param name="targetLanguage">Target Language</param>
        /// <returns>DeeplAnswer, which can be accessed like a JSON object</returns>
        public static DeeplAnswer CreateRequest(string text, string sourceLanguage, string targetLanguage)
        {
            var jsonRequest = JsonConvert.SerializeObject(new DeeplBody(text, sourceLanguage, targetLanguage));

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;

            Request.Parameters.Clear();
            Request.AddParameter("application/json; charset=utf-8", jsonRequest, ParameterType.RequestBody);
            Request.RequestFormat = DataFormat.Json;
            var result = Client.Execute(Request);
            var rawResult = result.Content;

            var answer = JsonConvert.DeserializeObject<DeeplAnswer>(rawResult);

            return answer;
        }

        /// <summary>
        /// Create a simple DeepL Request with a string return.
        /// </summary>
        /// <param name="text">Text to translate</param>
        /// <param name="sourceLanguage">Language of the text</param>
        /// <param name="targetLanguage">Target Language</param>
        /// <returns>String, containing the translated text</returns>
        public static string CreateRequestSimple(string text, string sourceLanguage, string targetLanguage)
        {
            var answer = CreateRequest(text, sourceLanguage, targetLanguage);

            return answer.result.translations.Aggregate(string.Empty, (current, translation) => current + translation.beams[0].postprocessed_sentence);
        }

        private static bool MyRemoteCertificateValidationCallback(object sender,
            X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            var isOk = true;
            // If there are errors in the certificate chain,
            // look at each error to determine the cause.
            if (sslPolicyErrors == SslPolicyErrors.None) return true;
            foreach (var t in chain.ChainStatus)
            {
                if (t.Status == X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    continue;
                }
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                var chainIsValid = chain.Build((X509Certificate2)certificate);
                if (chainIsValid) continue;
                isOk = false;
                break;
            }
            return isOk;
        }

    }
}
