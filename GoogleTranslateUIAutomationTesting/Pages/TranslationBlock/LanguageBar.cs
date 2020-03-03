using System;
using GoogleTranslateTAFramework;
using GoogleTranslateUIAutomationTesting.Data;
using GoogleTranslateUIAutomationTesting.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GoogleTranslateUIAutomationTesting.Pages.TranslationBlock
{
    public class LanguageBar
    {
        [FindsBy(How = How.ClassName, Using = "tlid-open-source-language-list")]
        private IWebElement openSourceLanguageList;

        [FindsBy(How = How.ClassName, Using = "tlid-open-target-language-list")]
        private IWebElement openTargetLanguageList;

        // source English language
        [FindsBy(How = How.XPath, Using = "//div[@class = 'language-list-unfiltered-langs-sl_list']//div[@class = 'language_list_item_wrapper language_list_item_wrapper-en']")]
        private IWebElement sourceEnLanguage;
                
        // source Ukrainien language
        [FindsBy(How = How.XPath, Using = "//div[@class = 'language-list-unfiltered-langs-sl_list']//div[@class = 'language_list_item_wrapper language_list_item_wrapper-uk']")]
        private IWebElement sourceUkLanguage;

        // target English language
        [FindsBy(How = How.XPath, Using = "//div[@class = 'language-list-unfiltered-langs-tl_list']//div[@class = 'language_list_item_wrapper language_list_item_wrapper-en']")]
        private IWebElement targetEnLanguage;

        // target Ukrainien language
        [FindsBy(How = How.XPath, Using = "//div[@class = 'language-list-unfiltered-langs-tl_list']//div[@class = 'language_list_item_wrapper language_list_item_wrapper-uk']")]
        private IWebElement targetUkLanguage;
                
        [FindsBy(How = How.XPath, Using = "//*[@class='sl-sugg']//*[@aria-pressed='true']")]
        private IWebElement selectedSourceLanguage;

        [FindsBy(How = How.XPath, Using = "//*[@class='tl-sugg']//*[@aria-pressed='true']")]
        private IWebElement selectedTargetLanguage;

        [FindsBy(How = How.ClassName, Using = "jfk-button-narrow")]
        private IWebElement swapLanguages;

        [FindsBy(How = How.XPath, Using = "//*[@value='auto']")]
        private IWebElement autoDetermineLanguage;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'sl-sugg']//div[@class = 'goog-inline-block jfk-button jfk-button-standard jfk-button-collapse-right jfk-button-checked']")]
        private IWebElement autoDeterminedLanguage;//goog-inline-block jfk-button jfk-button-standard jfk-button-collapse-right jfk-button-checked

        [FindsBy(How = How.XPath, Using = "//input[@id = 'sl_list-search-box']")]
        private IWebElement searchSourceLanguage;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'tl_list-search-box']")]
        private IWebElement searchTargetLanguage;


        public LanguageBar OpenSourceLanguageList()
        {
            try
            {
                openSourceLanguageList.Click();
                return this;
            }
            catch (Exception ex)
            {
                // Report "Can not open language list"
                throw ex;
            }
        }

        public LanguageBar OpenTargetLanguageList()
        {
            try
            {
                openTargetLanguageList.Click();
                return this;
            }
            catch (Exception ex)
            {
                // Report "Can not open target language list"
                throw ex;
            }
        }

        public LanguageBar SelectSourceLanguage(Language value)
        {
            try
            {
                switch (value)
                {
                    case Language.Ukrainien:                        
                        ScrollToElement(sourceUkLanguage);
                        sourceUkLanguage.Click();
                        break;
                    case Language.English:
                        ScrollToElement(sourceEnLanguage);
                        sourceEnLanguage.Click();
                        break;
                    default:
                        break;
                }
                return this;
            }
            catch(Exception ex)
            {
                // Report "Can not select source language"
                throw ex;
            }            
        }

        public LanguageBar SelectTargetLanguage(Language value)
        {
            try
            {
                switch (value)
                {
                    case Language.Ukrainien:
                        ScrollToElement(targetUkLanguage);
                        targetUkLanguage.Click();
                        break;
                    case Language.English:
                        ScrollToElement(targetEnLanguage);
                        targetEnLanguage.Click();
                        break;
                    default:
                        break;
                }
                return this;
            }
            catch (Exception ex)
            {
                // Report "Can not select target language"
                throw ex;
            }
        }

        public string GetSelectedSourceLanguage()
        {
            try
            {
                return selectedSourceLanguage.Text;
            }
            catch (Exception ex)
            {
                // Report "Can not get selected source language"
                throw ex;
            }
        }

        public string GetSelectedTargetLanguage()
        {
            try
            {
                return selectedTargetLanguage.Text;
            }
            catch (Exception ex)
            {
                // Report "Can not get selected target language"
                throw ex;
            }
        }

        public LanguageBar SwapLanguages()
        {
            try
            {
                swapLanguages.Click();
                return this;
            }
            catch (Exception ex)
            {
                // Report "Can not swap languages"
                throw ex;
            }
        }

        public LanguageBar SearchAndSelectSourceLanguage(Language value)
        {
            try
            {
                OpenSourceLanguageList();
                searchSourceLanguage.SendKeys(value.GetString());
                searchSourceLanguage.SendKeys(Keys.Enter);
                return this;
            }
            catch (Exception ex)
            {
                // Report "Can not search and select source language"
                throw ex;
            }
        }

        public LanguageBar SearchAndSelectTargetLanguage(Language value)
        {
            try
            {
                OpenTargetLanguageList();
                searchTargetLanguage.SendKeys(value.GetString());
                searchTargetLanguage.SendKeys(Keys.Enter);
                return this;
            }
            catch (Exception ex)
            {
                // Report "Can not search and select target language"
                throw ex;
            }
        }

        public LanguageBar AutoDetermineLanguage()
        {
            try
            {
                autoDetermineLanguage.Click();
                return this;
            }
            catch (Exception ex)
            {
                // Report "Can not automatically determine language"
                throw ex;
            }
        }

        public string GetAutomaticallyDeterminedLanguage()
        {
            try
            {
                var index = autoDeterminedLanguage.Text.LastIndexOf("(");
                var language = autoDeterminedLanguage.Text
                    .Substring(0, index).Trim(); 
                return language;
            }
            catch (Exception ex)
            {
                // Report "Can not get automatically determined language"
                throw ex;
            }
        }

        private LanguageBar ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)Browser.Driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return this;
        }
    }
}
