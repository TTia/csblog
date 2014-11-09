using Coypu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Features.Steps
{
    public class BaseStep
    {
        protected BrowserSession browser = Hooks.Hooks.browser;

        public void takeScreenshot(string fileName = @"screenshot.jpg")
        {
            browser.SaveScreenshot(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
