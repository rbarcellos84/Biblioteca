using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Projeto.Repository.Context;

namespace Projeto.Repository.Generics
{
    //<T> Tipo generico
    public class GenericRepository<T>
        where T : class        
    {
        //método para inserir um registro na base..
        public virtual void Insert(T obj)
        {
            //acessar o banco de dados com o EntityFramework
            using (DataContext dataContext = new DataContext())
            {
                dataContext.Entry(obj).State = EntityState.Added;
                dataContext.SaveChanges();
            }
        }

        //método para atualizar um registro na base..
        public virtual void Update(T obj)
        {
            //acessar o banco de dados com o EntityFramework
            using (DataContext dataContext = new DataContext())
            {
                dataContext.Entry(obj).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        //método para excluir um registro na base..
        public virtual void Delete(T obj)
        {
            //acessar o banco de dados com o EntityFramework
            using (DataContext dataContext = new DataContext())
            {
                dataContext.Entry(obj).State = EntityState.Deleted;
                dataContext.SaveChanges();
            }
        }

        //método para retornar todos os registros..
        public virtual List<T> FindAll()
        {
            //acessar o banco de dados com o EntityFramework
            using (DataContext dataContext = new DataContext())
            {
                return dataContext.Set<T>().ToList();
            }
        }

        //método para retornar 1 registro pelo id..
        public virtual T FindById(int id)
        {
            //acessar o banco de dados com o EntityFramework
            using (DataContext dataContext = new DataContext())
            {
                return dataContext.Set<T>().Find(id);
            }
        }
    }
}
