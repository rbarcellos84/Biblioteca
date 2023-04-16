using Projeto.Entities;
using Projeto.Presentation.Models;
using Projeto.Repository.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Presentation.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Livro/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        //JsonResult -> Receber chamadas AJAX (JavaScript)
        public JsonResult CadastrarLivro(LivroCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Livro livro = new Livro();
                    livro.Titulo = model.Titulo;
                    livro.Genero = model.Genero;
                    livro.Resumo = model.Resumo;
                    livro.Foto = model.Foto;
                    livro.IdAutor = model.IdAutor;
                    livro.IdEditora = model.IdEditora;
                    LivroRepository livroRepository = new LivroRepository();
                    livroRepository.Insert(livro);
                    return Json($"Livro {livro.Titulo}, cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    return Json(e.Message);
                }
            }
            else
            {
                //criar uma rotina para retornar as mensagens de erro de
                //validação para cada campo da classe viewModel
                Hashtable erros = new Hashtable();

                //varrer o objeto ModelState..
                foreach (var state in ModelState)
                {
                    //verificar se o elemento contem erro..
                    if (state.Value.Errors.Count > 0)
                    {
                        //adicionar o erro dentro do HashTable
                        erros[state.Key] = state.Value.Errors.Select(e => e.ErrorMessage).First();
                    }
                }

                //retonar erros de validação.. STATUS 400
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json(erros);
            }
        }

        //método para retornar a consulta de livros para o Angular..
        public JsonResult ConsultarLivros()
        {
            try
            {
                List<LivroConsultaViewModel> lista = new List<LivroConsultaViewModel>();
                LivroRepository livroRepository = new LivroRepository();
                foreach (Livro livro in livroRepository.FindAll())
                {
                    LivroConsultaViewModel model = new LivroConsultaViewModel();
                    model.IdLivro = livro.IdLivro;
                    model.Titulo = livro.Titulo;
                    model.Genero = livro.Genero;
                    model.Resumo = livro.Resumo;
                    model.Foto = livro.Foto;
                    model.IdAutor = livro.IdAutor;
                    model.IdEditora = livro.IdEditora;
                    lista.Add(model); //adicionando na lista..
                }

                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //método para retornar 1 Livro pelo id..
        public JsonResult ObterLivro(int idLivro)
        {
            try
            {
                LivroRepository livroRepository = new LivroRepository();
                Livro livro = livroRepository.FindById(idLivro);
                LivroConsultaViewModel model = new LivroConsultaViewModel();
                model.IdLivro = livro.IdLivro;
                model.Titulo = livro.Titulo;
                model.Genero = livro.Genero;
                model.Resumo = livro.Resumo;
                model.Foto = livro.Foto;
                model.IdAutor = livro.IdAutor;
                model.IdEditora = livro.IdEditora;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //método para excluir uma livro..
        public JsonResult ExcluirLivro(int idLivro)
        {
            try
            {
                LivroRepository livroRepository = new LivroRepository();
                Livro livro = livroRepository.FindById(idLivro);
                livroRepository.Delete(livro);
                return Json($"Livro {livro.Titulo}, excluído com sucesso.",JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //método para atualizar livro..
        public JsonResult AtualizarLivro(LivroEdicaoViewModel model)
        {
            try
            {
                Livro livro = new Livro();
                livro.IdLivro = model.IdLivro;
                livro.Titulo = model.Titulo;
                livro.Genero = model.Genero;
                livro.Resumo = model.Resumo;
                livro.Foto = model.Foto;
                livro.IdAutor = model.IdAutor;
                livro.IdEditora = model.IdEditora;
                LivroRepository rep = new LivroRepository();
                rep.Update(livro);
                return Json($"Livro {livro.Titulo}, atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}