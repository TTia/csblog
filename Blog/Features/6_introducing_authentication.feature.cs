﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Blog.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Autenticazione su SBlog")]
    [NUnit.Framework.CategoryAttribute("cap6")]
    public partial class AutenticazioneSuSBlogFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "6_introducing_authentication.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("it-IT"), "Autenticazione su SBlog", "Come Autore di SBlog\nVorrei che alcune operazioni sensibili siano permesse previa" +
                    " autenticazione\nPer poter garantire l\'autenticità dei contenuti", ProgrammingLanguage.CSharp, new string[] {
                        "cap6"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 8
  #line 9
    testRunner.Given("apro SBlog", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Possibilità di autenticarsi")]
        public virtual void PossibilitaDiAutenticarsi()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Possibilità di autenticarsi", ((string[])(null)));
#line 11
  this.ScenarioSetup(scenarioInfo);
#line 8
  this.FeatureBackground();
#line 12
    testRunner.Given("l\'utente non è autenticato", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 13
    testRunner.Then("tramite l\'intestazione posso autenticarmi", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Autenticazione su SBlog")]
        public virtual void AutenticazioneSuSBlog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Autenticazione su SBlog", ((string[])(null)));
#line 15
  this.ScenarioSetup(scenarioInfo);
#line 8
  this.FeatureBackground();
#line 16
    testRunner.Given("l\'utente non è autenticato", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 17
    testRunner.Then("tramite l\'intestazione posso autenticarmi", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line 18
    testRunner.When("mi autentico come \"ttia@sblog.io\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 19
    testRunner.Then("l\'utente è autenticato", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line 20
    testRunner.And("tramite l\'intestazione non posso autenticarmi", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 21
    testRunner.And("tramite l\'intestazione posso disconnettermi", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Disconnessione da SBlog")]
        public virtual void DisconnessioneDaSBlog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Disconnessione da SBlog", ((string[])(null)));
#line 23
  this.ScenarioSetup(scenarioInfo);
#line 8
  this.FeatureBackground();
#line 24
    testRunner.Given("l\'utente non è autenticato", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 25
    testRunner.When("mi autentico come \"ttia@sblog.io\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 26
    testRunner.Then("tramite l\'intestazione posso disconnettermi", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line 27
    testRunner.When("quando mi disconnetto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 28
    testRunner.And("l\'utente non è autenticato", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Possibilità di compiere operazioni sensibili avendo compiuto l\'accesso")]
        public virtual void PossibilitaDiCompiereOperazioniSensibiliAvendoCompiutoLAccesso()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Possibilità di compiere operazioni sensibili avendo compiuto l\'accesso", ((string[])(null)));
#line 30
  this.ScenarioSetup(scenarioInfo);
#line 8
  this.FeatureBackground();
#line 31
    testRunner.Given("l\'utente non è autenticato", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 32
    testRunner.When("mi autentico come \"ttia@sblog.io\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 33
    testRunner.Then("posso navigare verso la pagina per la creazione di un nuovo post", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Autenticazione fallita su SBlog")]
        public virtual void AutenticazioneFallitaSuSBlog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Autenticazione fallita su SBlog", ((string[])(null)));
#line 35
  this.ScenarioSetup(scenarioInfo);
#line 8
  this.FeatureBackground();
#line 36
    testRunner.Given("l\'utente non è autenticato", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 37
    testRunner.Then("tramite l\'intestazione posso autenticarmi", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line 38
    testRunner.When("mi autentico come \"anonymous@sblog.io\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 39
    testRunner.Then("l\'utente non è autenticato", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line 40
    testRunner.And("compare l\'errore di autenticazione \"Credenziali invalide.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion