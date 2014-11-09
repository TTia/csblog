using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Blog.Features.Steps
{
    [Binding]
    public class Events : BaseStep
    {

        [When(@"navigo verso ""(.*)""")]
        public void QuandoNavigoVerso(string pageName)
        {
            Assert.True(browser.FindLink(pageName).Exists());
            browser.ClickLink(pageName);
        }
    }
}
