using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class LivroEdicaoViewModel
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Resumo { get; set; }
        public string Foto { get; set; }
        public int IdAutor { get; set; }
        public int IdEditora { get; set; }
    }
}