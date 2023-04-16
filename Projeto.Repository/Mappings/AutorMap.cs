using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration; //mapeamento
using Projeto.Entities; //entidades

namespace Projeto.Repository.Mappings
{
    //Classe de mapeamento para a entidade Autor
    public class AutorMap : EntityTypeConfiguration<Autor>
    {
        //construtor [ctor] + 2x[tab]
        public AutorMap()
        {
            //nome da tabela..
            ToTable("Autor");

            //chave primária..
            HasKey(autor => autor.IdAutor);

            //mapear os demais campos da tabela
            Property(autor => autor.IdAutor)
                .HasColumnName("IdAutor")
                .IsRequired();

            Property(autor => autor.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
