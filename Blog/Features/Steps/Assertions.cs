using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Blog.Features.Steps
{
    [Binding]
    public class Assertions : BaseStep
    {
        [Then(@"posso visitare la pagina dell'autore")]
        public void AlloraPossoVisitareLaPaginaDellAutore()
        {
            Assert.True(browser.FindLink("Autore").Exists());
        }
        [Then(@"posso visitare la pagina dell'abstract")]
        public void AlloraPossoVisitareLaPaginaDellAbstract()
        {
            Assert.True(browser.FindLink("Abstract").Exists());
        }
        [Then(@"la pagina è intitolata ""(.*)""")]
        public void AlloraLaPaginaEIntitolata(string pageTitle)
        {
            Assert.AreEqual(pageTitle, browser.Title);
        }

        [Then(@"posso tornare alla pagina iniziale")]
        public void AlloraPossoTornareAllaPaginaIniziale()
        {
            var logoLink = browser.FindId("logo");
            Assert.That(logoLink.Exists());
            logoLink.Click();
            Assert.AreEqual("CSBlog", browser.Title);
        }

    }
}
