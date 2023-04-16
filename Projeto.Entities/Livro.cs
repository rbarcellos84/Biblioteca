using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Livro
    {
        //propriedades da classe [prop] + 2x[tab]
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Resumo { get; set; }
        public string Foto { get; set; }

        //chaves estrangeiras
        public int IdAutor { get; set; }
        public int IdEditora { get; set; }

        //relacionamentos
        public Autor Autor { get; set; }
        public Editora Editora { get; set; }

        //construtor default [ctor] + 2x[tab]
        public Livro()
        {

        }

        //sobrecarga de construtores (overloading)
        public Livro(int idLivro, string titulo, string genero, string resumo, string foto)
        {
            IdLivro = idLivro;
            Titulo = titulo;
            Genero = genero;
            Resumo = resumo;
            Foto = foto;
        }

        //sobrescrita do método ToString()
        public override string ToString()
        {
            return $"Id: {IdLivro} Título: {Titulo}, Genero: {Genero}, Resumo: {Resumo}";
        }
    }
}
