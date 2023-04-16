using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Projeto.Entities;

namespace Projeto.Repository.Mappings
{
    public class EditoraMap : EntityTypeConfiguration<Editora>
    {
        public EditoraMap()
        {
            ToTable("Editora");

            HasKey(editora => editora.IdEditora);

            Property(editora => editora.IdEditora)
                .HasColumnName("IdEditora")
                .IsRequired();

            Property(editora => editora.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
