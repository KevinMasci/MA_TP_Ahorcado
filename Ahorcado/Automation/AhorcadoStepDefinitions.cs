using AhorcadoGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Automation
{
    [Binding]
    public class AhorcadoStepDefinitions
    {
        private IWebDriver driver;
        AhorcadoJuego juego;
        string baseURL;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            baseURL = "http://localhost:39278/";
            driver.Navigate().GoToUrl(baseURL);
        }

        [Given(@"La palabra secreta es ahorcado")]
        public void GivenLaPalabraSecretaEsAhorcado()
        {
            juego = new AhorcadoJuego();
            juego.IngresarPalabraSecreta("Ahorcado");

            Thread.Sleep(5000);

            var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
            txtPalabra.SendKeys("Ahorcado");

            Thread.Sleep(1000);

            var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
            btnInsertWord.SendKeys(Keys.Enter);

            Thread.Sleep(1000);
        }

        [When(@"Ingreso seis palabras incorrectas diferentes")]
        public void WhenIngresoSeisPalabrasIncorrectasDiferentes()
        {
            var letrasIncorrectas = new[] { "X", "Y", "Z", "Q", "W", "P" };

            var letterTyped = driver.FindElement(By.Id("LetterTyped"));
            var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));
            for (int i = 0; i < 6; i++)
            {
                letterTyped.SendKeys(letrasIncorrectas[i]);
                Thread.Sleep(1000);
                btnInsertLetter.SendKeys(Keys.Enter);
            }
        }

        [Then(@"Deberia decirme que perdi el juego")]
        public void ThenDeberiaDecirmeQuePerdiElJuego()
        {
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            var loss = Convert.ToInt32(chancesLeft.GetAttribute("value")) == 0;
            Thread.Sleep(1000);
            Assert.IsTrue(loss);
            Thread.Sleep(1000);
        }

        [Given(@"La palabra secreta es juego")]
        public void GivenLaPalabraSecretaEsJuego()
        {
            juego = new AhorcadoJuego();
            juego.IngresarPalabraSecreta("juego");

            Thread.Sleep(5000);

            var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
            txtPalabra.SendKeys("juego");

            Thread.Sleep(1000);

            var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
            btnInsertWord.SendKeys(Keys.Enter);

            Thread.Sleep(1000);
        }

        [When(@"Ingreso las letras correctas")]
        public void WhenIngresoLasLetrasCorrectas()
        {
            var letrasCorrectas = new[] { "j", "u", "e", "g", "o" };

            var letterTyped = driver.FindElement(By.Id("LetterTyped"));
            var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));
            foreach (var letra in letrasCorrectas)
            {
                letterTyped.SendKeys(letra);
                Thread.Sleep(1000);
                btnInsertLetter.SendKeys(Keys.Enter);
            }
        }

        [Then(@"Deberia decirme que gane el juego")]
        public void ThenDeberiaDecirmeQueGaneElJuego()
        {
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            var win = Convert.ToInt32(chancesLeft.GetAttribute("value")) > 0;
            Thread.Sleep(1000);
            Assert.IsTrue(win);
            Thread.Sleep(1000);
        }

        [Given(@"La palabra secreta es hola y ya ingrese la h")]
        public void GivenLaPalabraSecretaEsHolaYYaIngreseLaH()
        {
            juego = new AhorcadoJuego();
            juego.IngresarPalabraSecreta("hola");

            Thread.Sleep(5000);

            var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
            txtPalabra.SendKeys("hola");

            Thread.Sleep(1000);

            var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
            btnInsertWord.SendKeys(Keys.Enter);

            Thread.Sleep(1000);

            var letterTyped = driver.FindElement(By.Id("LetterTyped"));
            var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));

            letterTyped.SendKeys("h");
            btnInsertLetter.SendKeys(Keys.Enter);
        }

        [When(@"Ingreso la letra h")]
        public void WhenIngresoLaLetraH()
        {
            var letterTyped = driver.FindElement(By.Id("LetterTyped"));
            var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));

            letterTyped.SendKeys("h");
            btnInsertLetter.SendKeys(Keys.Enter);
        }

        [Then(@"No deberia restar intentos")]
        public void ThenNoDeberiaRestarIntentos()
        {
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            var chances = Convert.ToInt32(chancesLeft.GetAttribute("value"));
            Thread.Sleep(1000);
            Assert.AreEqual(chances, 6);
            Thread.Sleep(1000);
        }

        [Given(@"La palabra secreta es metodologia")]
        public void GivenLaPalabraSecretaEsMetodologia()
        {
            juego = new AhorcadoJuego();
            juego.IngresarPalabraSecreta("metodologia");

            Thread.Sleep(5000);

            var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
            txtPalabra.SendKeys("metodologia");

            Thread.Sleep(1000);

            var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
            btnInsertWord.SendKeys(Keys.Enter);

            Thread.Sleep(1000);
        }

        [When(@"Ingreso la letra o")]
        public void WhenIngresoLaLetraO()
        {
            var letterTyped = driver.FindElement(By.Id("LetterTyped"));
            var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));

            letterTyped.SendKeys("o");
            btnInsertLetter.SendKeys(Keys.Enter);
        }

        [Then(@"Deberia ubicarse en las posiciones correctas")]
        public void ThenDeberiaUbicarseEnLasPosicionesCorrectas()
        {
            var guessingWord = driver.FindElement(By.Id("GuessingWord"));
            var palabra = guessingWord.GetAttribute("value");

            Assert.AreEqual(palabra, "_ _ _ o _ o _ o _ _ _");
        }

        [AfterScenario]
        public void TestCleanUp()
        {
            driver.Quit();
        }
    }
}
