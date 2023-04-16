using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Autor
    {
        //propriedades [prop] + 2x[tab]
        public int IdAutor { get; set; }
        public string Nome { get; set; }

        //relacionamento
        public List<Livro> Livros { get; set; }

        //construtor [ctor] + 2x[tab]
        public Autor()
        {

        }

        //sobrecarga de construtores (overloading)
        public Autor(int idAutor, string nome)
        {
            IdAutor = idAutor;
            Nome = nome;
        }

        //sobrescrita do método ToString()
        public override string ToString()
        {
            return $"Id: {IdAutor}, Nome: {Nome}";
        }
    }
}
