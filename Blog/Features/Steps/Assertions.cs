using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Coypu;
using Coypu.NUnit.Matchers;

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

        [Then(@"lo sfondo del collegamento cambia")]
        public void AlloraLoSfondoDelCollegamentoCambia()
        {
            Assert.Fail();
        }

        [Then(@"ogni collegamento ha una descrizione testuale")]
        public void AlloraOgniCollegamentoHaUnaDescrizioneTestuale()
        {       
            IEnumerable<SnapshotElementScope> linked_images = browser.FindAllCss("a img");
            //Assert.That(linked_images.All(li => li != null));

            foreach (var linked_image in linked_images)
            {
                //Assert.That(linked_image.Exists());
                Assert.NotNull(linked_image["alt"]);
                Assert.IsNotEmpty(linked_image["alt"]);
            }
        }

        [Then(@"l_intestazione è posizionata all_inizio")]
        public void AlloraLInizio()
        {
            var first = browser.FindXPath("//body/*[1]");
            Assert.True(first.Exists());
            Assert.True(header.Exists());
            Assert.AreEqual(first.Id, header.Id);
        }

        [Then(@"il piè di pagina è posizionato alla fine")]
        public void AlloraIlPieDiPaginaEPosizionatoAllaFine()
        {
            var last = browser.FindXPath("descendant::body/div[last()]");
            Assert.True(last.Exists());
            Assert.True(footer.Exists());
            Assert.AreEqual(last.Id, footer.Id);
        }

        [Then(@"posso navigare verso ""(.*)""")]
        public void AlloraPossoNavigareVerso(string pageName)
        {
            browser.FindLink(pageName);
        }
        [Then(@"intestazione e pié di pagina hanno lo stesso colore di sfondo")]
        public void AlloraIntestazioneEPieDiPaginaHannoLoStessoColoreDiSfondo()
        {
            Assert.Fail();
        }

        [Then(@"il titolo della pagina è uguale a ""(.*)""")]
        public void AlloraIlTitoloDellaPaginaEUgualeA(string pageName)
        {
            Assert.AreEqual(browser.Title, pageName);
        }
    }
}
