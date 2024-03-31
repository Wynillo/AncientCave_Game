using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AncientCave.ModLoader;

public static class TranslationLoader
{
    private static Dictionary<string, Dictionary<string, string>> allTranslations = new Dictionary<string, Dictionary<string, string>>();
    private static Dictionary<string, string> currentTranslations;
    
    public static void LoadTranslation(string directoryPath, string language="en")
    {
        if (!allTranslations.ContainsKey(language))
        {
            allTranslations[language] = new Dictionary<string, string>();

            // Load the single translations file for the given language
            string file = $"{directoryPath}/{language}.translation.json";
            var jsonData = File.ReadAllText(file);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
            ParseNestedJson(dict, string.Empty, allTranslations[language]);
        }

        currentTranslations = allTranslations[language];
    }

    private static void ParseNestedJson(Dictionary<string, object> dict, string path, Dictionary<string, string> translations)
    {
        foreach (var pair in dict)
        {
            if (pair.Value is Dictionary<string, object> nestedDict)
            {
                ParseNestedJson(nestedDict, path + pair.Key + ".", translations);
            }
            else
            {
                translations[path + pair.Key] = pair.Value.ToString();
            }
        }
    }
}