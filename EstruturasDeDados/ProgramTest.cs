using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturasDeDados
{
    [TestFixture]
    public class ProgramTest
    {

        [Test]
        public void TestarMetodoCreate()
        {

            Pessoa a = new Pessoa();
            Assert.AreEqual(a.Nome, "Roda Azul");
        }

        [Test]
        public void TestCalculoDissidio()
        {
            Pessoa a = new Pessoa()
            {
                Id = 1,
                Nome = "Renan",
                Salario = 1000
            };

            a.CalcularDissidio();

            Assert.AreEqual(a.Nome, "Renan");
            Assert.AreEqual(1100f, a.Salario);
        }


    }
}
