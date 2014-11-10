using Coypu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Blog.Features.Steps
{
    public class BaseStep
    {
        protected BrowserSession browser = Hooks.Hooks.browser;

        protected ElementScope header {get{return browser.FindId("header");}}
        protected ElementScope footer {get{return browser.FindId("footer");}}

        public void takeScreenshot(string fileName = @"screenshot.jpg")
        {
            browser.SaveScreenshot(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public string getBackgroundColor(string id) {
            var script = String.Format("$('#{0}').css('backgroundColor');", id);

            var selenium = ((OpenQA.Selenium.Remote.RemoteWebDriver)browser.Native);
            var selenium_bcolor = selenium.ExecuteScript(script);
            var coypu_bcolor = browser.ExecuteScript(script);

            Assert.NotNull(coypu_bcolor);
            Assert.NotNull(coypu_bcolor);

            return coypu_bcolor;
        }
    }
}
