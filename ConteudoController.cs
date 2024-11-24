// Controllers/ConteudoController.cs
using Microsoft.AspNetCore.Mvc;
using Just.Data;
using Just.Models;
using System.Linq;

namespace Just.Controllers
{
    public class ConteudoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConteudoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var conteudos = _context.Conteudos.ToList();
            return View(conteudos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Conteudo conteudo)
        {
            if (ModelState.IsValid)
            {
                _context.Conteudos.Add(conteudo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(conteudo);
        }

        public IActionResult Edit(int id)
        {
            var conteudo = _context.Conteudos.Find(id);
            return View(conteudo);
        }

        [HttpPost]
        public IActionResult Edit(Conteudo conteudo)
        {
            if (ModelState.IsValid)
            {
                _context.Conteudos.Update(conteudo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(conteudo);
        }
public IActionResult Delete(int id)
{
    var conteudo = _context.Conteudos.Find(id);
    if (conteudo == null)
    {
        return NotFound();
    }
    
    _context.Conteudos.Remove(conteudo);
    _context.SaveChanges();
    return RedirectToAction(nameof(Index));
}

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var conteudo = _context.Conteudos.Find(id);
            _context.Conteudos.Remove(conteudo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}