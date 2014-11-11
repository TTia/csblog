﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Coypu;

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

        [When(@"il cursore si sposta sui collegamenti")]
        public void QuandoIlCursoreSiSpostaSuiCollegamenti()
        {
            Assert.Fail();
        }

        [When(@"inserisco ""(.*)"" come titolo")]
        public void QuandoInseriscoComeTitolo(string title)
        {
            InsertTitle(title);
        }

        [When(@"inserisco del testo riempitivo come contenuto")]
        public void QuandoInseriscoDelTestoRiempitivoComeContenuto()
        {
            InsertBody();
        }

        [When(@"inserisco ""(.*)"" come contenuto")]
        public void QuandoInseriscoComeContenuto(string body)
        {
            base.InsertBody(body);
        }


        [When(@"salvo il post")]
        public void QuandoSalvoIlPost()
        {
            SavePost();
        }

        [When(@"modifico il post ""(.*)""")]
        public void QuandoModificoIlPost(string title)
        {
            var post = findPostByTitle(title);
            post.FindCss(".edit_post_button").Click();
        }

        [When(@"cancello il post ""(.*)""")]
        public void QuandoCancelloIlPost(string title)
        {
            var post = findPostByTitle(title);
            post.FindCss(".remove_post_button").Click();
            browser.ClickButton("Confermi la rimozione?");
        }

        [When(@"espando il post ""(.*)""")]
        public void QuandoEspandoIlPost(string title)
        {
            var post = base.findPostByTitle(title);
            post.ClickLink(title);
        }

    }
}
