using System;
using NUnit.Framework;
using GoogleTranslateUIAutomationTesting;
using GoogleTranslateUIAutomationTesting.Pages;
using static GoogleTranslateUIAutomationTesting.Data.Language;
using GoogleTranslateUIAutomationTesting.Helpers;

namespace GoogleTranslateTests
{
    // TODO: move constants to TranslateTextData.xml file
    static class TestConstants
    {
        public const string SundayInEnglish = "sunday";
        public const string SundayInUkrainien = "неділя";
        public const string FriendInEnglish = "friend";
        public const string FriendInUkrainien = "друг";
        public const string TestingInEnglish = "testing";
        public const string TestingInUkrainien = "тестування";        
    }

    [TestFixture]
    public class RegressionTests : BaseTest
    {
        [Test]
        public void VerifySelectionOfSourceEnLanguageAndTargetUkLanguage()
        {
            // select source and target languages
            var languageBar = HomePage.TranslationBlock.LanguageBar;
            languageBar.OpenSourceLanguageList().SelectSourceLanguage(English)
                .OpenTargetLanguageList().SelectTargetLanguage(Ukrainien);
            // verify that languages are selected correctly
            Assert.IsTrue(languageBar.GetSelectedSourceLanguage().ToLower().
                Equals(English.GetString()));
            Assert.IsTrue(languageBar.GetSelectedTargetLanguage().ToLower().
                Equals(Ukrainien.GetString()));            
        }

        [Test]
        public void VerifySearchSourceEnLanguageAndSearchTargetUkLanguage()
        {
            // search and select source and target languages
            var languageBar = HomePage.TranslationBlock.LanguageBar;     
            languageBar.SearchAndSelectSourceLanguage(English)
                .SearchAndSelectTargetLanguage(Ukrainien);
            // verify that languages are selected correctly
            Assert.IsTrue(languageBar.GetSelectedSourceLanguage().ToLower().
                Equals(English.GetString()));
            Assert.IsTrue(languageBar.GetSelectedTargetLanguage().ToLower().
                Equals(Ukrainien.GetString()));
        }

        [Test]
        public void VerifyAutoDeterminationOfSourseUkLanguage()
        {
            // enter source text
            var sourceContainer = HomePage.TranslationBlock.SourceContainer;
            sourceContainer.SetSourceText(TestConstants.TestingInUkrainien);
            // determinate language automatically
            var languageBar = HomePage.TranslationBlock.LanguageBar;
            languageBar.AutoDetermineLanguage();
            // verify that language is determinated correctly
            Assert.IsTrue(languageBar.GetAutomaticallyDeterminedLanguage().ToLower().
                Equals(Ukrainien.GetString()));
        }

        [Test]
        public void VerifyTranslationFromEnLanguageToUkLanguage()
        {
            // select source and target languages
            var languageBar = HomePage.TranslationBlock.LanguageBar;
            languageBar.OpenSourceLanguageList().SelectSourceLanguage(English)
                .OpenTargetLanguageList().SelectTargetLanguage(Ukrainien);
            // enter source text
            var sourceContainer = HomePage.TranslationBlock.SourceContainer;
            sourceContainer.SetSourceText(TestConstants.SundayInEnglish);
            // verify translation
            var targetContainer = HomePage.TranslationBlock.ResultContainer;
            Assert.AreEqual(TestConstants.SundayInUkrainien, targetContainer.GetResultText());
        }

        [Test]
        public void VerifyTranslationFromUkLanguageToEnLanguage()
        {
            // select source and target languages
            var languageBar = HomePage.TranslationBlock.LanguageBar;
            languageBar.OpenSourceLanguageList().SelectSourceLanguage(Ukrainien)
                .OpenTargetLanguageList().SelectTargetLanguage(English);
            // enter source text
            var sourceContainer = HomePage.TranslationBlock.SourceContainer;
            sourceContainer.SetSourceText(TestConstants.FriendInUkrainien);
            // verify translation
            var targetContainer = HomePage.TranslationBlock.ResultContainer;
            Assert.AreEqual(TestConstants.FriendInEnglish, targetContainer.GetResultText());
        }

        [Test]
        public void VerifySwapSourceEnLanguageAndTargetUkLanguage()
        {
            // select source and target languages
            var languageBar = HomePage.TranslationBlock.LanguageBar;
            languageBar.OpenSourceLanguageList().SelectSourceLanguage(English)
                .OpenTargetLanguageList().SelectTargetLanguage(Ukrainien);
            // verify that languages are selected correctly
            Assert.IsTrue(languageBar.GetSelectedSourceLanguage().ToLower().
                Equals(English.GetString()));
            Assert.IsTrue(languageBar.GetSelectedTargetLanguage().ToLower().
                Equals(Ukrainien.GetString()));
            // enter source text
            var sourceContainer = HomePage.TranslationBlock.SourceContainer;
            sourceContainer.SetSourceText(TestConstants.SundayInEnglish);
            // verify translation
            var targetContainer = HomePage.TranslationBlock.ResultContainer;
            Assert.AreEqual(TestConstants.SundayInUkrainien, targetContainer.GetResultText());
            // swap languages
            languageBar.SwapLanguages();
            // verify languages are swapped in language bar
            Assert.IsTrue(languageBar.GetSelectedSourceLanguage().ToLower().
                Equals(Ukrainien.GetString()));
            Assert.IsTrue(languageBar.GetSelectedTargetLanguage().ToLower().
                Equals(English.GetString()));
            // verify text is swapped
            Assert.AreEqual(TestConstants.SundayInUkrainien, sourceContainer.GetSourceText());
            Assert.AreEqual(TestConstants.SundayInEnglish, targetContainer.GetResultText());
        }

        [Test]
        public void VerifyCharactersCountOfSourceEnLanguage()
        {
            // select source and target languages
            var languageBar = HomePage.TranslationBlock.LanguageBar;
            languageBar.OpenSourceLanguageList().SelectSourceLanguage(English);
            // enter source text
            var sourceContainer = HomePage.TranslationBlock.SourceContainer;
            sourceContainer.SetSourceText(TestConstants.TestingInEnglish);
            // verify character's count
            Assert.AreEqual(TestConstants.TestingInEnglish.Length, sourceContainer.GetCharacterCount());
        }

    }
}
