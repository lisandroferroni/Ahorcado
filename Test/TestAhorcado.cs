using NUnit.Framework;
using Ahorcado;
using System.Linq;

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

        [Test]
        public void TestArriesgarLetraCorrecta()
        {
            Assert.IsTrue(ahorcado.ArriesgaLetra('a'));
        }

        [Test]
        public void TestArriesgarLetraIncorrecta()
        {
            Assert.IsFalse(ahorcado.ArriesgaLetra('x'));
        }

        [Test]
        public void TestArriesgarLetrasCorectas()
        {
            ahorcado.ArriesgaLetra('p');
            ahorcado.ArriesgaLetra('a');
            ahorcado.ArriesgaLetra('b');
            Assert.IsTrue(ahorcado.ContieneLetraCorrecta('p'));
            Assert.IsTrue(ahorcado.ContieneLetraCorrecta('a'));
            Assert.IsTrue(ahorcado.ContieneLetraCorrecta('b'));
        }

        [Test]
        public void TestArriesgarLetrasIncorectas()
        {
            ahorcado.ArriesgaLetra('x');
            ahorcado.ArriesgaLetra('y');
            ahorcado.ArriesgaLetra('z');
            Assert.IsTrue(ahorcado.ContieneLetraIncorrecta('x'));
            Assert.IsTrue(ahorcado.ContieneLetraIncorrecta('y'));
            Assert.IsTrue(ahorcado.ContieneLetraIncorrecta('z'));
        }

        [Test]
        public void TestIngresarNombre()
        {
            var nombre = "Nombre";
            ahorcado.SetNombreUsuario(nombre);
            Assert.AreEqual(nombre, ahorcado.GetNombreUsuario());
        }

        [Test]
        public void TestGetNombreIncorrecto()
        {
            var nombre = "Nombre";
            ahorcado.SetNombreUsuario(nombre);
            Assert.AreNotEqual("asd", ahorcado.GetNombreUsuario());
        }
    }
}