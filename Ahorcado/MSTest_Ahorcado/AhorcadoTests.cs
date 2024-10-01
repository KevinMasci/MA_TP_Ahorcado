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
    }
}