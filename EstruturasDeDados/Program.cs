using System;
using System.Collections.Generic;
using System.Linq;

namespace EstruturasDeDados
{
    public class Program
    {
        private const int qtdRegistros = 300000;
        private const int qtdIds = 10000;
        private const int posicaoGeracaoListaIds = 0; //qtdRegistros - qtdIds;

        public List<Pessoa> listaPessoa { get; set; }
        public List<int> listaIds { get; set; }

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

        private void CalculaTempo(string acao, Func<List<Pessoa>> metodo)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var result = metodo();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine(acao + ": \n  " +
                "QTD Registros: " + result.Count + " \n" +
                "Tempo: " + elapsedMs + " ms \n");
        }

        public List<Pessoa> ContainsEstruturaObjeto()
        {
            return listaPessoa.Where(x => listaIds.Contains(x.Id)).ToList();
        }

        public List<Pessoa> DicionarioEstruturaObjeto()
        {
            var dictPessoa = listaPessoa.ToDictionary(g => g.Id, g => g);
            return listaIds.Select(x => dictPessoa[x]).ToList();
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.listaPessoa = prog.PreencherListaPessoas();
            prog.listaIds = Enumerable.Range(posicaoGeracaoListaIds, qtdIds).ToList();

            prog.CalculaTempo("Contains (Estrutura Objeto)", prog.ContainsEstruturaObjeto);
            prog.CalculaTempo("Dicionario (Estrutura Objeto)", prog.DicionarioEstruturaObjeto);

            Console.ReadLine();
        }
    }
}