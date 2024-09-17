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
    }
}