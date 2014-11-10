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
    [NUnit.Framework.DescriptionAttribute("Ricerca fra i post")]
    [NUnit.Framework.CategoryAttribute("cap5")]
    [NUnit.Framework.CategoryAttribute("clear")]
    public partial class RicercaFraIPostFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "5_introducing_search.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("it-IT"), "Ricerca fra i post", "Come Lettore\nVorrei poter ricercare i post su RBlog\nPer poter navigare fra i cont" +
                    "enuti più velocemente", ProgrammingLanguage.CSharp, new string[] {
                        "cap5",
                        "clear"});
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
    testRunner.Given("apro RBlog", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 10
    testRunner.Given("mi autentico come \"mattia@rblog.io\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Autocompletamento della ricerca")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void AutocompletamentoDellaRicerca()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Autocompletamento della ricerca", new string[] {
                        "ignore"});
#line 13
  this.ScenarioSetup(scenarioInfo);
#line 8
  this.FeatureBackground();
#line 14
    testRunner.Given("nell\'intestazione è presente la barra di ricerca", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 15
    testRunner.Given("il post \"Lorem Ipsum\" esiste", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 16
    testRunner.When("inserisco il testo \"Lorem\" da ricercare", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 17
    testRunner.Then("viene proposto il post \"Lorem Ipsum\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line 18
    testRunner.When("inserisco il testo \"lor\" da ricercare", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 19
    testRunner.Then("viene proposto il post \"Lorem Ipsum\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line 20
    testRunner.When("inserisco il testo \"xyz\" da ricercare", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 21
    testRunner.Then("non è proposto alcun post", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line 22
    testRunner.When("inserisco il testo \"L\" da ricercare", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 23
    testRunner.Then("non è proposto alcun post", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ricerca di un post esistente")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void RicercaDiUnPostEsistente()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ricerca di un post esistente", new string[] {
                        "ignore"});
#line 26
  this.ScenarioSetup(scenarioInfo);
#line 8
  this.FeatureBackground();
#line 27
    testRunner.Given("nell\'intestazione è presente la barra di ricerca", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 28
    testRunner.Given("il post \"Lorem Ipsum\" esiste", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 29
    testRunner.When("ricerco \"Lorem\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 30
    testRunner.Then("il post \"Lorem Ipsum\" è leggibile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line 31
    testRunner.When("ricerco \"lo\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 32
    testRunner.Then("il post \"Lorem Ipsum\" è leggibile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ricerca di un post non esistente")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void RicercaDiUnPostNonEsistente()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ricerca di un post non esistente", new string[] {
                        "ignore"});
#line 35
  this.ScenarioSetup(scenarioInfo);
#line 8
  this.FeatureBackground();
#line 36
    testRunner.Given("nell\'intestazione è presente la barra di ricerca", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 37
    testRunner.Given("il post \"Lorem Ipsum\" esiste", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dato ");
#line 38
    testRunner.When("ricerco \"XXX\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 39
    testRunner.Then("il post \"Lorem Ipsum\" non è leggibile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Allora ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion