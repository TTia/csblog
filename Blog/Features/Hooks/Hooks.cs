using BoDi;
using Coypu;
using Coypu.Drivers.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Blog.Features.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private static BrowserSession _browser;
        public static BrowserSession browser { get { return _browser; } }

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Before()
        {
            var sessionConfiguration = new SessionConfiguration
            {
                Port = 1448,
            };
            sessionConfiguration.Driver = typeof(SeleniumWebDriver);
            sessionConfiguration.Browser = Coypu.Drivers.Browser.PhantomJS;
            sessionConfiguration.Timeout = TimeSpan.FromSeconds(5);

            _browser = new BrowserSession(sessionConfiguration);
            _browser.MaximiseWindow();
            _objectContainer.RegisterInstanceAs(_browser);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("clear")
                 || FeatureContext.Current.FeatureInfo.Tags.Contains("clear"))
            {
                login();

                string LoremIpsumTitle = "Lorem Ipsum";
                string xpathQuery = String.Format(
                    "//div[@class = 'post'][p/a[contains(text(),'{0}')]]", LoremIpsumTitle);

                browser.Visit("/");
                foreach (var post in browser.FindAllXPath(xpathQuery)) {
                    post.FindCss(".remove_post_button").Click();
                    browser.ClickButton("Confermi la rimozione?");                    
                }
                /*
                foreach (var post in browser.FindAllCss(".post"))
                {
                    if (!post.FindCss(".post_title",
                                        LoremIpsumTitle,
                                        new Options { TextPrecision = TextPrecision.Substring })
                                            .Exists())
                    {
                        continue;
                    }
                    post.FindCss(".remove_post_button").Click();
                    browser.ClickButton("Confermi la rimozione?");
                }
                */
            }
            //browser.SaveScreenshot("screenshot.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            _browser.Dispose();
        }

        private void login()
        {
            if (browser.FindId("log_out_link").Exists())
            {
                return;
            }
            string password = "password";
            browser.Visit("/");
            browser.ClickLink("Login");
            browser.FillIn("Email").With("ttia@csblog.io");
            browser.FillIn("Password").With(password);
            browser.ClickButton("Login");
        }

    }
}
