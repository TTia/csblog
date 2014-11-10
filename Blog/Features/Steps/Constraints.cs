using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Coypu.NUnit.Matchers;

namespace Blog.Features.Steps
{
    [Binding]
    public class Constraints : BaseStep
    {
        [Given(@"apro RBlog")]
        public void DatoAproRBlog()
        {
            browser.Visit("/");
            //takeScreenshot();
            Assert.AreEqual("CSBlog", browser.Title);

        }
        [Given(@"è presente l'intestazione")]
        public void DatoEPresenteLIntestazione()
        {
            Assert.True(header.Exists());
        }

        [Given(@"è presente il pié di pagina")]
        public void DatoEPresenteIlPieDiPagina()
        {
            Assert.True(footer.Exists());
        }

        [Given(@"l'intestazione ha un colore di sfondo")]
        public void DatoLIntestazioneHaUnColoreDiSfondo()
        {
            Assert.Fail();
        }

        [Given(@"il pié di pagina ha un colore di sfondo")]
        public void DatoIlPieDiPaginaHaUnColoreDiSfondo()
        {
            Assert.Fail();
        }

        [Given(@"i collegamenti non hanno sfondo")]
        public void DatoICollegamentiNonHannoSfondo()
        {
            Assert.Fail();
        }

        [Given(@"l'intestazione permette la navigazione")]
        public void DatoLIntestazionePermetteLaNavigazione()
        {
            var header = base.header;
            Assert.AreEqual(4, browser.FindAllCss(".banner_link").Count());
        }

        [Given(@"la pagina ha un titolo")]
        public void DatoLaPaginaHaUnTitolo()
        {
            Assert.NotNull(browser.Text);
            Assert.IsNotEmpty(browser.Text);
        }

        [Given(@"navigo verso ""(.*)""")]
        public void DatoNavigoVerso(string pageName)
        {
            browser.ClickLink(pageName);
        }

        [Given(@"sono presenti dei collegamenti raffigurati tramite immagini")]
        public void DatoSonoPresentiDeiCollegamentiRaffiguratiTramiteImmagini()
        {
            Assert.Greater(browser.FindAllCss("a img").Count(), 0);
        }

    }
}
