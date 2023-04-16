using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Editora
    {
        //propriedades [prop] + 2x[tab]
        public int IdEditora { get; set; }
        public string Nome { get; set; }

        //relacionamento
        public List<Livro> Livros { get; set; }

        //construtor default [ctor] + 2x[tab]
        public Editora()
        {

        }

        //sobrecarga de construtor (overloading)
        public Editora(int idEditora, string nome)
        {
            IdEditora = idEditora;
            Nome = nome;
        }

        //sobrescrita do método ToString()
        public override string ToString()
        {
            return $"Id: {IdEditora}, Nome: {Nome}";
        }
    }
}
