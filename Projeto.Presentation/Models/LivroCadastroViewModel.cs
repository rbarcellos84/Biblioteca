using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class LivroCadastroViewModel
    {
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe o título do livro.")]
        public string Titulo { get; set; }

        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe o gênero do livro.")]
        public string Genero { get; set; }

        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(250, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe o resumo do livro.")]
        public string Resumo { get; set; }

        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(500, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a foto do livro.")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "Selecione o autor do livro")]
        public int IdAutor { get; set; }

        [Required(ErrorMessage = "Selecione a editora do livro")]
        public int IdEditora { get; set; }
    }
}