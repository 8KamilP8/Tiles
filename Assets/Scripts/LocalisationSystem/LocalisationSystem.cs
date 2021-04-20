using System.Collections.Generic;
using System.Xml;
using UnityEngine;
public static class LocalisationSystem
{
    private static bool initialised = false;
    private static Language _currentLanguage;

    private static Dictionary<Language, Dictionary<string, string>> _dictionary;

    public static Language GetCurrentLanguage() {
        return _currentLanguage;
    }

    public static void SetCurrentLanguage(Language language) {
        _currentLanguage = language;
    }

    public static string GetValue(string stringId) {
        if (!initialised) Init();
        return _dictionary[_currentLanguage][stringId];
    }

    public static void Init() {
        _dictionary = new Dictionary<Language, Dictionary<string, string>>();
        XmlTextReader xtr = new XmlTextReader(Application.dataPath + "localisation.xml");
        foreach (var val in System.Enum.GetValues(typeof(Language))) {
            var dictionary = new Dictionary<string, string>();
            while (xtr.Read()) {
                if(xtr.NodeType == XmlNodeType.Element && xtr.Name == ((Language)val).ToString()) {

                }
            }
            _dictionary.Add((Language)val, dictionary);
        }
    }
}

public enum Language {
    english,polish,french, chinese
}