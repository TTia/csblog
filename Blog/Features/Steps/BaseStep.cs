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

        protected void takeScreenshot(string fileName = @"screenshot.jpg")
        {
            browser.SaveScreenshot(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        protected string getBackgroundColor(string id)
        {
            var script = String.Format("$('#{0}').css('backgroundColor');", id);

            var selenium = ((OpenQA.Selenium.Remote.RemoteWebDriver)browser.Native);
            var selenium_bcolor = selenium.ExecuteScript(script);
            var coypu_bcolor = browser.ExecuteScript(script);

            Assert.NotNull(coypu_bcolor);
            Assert.NotNull(coypu_bcolor);

            return coypu_bcolor;
        }

        protected void InsertTitle(string title)
        {
            browser.FillIn("Titolo").With(title);
        }
        protected void InsertBody()
        {
            string post = "Bla ";
            while (post.Length < 600)
            {
                post += post + " bla";
            }
            browser.FillIn("Post").With(post);
        }

        protected void InsertBody(string body)
        {
            browser.FillIn("Post").With(body);
        }

        protected void SavePost()
        {
            browser.FindId("submit").Click();
        }

        protected ElementScope findPostByTitle(String title) {
            return browser.FindAllCss(".post").First(p => p.FindLink(title, new Options { TextPrecision = TextPrecision.Substring }).Exists());
        }

        protected ElementScope FindNotice(string noticeMessage)
        {
            var notice = browser.FindId("notice");
            Assert.That(notice.Exists());
            Assert.AreEqual(noticeMessage, notice.Text);
            return notice;
        }
    }
}
