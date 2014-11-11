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
            string post = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."+
                            "Nullam sit amet odio tincidunt, pretium urna eu, euismod mauris."+
                            "Pellentesque ut augue ut leo posuere commodo ac vel odio."+
                            "Vivamus aliquam mollis nunc, at viverra dui pellentesque sit amet."+
                            "Donec sed ullamcorper ipsum. Nam a metus pellentesque, tempor lacus ut, bibendum lorem."+
                            "Sed volutpat eget dui in cursus. Suspendisse a quam ut diam ultricies mattis."+
                            "Morbi malesuada arcu vel massa aliquam tempus.\n"+
                            "Aenean vitae elementum odio. Maecenas eget metus elementum nisl fermentum rhoncus non et orci."+
                            "Donec condimentum metus magna, sed posuere sapien vestibulum ac. Cras ut tincidunt enim."+
                            "Phasellus aliquam, justo ut convallis dictum, nibh leo pretium nisi,"+
                            "mollis pellentesque lacus ipsum id dolor. Sed ut ipsum sed leo rhoncus maximus."+
                            "Duis at odio quis leo tristique ornare sit amet quis orci."+
                            "Pellentesque eleifend sem eu mauris eleifend condimentum."+
                            "Ut non luctus odio. Suspendisse potenti."+
                            "Suspendisse ultrices eu urna ac tincidunt."+
                            "Donec eget fermentum massa."+
                            "Nullam dolor ante, placerat vitae mi eu, auctor blandit sapien."+
                            "Suspendisse vel velit ac quam fermentum pretium."+
                            "Nulla congue lorem et dui dictum pretium vitae scelerisque nunc.";
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
