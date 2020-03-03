using GoogleTranslateUIAutomationTesting.Pages.TranslationBlock;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace GoogleTranslateUIAutomationTesting.Pages
{
    public class HomePage : Page
    {
        [FindsBy(How = How.ClassName, Using = "acknowledge-button button")]
        private IWebElement notification;        

        public static MainTranslationBlock TranslationBlock => GetPage<MainTranslationBlock>();

        public void CloseNotificationIfExists()
        {
            try
            {
                if (notification != null)
                    notification.Click();
            }
            catch (Exception ex)
            {
                // TODO: Report "Notification does not exist.";
            }
        }

    }
}
