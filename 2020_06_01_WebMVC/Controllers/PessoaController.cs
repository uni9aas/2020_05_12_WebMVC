using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2020_05_12_WebMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2020_05_12_WebMVC.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        [HttpGet]
        public ActionResult Index()
        {
            PessoaModel pModel = new PessoaModel();
            return View(pModel.Listar());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pessoa/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new PessoaModel());
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(PessoaModel pModel)
        {
            pModel.Salvar();
            return RedirectToAction("Index");
        }

        // Recuperação do registro para edição:
        // GET: Pessoa/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PessoaModel pModel = new PessoaModel();
            pModel.Editar(id);

            return View(pModel);
        }

        // Grava no BD o registro alterado:
        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PessoaModel pessoaModel)
        {
            pessoaModel.Atualizar();
            return RedirectToAction("Index");
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}