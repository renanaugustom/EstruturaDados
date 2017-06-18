using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturasDeDados
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public int IdOrgao { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(string nome, decimal salario, int idOrgao)
        {
            Nome = nome;
            Salario = salario;
            IdOrgao = idOrgao;
        }

        public void CalcularDissidio()
        {
            Salario = Salario + (Salario * 0.1m);
        }
    }
}
