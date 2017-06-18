using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EstruturasDeDados
{
    [TestFixture]
    public class ProgramTest
    {
        [Test]
        public void TestarMetodoCreate()
        {
            Pessoa a = new Pessoa("Renan", 100, 1);
            Assert.AreEqual(a.Nome, "Renan");
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
            Assert.AreEqual(1100m, a.Salario);
        }

        [Test]
        public void TestDicionarioEstruturaObjeto()
        {
            Program prog = new Program();
            prog.listaPessoa = new List<Pessoa>()
            {
                new Pessoa()
                {
                    Id = 1,
                    IdOrgao = 1,
                    Nome = "Fulano 1",
                    Salario = 1000m
                },
                new Pessoa()
                {
                    Id = 2,
                    IdOrgao = 2,
                    Nome = "Fulano 2",
                    Salario = 2000m
                },
                new Pessoa()
                {
                    Id = 3,
                    IdOrgao = 3,
                    Nome = "Fulano 3",
                    Salario = 3000m
                }
            };

            prog.listaIds = new List<int>() { 1, 3 };

            var result = prog.DicionarioEstruturaObjeto();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Nome, "Fulano 1");
            Assert.AreEqual(result[1].Nome, "Fulano 3");
        }


    }
}
