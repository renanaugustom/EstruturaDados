using System;
using System.Collections.Generic;
using System.Linq;

namespace EstruturasDeDados
{
    public class Program
    {
        private const int qtdRegistros = 300000;

        public const int qtdIds = 10000;

        private const int posicaoGeracaoLista = qtdRegistros - qtdIds;

        public List<Pessoa> listaPessoa { get; set; }
        public List<int> listaIds { get; set; }
        public List<int> listaInteirosSimples { get; set; }


        private List<Pessoa> PreencherListaPessoas()
        {
            List<Pessoa> listaPessoa = new List<Pessoa>();

            for (int i = 0; i < qtdRegistros; i++)
            {
                listaPessoa.Add(new Pessoa()
                {
                    Id = i,
                    IdOrgao = i,
                    Nome = "Fulano " + i,
                });
            }

            return listaPessoa;
        }

        private void CalculaTempo(string acao, Func<int> metodo)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var result = metodo();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine(acao + ": \n  " +
                "QTD Registros: " + result + " \n" +
                "Tempo: " + elapsedMs + " ms \n");
        }

        private int ContainsEstruturaSimples()
        {
            return listaInteirosSimples.Where(x => listaIds.Contains(x)).Count();
        }

        private int DicionarioEstruturaSimples()
        {
            var dict = listaInteirosSimples.ToDictionary(x => x, x => x);
            return listaIds.Select(x => dict[x]).Count();
        }

        private int ContainsEstruturaObjeto()
        {
            return listaPessoa.Where(x => listaIds.Contains(x.Id)).Count();
        }

        private int DicionarioEstruturaObjeto()
        {
            var dictPessoa = listaPessoa.GroupBy(x => x.Id).ToDictionary(g => g.Key, g => g.FirstOrDefault());
            return listaIds.Select(x => dictPessoa[x]).Select(x => x).Count();
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.listaPessoa = prog.PreencherListaPessoas();
            prog.listaIds = Enumerable.Range(posicaoGeracaoLista, qtdIds).ToList();
            prog.listaInteirosSimples = Enumerable.Range(0, qtdRegistros).ToList();

            prog.CalculaTempo("Contains (Estrutura simples)", prog.ContainsEstruturaSimples);
            prog.CalculaTempo("Dicionario (Estrutura simples)", prog.DicionarioEstruturaSimples);
            prog.CalculaTempo("Contains (Estrutura Objeto)", prog.ContainsEstruturaObjeto);
            prog.CalculaTempo("Dicionario (Estrutura Objeto)", prog.DicionarioEstruturaObjeto);

            Console.ReadLine();
        }
    }

    

    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Salario { get; set; }
        public int IdOrgao { get; set; }

        public void CalcularDissidio()
        {
            Salario = Salario + (Salario * 0.1f);
        }
    }
}
