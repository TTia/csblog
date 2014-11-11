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

            foreach (var linked_image in linked_images)
            {
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

        [Then(@"il post ""(.*)"" è stato creato con successo")]
        public void AlloraIlPostEStatoCreatoConSuccesso(string title)
        {
            string noticeMessage = String.Format("Il post '{0}' è stato creato con successo.", title);
            base.FindNotice(noticeMessage);
        }

        [Then(@"il post ""(.*)"" è stato cancellato con successo")]
        public void AlloraIlPostEStatoCancellatoConSuccesso(string title)
        {
            string noticeMessage = String.Format("Il post '{0}' è stato cancellato con successo.", title);
            base.FindNotice(noticeMessage);
        }

        [Then(@"compare l'errore ""(.*)""")]
        public void AlloraCompareLErrore(string errorMessage)
        {
            Assert.That(browser.HasContent(errorMessage));
        }

        [Then(@"ogni post ha un titolo")]
        public void AlloraOgniPostHaUnTitolo()
        {
            foreach (var post in browser.FindAllCss(".post"))
            {
                Assert.That(post.FindCss(".post_title", new Options { Match = Match.Single }).Exists());
            }
        }

        [Then(@"ogni post ha dei dettagli")]
        public void AlloraOgniPostHaDeiDettagli()
        {
            foreach (var post in browser.FindAllCss(".post"))
            {
                Assert.That(post.FindCss(".post_detail", new Options { Match = Match.First }).Exists());
            }
        }

        [Then(@"ogni post ha del contenuto")]
        public void AlloraOgniPostHaDelContenuto()
        {
            foreach (var post in browser.FindAllCss(".post"))
            {
                Assert.That(post.FindCss(".post_body", new Options { Match = Match.Single }).Exists());
            }
        }

        [Then(@"il contenuto del post ""(.*)"" è un_anteprima dell_intero post")]
        public void AlloraIlContenutoDelPostEUn_AnteprimaDell_InteroPost(string title)
        {
            var post = base.findPostByTitle(title);
            string body = post.FindCss(".post_body").Text;
            Assert.IsNotEmpty(body);
            Assert.Less(body.Length, 550);
            Assert.That(post, Shows.Content("Leggi il resto"));
        }

        [Then(@"il contenuto del post ""(.*)"" rappresenta l'intero post")]
        public void AlloraIlContenutoDelPostRappresentaLInteroPost(string title)
        {
            var post = base.findPostByTitle(title);
            string body = post.FindCss(".post_body").Text;
            Assert.IsNotEmpty(body);
            Assert.Greater(body.Length, 550);
            Assert.That(post, Shows.No.Content("Leggi il resto"));
        }

        [Then(@"il titolo del post è ""(.*)""")]
        public void AlloraIlTitoloDelPostE(string title)
        {
            var post = base.findPostByTitle(title);
            Assert.That(post.FindCss(".post_title", new Options { Match = Match.Single }).Exists());
        }
        [Then(@"tramite l'intestazione posso autenticarmi")]
        public void AlloraTramiteLIntestazionePossoAutenticarmi()
        {
            var header = base.header;
            Assert.That(header.FindLink("Login").Exists());
        }

        [Then(@"l'utente è autenticato")]
        public void AlloraLUtenteEAutenticato()
        {
            base.FindNotice("Login effettuato, benvenuto!");
        }

        [Then(@"tramite l'intestazione posso disconnettermi")]
        public void AlloraTramiteLIntestazionePossoDisconnettermi()
        {
            var header = base.header;
            var logoutLink = header.FindLink("Esci", new Options { TextPrecision = TextPrecision.Substring });

            Assert.That(logoutLink.Exists());
            Assert.That(logoutLink["href"].Contains("/Author/Logout"));
        }

        [Then(@"tramite l'intestazione non posso autenticarmi")]
        public void AlloraTramiteLIntestazioneNonPossoAutenticarmi()
        {
            var header = base.header;
            var logoutLink = header.FindLink("Esci", new Options { TextPrecision = TextPrecision.Substring });

            Assert.That(logoutLink.Exists());
            Assert.That(logoutLink["href"].Contains("/Author/Logout"));
            Assert.That(!header.FindLink("Login").Exists());
        }


        [Then(@"compare l'errore di autenticazione ""(.*)""")]
        public void AlloraCompareLErroreDiAutenticazione(string p0)
        {
            FindNotice("Credenziali invalide.");
        }

        [Then(@"non posso visitare la pagina per la creazione di un nuovo post")]
        public void AlloraNonPossoVisitareLaPaginaPerLaCreazioneDiUnNuovoPost()
        {
            browser.Visit("/Post/Create");
            base.FindNotice("Devi prima effettuare l'accesso.");
        }

        [Then(@"posso navigare verso la pagina per la creazione di un nuovo post")]
        public void AlloraPossoNavigareVersoLaPaginaPerLaCreazioneDiUnNuovoPost()
        {
            browser.Visit("/Post/Create");
            Assert.That(browser, Shows.No.Content("Devi prima effettuare l'accesso."));
            Assert.That(browser, Shows.Content("Scrivi un nuovo post"));
        }

        [Given(@"non è presente il logo nell'intestazione")]
        public void DatoNonEPresenteIlLogoNellIntestazione()
        {
            Assert.That(base.footer, Shows.No.Css("img"));
        }

        [Then(@"è presente il logo")]
        public void AlloraEPresenteIlLogo()
        {
            var footer = base.footer;
            Assert.That(footer, Shows.Css("img"));
            Assert.That(footer.FindId("woodstock").Exists());
        }

    }
}
