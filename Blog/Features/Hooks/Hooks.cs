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
        public static BrowserSession browser { get { return _browser;  } }

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
            //sessionConfiguration.Timeout = TimeSpan.FromSeconds(10);

            _browser = new BrowserSession(sessionConfiguration);
            _browser.MaximiseWindow();
            _objectContainer.RegisterInstanceAs(_browser);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            _browser.Dispose();
        }
    }
}
