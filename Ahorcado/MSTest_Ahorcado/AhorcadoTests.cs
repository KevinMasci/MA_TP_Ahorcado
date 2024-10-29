using Ahorcado;

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
            ahorcadoJuego.ElegirPalabraSecreta();

            // Assert
            Assert.IsNotNull(ahorcadoJuego.PalabraSecreta);
        }

        [TestMethod]
        public void IngresarUnaLetra()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            //Act
            ahorcadoJuego.AdivinarLetra('a');

            //Assert
            Assert.IsNotNull(ahorcadoJuego.LetrasIntentadas);
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
        public void IngresarUnaPalabra()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            //Act
            bool result = ahorcadoJuego.AdivinarPalabra("Hola");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RestarVidaPorLetraErronea()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();

            //Act
            bool result = ahorcadoJuego.AdivinarLetra('j');

            //Assert
            Assert.AreEqual(5, ahorcadoJuego.VidasRestantes);
        }

        [TestMethod]
        public void VerCantidadLetrasDeLaPalabra()
        {
            //Arrange
            var ahorcadoJuego = new AhorcadoJuego();
            ahorcadoJuego.ElegirPalabraSecreta();

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
            ahorcadoJuego.PalabraSecreta = "Hola";

            // Act
            ahorcadoJuego.AdivinarLetra('H');
            ahorcadoJuego.AdivinarLetra('o');
            ahorcadoJuego.AdivinarLetra('l');
            ahorcadoJuego.AdivinarLetra('a');
            bool juegoGanado = ahorcadoJuego.JuegoGanado();

            // Assert
            Assert.IsTrue(juegoGanado);
        }

        public void PerderJuegoCuandoVidasSonCero()
        {
            // Arrange
            var ahorcadoJuego = new AhorcadoJuego();
            ahorcadoJuego.VidasRestantes = 1;

            // Act
            ahorcadoJuego.AdivinarLetra('K');
            bool juegoPerdido = ahorcadoJuego.JuegoPerdido();

            // Assert
            Assert.IsTrue(juegoPerdido);
        }
    }
}