using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslateUIAutomationTesting.Model
{
    [Serializable]
    class TranslateText
    {
        public string SourceLanguage { get; set; }
        public string TargetLanguage { get; set; }
        public string SourceText { get; set; }
        public int CharactersCount { get; set; }
        public string TargetText { get; set; }

        public TranslateText(string sourceLanguage, string targetLanguage, 
            string sourceText, int charactersCount, string targetText)
        {
            SourceLanguage = sourceLanguage;
            TargetLanguage = targetLanguage;
            SourceText = sourceText;
            CharactersCount = charactersCount;
            TargetText = targetText;
        }
    }
}
