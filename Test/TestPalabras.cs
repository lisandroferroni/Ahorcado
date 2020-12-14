using NUnit.Framework;
using Ahorcado;
using System.Linq;
using Ahorcado.Util;

namespace Test
{
    public class TestPalabras
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetPalabraAleatoria()
        {
            var palabraAleatoria = Palabras.GetPalabraAleatoria();
            Assert.IsNotNull(palabraAleatoria);
        }
    }
}