// Controllers/CriadorController.cs
using Microsoft.AspNetCore.Mvc;
using Just.Data;
using Just.Models;
using System.Linq;

namespace Just.Controllers
{
    public class CriadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CriadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var criadores = _context.Criadores.ToList();
            return View(criadores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Criador criador)
        {
            if (ModelState.IsValid)
            {
                _context.Criadores.Add(criador);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(criador);
        }
        
        public IActionResult delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult delete(Criador criador)
        {
            if (ModelState.IsValid)
            {
                _context.Criadores.Add(criador);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(criador);
        }

        public IActionResult Edit(int id)
        {
            var criador = _context.Criadores.Find(id);
            return View(criador);
        }

        [HttpPost]
        public IActionResult Edit(Criador criador)
        {
            if (ModelState.IsValid)
            {
                _context.Criadores.Update(criador);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(criador);
        }
/*
       public IActionResult Delete(int id)
{
    var criador = _context.Criadores.Find(id);
    if (criador == null)
    {
        return NotFound(); // Retorna 404 se o criador não for encontrado
    }
    
    _context.Criadores.Remove(criador); // Remove o criador
    _context.SaveChanges(); // Salva as alterações no banco de dados
    return RedirectToAction(nameof(Index)); // Redireciona para a lista de criadores
}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var criador = _context.Criadores.Find(id);
            _context.Criadores.Remove(criador);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }*/
    }
}