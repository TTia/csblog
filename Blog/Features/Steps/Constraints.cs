using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Blog.Features.Steps
{
    [Binding]
    public class Constraints : BaseStep
    {
        [Given(@"apro RBlog")]
        public void DatoAproRBlog()
        {
            browser.Visit("/");
            takeScreenshot();
            Assert.AreEqual("CSBlog", browser.Title);
            
        }

    }
}
