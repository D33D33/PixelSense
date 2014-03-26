using MonJoliPortavion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestMenu
{
    
    
    /// <summary>
    ///Classe de test pour AircraftCarrierWindowTest, destinée à contenir tous
    ///les tests unitaires AircraftCarrierWindowTest
    ///</summary>
    [TestClass()]
    public class AircraftCarrierWindowTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        // 
        //Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        //Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Test pour Constructeur AircraftCarrierWindow
        ///</summary>
        [TestMethod()]
        public void AircraftCarrierWindowConstructorTest()
        {
            AircraftCarrierWindow target = new AircraftCarrierWindow();
            Assert.Inconclusive("TODO: implémentez le code pour vérifier la cible");
        }

        /// <summary>
        ///Test pour AircraftCarrierWindow_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MonJoliPortavion.exe")]
        public void AircraftCarrierWindow_LoadTest()
        {
            AircraftCarrierWindow_Accessor target = new AircraftCarrierWindow_Accessor(); // TODO: initialisez à une valeur appropriée
            object sender = null; // TODO: initialisez à une valeur appropriée
            EventArgs e = null; // TODO: initialisez à une valeur appropriée
            target.AircraftCarrierWindow_Load(sender, e);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MonJoliPortavion.exe")]
        public void DisposeTest()
        {
            AircraftCarrierWindow_Accessor target = new AircraftCarrierWindow_Accessor(); // TODO: initialisez à une valeur appropriée
            bool disposing = false; // TODO: initialisez à une valeur appropriée
            target.Dispose(disposing);
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }

        /// <summary>
        ///Test pour InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("MonJoliPortavion.exe")]
        public void InitializeComponentTest()
        {
            AircraftCarrierWindow_Accessor target = new AircraftCarrierWindow_Accessor(); // TODO: initialisez à une valeur appropriée
            target.InitializeComponent();
            Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        }
    }
}
