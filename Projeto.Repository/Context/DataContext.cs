using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity;
using Projeto.Repository.Mappings;
using Projeto.Entities;

namespace Projeto.Repository.Context
{
    //Regra 1) Esta classe deverá HERDAR 'DbContext'
    public class DataContext : DbContext
    {
        //Regra 2) Criar um construtor que envie para a DbContext
        //o caminho da connectionstring do banco de dados
        public DataContext() 
            : base(ConfigurationManager.ConnectionStrings["BaseBiblioteca"].ConnectionString)
        {

        }

        //sobrescrita do método OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //método utilizado para incluir cada classe
            //mapeada (ORM) do projeto Repository..
            modelBuilder.Configurations.Add(new AutorMap());
            modelBuilder.Configurations.Add(new EditoraMap());
            modelBuilder.Configurations.Add(new LivroMap());
        }

        //declarar uma propriedade DbSet para cada classe de entidade..
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Editora> Editora { get; set; }
    }
}
