using NUnit.Framework;
using Ahorcado;
namespace Test
{
    public class TestAhorcado
    {
        Ahorcado.Ahorcado ahorcado;

        [SetUp]
        public void Setup()
        {
            ahorcado = new Ahorcado.Ahorcado();
        }

        [Test]
        public void TestArriesgaPalabraCorrecta()
        {
            Assert.IsTrue(ahorcado.ArriesgaPalabra("palabra"));
        }

        [Test]
        public void TestArriesgaPalabraIncorrecta()
        {
            Assert.IsFalse(ahorcado.ArriesgaPalabra("asdasda"));
        }

        [Test]
        public void TestMostrarResultadoGanasteCorrecto()
        {
            ahorcado.ArriesgaPalabra("palabra");
            Assert.AreEqual("Ganaste!", ahorcado.MostrarEstadoJuego());
        }

        [Test]
        public void TestMostrarResultadoGanasteIncorrecto()
        {
            ahorcado.ArriesgaPalabra("asdasd");
            Assert.AreNotEqual("Ganaste!", ahorcado.MostrarEstadoJuego());
        }

        [Test]
        public void TestMostrarResultadoPerdisteCorrecto()
        {
            ahorcado.ArriesgaPalabra("asdasd");
            Assert.AreEqual("Perdiste!", ahorcado.MostrarEstadoJuego());
        }

        [Test]
        public void TestMostrarResultadoPerdisteIncorrecto()
        {
            ahorcado.ArriesgaPalabra("palabra");
            Assert.AreNotEqual("Perdiste!", ahorcado.MostrarEstadoJuego());
        }
    }
}