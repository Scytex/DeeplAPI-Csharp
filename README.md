# DeepL-API-Csharp
C# Library to translate small texts via DeepL using RestSharp

## Usage
```csharp
string translatedText = DeeplRequest.CreateRequestSimple("Hallo", Language.German, Language.Italian);
//Result "ciao"
```

```csharp
DeeplAnswer deeplAnswer = DeeplRequest.CreateRequest("Hallo", Language.German, Language.Italian);
string secondVariantOfTranslation = deeplAnswer.result.translations[0].beams[1].postprocessed_sentence;
//Result "saluto"
```

## Methods
```csharp
CreateRequest(string text, string sourceLanguage, string targetLanguage)
```
Returns a DeeplAnswer which can be used like an JSON object

```csharp

CreateRequestSimple(string text, string sourceLanguage, string targetLanguage)

```
Returns the result as simple string

```csharp

Main()

```
Debugging method, which starts an example in the console


