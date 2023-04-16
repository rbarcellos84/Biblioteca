using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Projeto.Entities;

namespace Projeto.Repository.Mappings
{
    public class LivroMap : EntityTypeConfiguration<Livro>
    {
        public LivroMap()
        {
            ToTable("Livro");

            HasKey(livro => livro.IdLivro);

            Property(livro => livro.IdLivro)
                .HasColumnName("IdLivro")
                .IsRequired();

            Property(livro => livro.Titulo)
                .HasColumnName("Titulo")
                .HasMaxLength(100)
                .IsRequired();

            Property(livro => livro.Genero)
                .HasColumnName("Genero")
                .HasMaxLength(50)
                .IsRequired();

            Property(l => l.Resumo)
                .HasColumnName("Resumo")
                .HasMaxLength(250)
                .IsRequired();

            Property(livro => livro.Foto)
                .HasColumnName("Foto")
                .HasMaxLength(500)
                .IsRequired();

            Property(livro => livro.IdAutor)
                .HasColumnName("IdAutor")
                .IsRequired();

            Property(livro => livro.IdEditora)
                .HasColumnName("IdEditora")
                .IsRequired();

            //Mapear a chave estrangeira com a 
            //tabela de Autor..
            HasRequired(livro => livro.Autor) //Livro TEM 1 Autor
                .WithMany(autor => autor.Livros) //Autor TEM Muitos Livros
                .HasForeignKey(livro => livro.IdAutor) //Chave estrangeira
                .WillCascadeOnDelete(false);

            //Mapear a chave estrangeira com a 
            //tabela de Editora..
            HasRequired(livro => livro.Editora)
                .WithMany(editora => editora.Livros)
                .HasForeignKey(livro => livro.IdEditora)
                .WillCascadeOnDelete(false);
        }
    }
}
