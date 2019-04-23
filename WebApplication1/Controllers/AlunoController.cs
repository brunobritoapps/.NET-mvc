using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectDotNet.Aplication;
using ProjectDotNet.Domain;

namespace ProjectDotNet.Ui.Web.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            var appAluno = new AlunoAplicacao();
            return View(appAluno.SelectAll());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var appAluno = new AlunoAplicacao();
                appAluno.Save(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }
        //SHOW
        public ActionResult Edit(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.SelectById(id);
            if(aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var appAluno = new AlunoAplicacao();
                appAluno.Save(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        public ActionResult Details(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.SelectById(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        public ActionResult Delete(int id)
        {
            var appAluno = new AlunoAplicacao();
            var aluno = appAluno.SelectById(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var appAluno = new AlunoAplicacao();
            appAluno.Delete(id);
            return RedirectToAction("Index");
        }
    }
}