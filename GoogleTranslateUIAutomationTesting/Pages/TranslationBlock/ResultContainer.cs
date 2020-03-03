using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslateUIAutomationTesting.Pages.TranslationBlock
{
    public class ResultContainer
    {
        [FindsBy(How = How.XPath, Using = "//span[@class = 'tlid-translation translation']/span")]
        private IWebElement resultText;

        [FindsBy(How = How.ClassName, Using = "tlid-copy-translation-button copybutton jfk-button-flat source-or-target-footer-button right-positioned jfk-button")]
        private IWebElement copyResult;

        [FindsBy(How = How.ClassName, Using = "res-tts ttsbutton-res left-positioned ttsbutton jfk-button-flat source-or-target-footer-button jfk-button")]
        private IWebElement speechTargetText;

        [FindsBy(How = How.ClassName, Using = "starbutton jfk-button-flat jfk-button unstarred")]
        private IWebElement starResult;

        public string GetResultText()
        {
            try
            {
                return resultText.Text;
            }
            catch (Exception ex)
            {
                // Report "Can not get target text"
                throw ex;
            }
        }


    }
}
