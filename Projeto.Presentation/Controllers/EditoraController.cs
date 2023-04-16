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
    public class EditoraController : Controller
    {
        // GET: Editora/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Editora/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        //JsonResult -> Receber chamadas AJAX (JavaScript)
        public JsonResult CadastrarEditora(EditoraCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Editora editora = new Editora();
                    editora.Nome = model.Nome;

                    EditoraRepository editoraRepository = new EditoraRepository();
                    editoraRepository.Insert(editora);

                    return Json($"Editora {editora.Nome}, cadastrado com sucesso.");
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
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(erros);
            }
        }

        //método para retornar a consulta de editoras para o Angular..
        public JsonResult ConsultarEditoras()
        {
            try
            {
                List<EditoraConsultaViewModel> lista = new List<EditoraConsultaViewModel>();
                EditoraRepository editoraRepository = new EditoraRepository();
                foreach (Editora editora in editoraRepository.FindAll())
                {
                    EditoraConsultaViewModel model = new EditoraConsultaViewModel();
                    model.IdEditora = editora.IdEditora;
                    model.Nome = editora.Nome;
                    lista.Add(model);
                }

                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //método para retornar 1 Editora pelo id..
        public JsonResult ObterEditora(int idEditora)
        {
            try
            {
                EditoraRepository editoraRepository = new EditoraRepository();
                Editora editora = editoraRepository.FindById(idEditora);
                EditoraConsultaViewModel model = new EditoraConsultaViewModel();
                model.IdEditora = editora.IdEditora;
                model.Nome = editora.Nome;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //método para excluir uma editora..
        public JsonResult ExcluirEditora(int idEditora)
        {
            try
            {
                EditoraRepository editoraRepository = new EditoraRepository();
                Editora editora = editoraRepository.FindById(idEditora);
                editoraRepository.Delete(editora);
                return Json($"Editora {editora.Nome}, excluído com sucesso.",JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //método para atualizar editora..
        public JsonResult AtualizarEditora(EditoraEdicaoViewModel model)
        {
            try
            {
                Editora editora = new Editora();
                editora.IdEditora = model.IdEditora;
                editora.Nome = model.Nome;
                EditoraRepository editoraRepository = new EditoraRepository();
                editoraRepository.Update(editora);
                return Json($"Editora {editora.Nome}, atualizada com sucesso.");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}