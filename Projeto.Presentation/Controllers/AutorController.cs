using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models;
using Projeto.Entities;
using Projeto.Repository.Persistence;
using System.Collections;
using System.Net;

namespace Projeto.Presentation.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Autor/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        //JsonResult -> Receber chamadas AJAX (JavaScript)
        public JsonResult CadastrarAutor(AutorCadastroViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Autor autor = new Autor();
                    autor.Nome = model.Nome;
                    AutorRepository autorRepository = new AutorRepository();
                    autorRepository.Insert(autor);
                    return Json($"Autor {autor.Nome}, cadastrado com sucesso.");
                }
                catch(Exception e)
                {
                    return Json(e.Message);
                }
            }
            else
            {
                Hashtable erros = new Hashtable();

                //varrer o objeto ModelState..
                foreach(var state in ModelState)
                {
                    //verificar se o elemento contem erro..
                    if(state.Value.Errors.Count > 0)
                    {
                        //adicionar o erro dentro do HashTable
                        erros[state.Key] = state.Value.Errors.Select(e => e.ErrorMessage).First();
                    }
                }

                //retonar erros de validação.. STATUS 400
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(erros);
            }
        }
        
        //método para retornar a consulta de autores para o Angular..
        public JsonResult ConsultarAutores()
        {
            try
            {
                List<AutorConsultaViewModel> lista = new List<AutorConsultaViewModel>();
                AutorRepository autorRepository = new AutorRepository();
                foreach(Autor autor in autorRepository.FindAll())
                {
                    AutorConsultaViewModel model = new AutorConsultaViewModel();
                    model.IdAutor = autor.IdAutor;
                    model.Nome = autor.Nome;
                    lista.Add(model);
                }
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //método para retornar 1 Autor pelo id..
        public JsonResult ObterAutor(int idAutor)
        {
            try
            {
                AutorRepository autorRepository = new AutorRepository();
                Autor autor = autorRepository.FindById(idAutor);
                AutorConsultaViewModel model = new AutorConsultaViewModel();
                model.IdAutor = autor.IdAutor;
                model.Nome = autor.Nome;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //método para excluir um autor..
        public JsonResult ExcluirAutor(int idAutor)
        {
            try
            {
                AutorRepository autorRepository = new AutorRepository();
                Autor autor = autorRepository.FindById(idAutor);
                autorRepository.Delete(autor);
                return Json($"Autor {autor.Nome}, excluído com sucesso.", JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //método para atualizar autor..
        public JsonResult AtualizarAutor(AutorEdicaoViewModel model)
        {
            try
            {
                Autor autor = new Autor();
                autor.IdAutor = model.IdAutor;
                autor.Nome = model.Nome;
                AutorRepository autorRepository = new AutorRepository();
                autorRepository.Update(autor);
                return Json($"Autor {autor.Nome}, atualizado com sucesso.");
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}