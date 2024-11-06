using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AhorcadoGame;

namespace MSTest_Ahorcado
{
    [TestClass]
    public class AhorcadoTests
    {
        [TestMethod]
        public void ElSistemaEligeUnaPalabraSecreta()
        {
            // Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            // Act
            ahorcadoJuego.IngresarPalabraSecreta("hola");

            // Assert
            Assert.IsNotNull(ahorcadoJuego.PalabraSecreta);
        }

        [TestMethod]
        public void LetraIngresadaSeAgregaAListaDeIntentos()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            //Act
            ahorcadoJuego.AdivinarLetra('a');

            //Assert
            Assert.IsNotNull(ahorcadoJuego.LetrasIntentadas);
            Assert.IsTrue(ahorcadoJuego.LetrasIntentadas.Contains('a'));
        }

        [TestMethod]
        public void IngresarLetraADevuelveCorrecto()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            //Act
            bool result = ahorcadoJuego.AdivinarLetra('a');

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IngresarLetraXDevuelveIncorrecto()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            //Act
            bool result = ahorcadoJuego.AdivinarLetra('x');

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IngresarSoloLetrasA_Z()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            //Act
            bool result = ahorcadoJuego.AdivinarLetra('a');

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IngresarNumeroDevuelveIncorrecto()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            //Act
            bool result = ahorcadoJuego.AdivinarLetra('3');

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IngresarLaPalabraCorrectaGanaLaPartida()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            //Act
            bool result = ahorcadoJuego.AdivinarPalabra("Hola");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IngresarUnaPalabraIncorrectaPierdeLaPartida()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            //Act
            bool result = ahorcadoJuego.AdivinarPalabra("chau");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RestarVidaPorLetraErronea()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            //Act
            ahorcadoJuego.AdivinarLetra('j');

            //Assert
            Assert.AreEqual(5, ahorcadoJuego.VidasRestantes);
        }

        [TestMethod]
        public void VerCantidadLetrasDeLaPalabra()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();
            ahorcadoJuego.IngresarPalabraSecreta("hola");

            //Act
            int cantidadLetras = ahorcadoJuego.PalabraSecreta.Length;

            //Assert
            Assert.AreEqual(4, cantidadLetras);
        }

        [TestMethod]
        public void VerIntentosRestantes()
        {
            // Arrange
            var ahorcadoJuego = new AhorcadoJuego();
            int vidasIniciales = ahorcadoJuego.VidasRestantes;

            // Act
            ahorcadoJuego.AdivinarLetra('x');
            int vidasRestantes = ahorcadoJuego.VidasRestantes;

            // Assert
            Assert.AreEqual(vidasIniciales - 1, vidasRestantes);
        }

        [TestMethod]
        public void GanarJuegoAlAdivinarTodasLasLetras()
        {
            // Arrange
            var ahorcadoJuego = new AhorcadoJuego();
            ahorcadoJuego.IngresarPalabraSecreta("hola");

            // Act
            ahorcadoJuego.AdivinarLetra('H');
            ahorcadoJuego.AdivinarLetra('o');
            ahorcadoJuego.AdivinarLetra('l');
            ahorcadoJuego.AdivinarLetra('a');
            bool juegoGanado = ahorcadoJuego.JuegoGanado();

            // Assert
            Assert.IsTrue(juegoGanado);
            Assert.IsFalse(ahorcadoJuego.JuegoPerdido());
        }

        [TestMethod]
        public void PerderJuegoCuandoGastoTodasLasVidas()
        {
            // Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            // Act
            ahorcadoJuego.AdivinarLetra('x');
            ahorcadoJuego.AdivinarLetra('x');
            ahorcadoJuego.AdivinarLetra('x');
            ahorcadoJuego.AdivinarLetra('x');
            ahorcadoJuego.AdivinarLetra('x');
            ahorcadoJuego.AdivinarLetra('x');
            bool juegoPerdido = ahorcadoJuego.JuegoPerdido();

            // Assert
            Assert.IsTrue(juegoPerdido);
            Assert.IsFalse(ahorcadoJuego.JuegoGanado());
        }
    }
}
