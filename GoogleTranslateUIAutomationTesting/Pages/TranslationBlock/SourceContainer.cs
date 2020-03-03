using GoogleTranslateTAFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslateUIAutomationTesting.Pages.TranslationBlock
{
    public class SourceContainer
    {
        [FindsBy(How = How.XPath, Using = "//textarea[@id='source']")]
        private IWebElement sourceTextInput;

        [FindsBy(How = How.ClassName, Using = "tlid-input-area input-area less-padding")]
        private IWebElement sourceText;

        [FindsBy(How = How.ClassName, Using = "src-tts left-positioned ttsbutton jfk-button-flat source-or-target-footer-button jfk-button")]
        private IWebElement speechSourceText;

        [FindsBy(How = How.ClassName, Using = "cc-ctr normal")]
        private IWebElement characterCount;

        [FindsBy(How = How.ClassName, Using = "speech-button goog-toolbar-button")]
        private IWebElement voiceInput;

        public void SetSourceText(string value)
        {
            try
            {
                sourceTextInput.Click();
                sourceTextInput.SendKeys(value);
            }
            catch (Exception ex)
            {
                // Report "Can not set source text"
                throw ex;
            }
        }

        public string GetSourceText()
        {
            try
            {
                return sourceText.Text;
            }
            catch (Exception ex)
            {
                // Report "Can not get source text"
                throw ex;
            }
        }

        public bool SpeechSourceTextIsEnabled(string value)
        {
            try
            {
                return speechSourceText.Displayed;
            }
            catch (Exception ex)
            {
                // Report "Speech source text is not displayed"
                throw ex;
            }
        }

        public int GetCharacterCount()
        {
            try
            {
                var text = characterCount.Text;
                return Int32.Parse(text.Trim().Remove(text.Length - 5, text.Length));
            }
            catch (Exception ex)
            {
                // Report "Can not count source text characters"
                throw ex;
            }
        }
    }
}
