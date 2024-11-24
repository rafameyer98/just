// Controllers/PlaylistController.cs
using Microsoft.AspNetCore.Mvc;
using Just.Data;
using Just.Models;
using System.Linq;
using Just.Repository;

namespace Just.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaylistController(ApplicationDbContext context)
        {
            _context = context;
        }

       /* public IActionResult Index()
        {
            ViewBag.Message = "Bem-vindo à sua lista de playlists!";
            var playlists = _context.Playlists.ToList();
            return View(playlists);
        }*/
      public IActionResult Inicio()
{
    List<Playlist> playlists = _playlistRepository.GetAllPlaylists();
    ViewBag.Playlists = playlists;
    return View();
}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Playlists.Add(playlist);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        public IActionResult Edit(int id)
        {
            var playlist = _context.Playlists.Find(id);
            return View(playlist);
        }

        [HttpPost]
        public IActionResult Edit(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Playlists.Update(playlist);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

     public IActionResult Delete(int id)
{
    var playlist = _context.Playlists.Find(id);
    if (playlist == null)
    {
        return NotFound(); // Retorna 404 se a playlist não for encontrada
    }
    
    _context.Playlists.Remove(playlist); // Remove a playlist
    _context.SaveChanges(); // Salva as alterações no banco de dados
    return RedirectToAction(nameof(Index)); // Redireciona para a lista de playlists
}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var playlist = _context.Playlists.Find(id);
            _context.Playlists.Remove(playlist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    
      [HttpGet]
        public IActionResult GetPlaylists()
        {
            var playlists = _context.Playlists.ToList();
            return Json(playlists);
        }

       private readonly PlaylistRepository _playlistRepository;

    public PlaylistController(PlaylistRepository playlistRepository)
    {
        _playlistRepository = playlistRepository;
    }
    }
    }
    


/*  Controllers/PlaylistController.cs
using Microsoft.AspNetCore.Mvc;
using Just.Data;
using Just.Models;
using System.Linq;

namespace MeuSiteStreaming.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaylistController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var playlists = _context.Playlists.ToList();
            return View(playlists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Playlists.Add(playlist);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        public IActionResult Edit(int id)
        {
            var playlist = _context.Playlists.Find(id);
            return View(playlist);
        }

        [HttpPost]
        public IActionResult Edit(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Playlists.Update(playlist);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

     public IActionResult Delete(int id)
{
    var playlist = _context.Playlists.Find(id);
    if (playlist == null)
    {
        return NotFound(); // Retorna 404 se a playlist não for encontrada
    }
    
    _context.Playlists.Remove(playlist); // Remove a playlist
    _context.SaveChanges(); // Salva as alterações no banco de dados
    return RedirectToAction(nameof(Index)); // Redireciona para a lista de playlists
}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var playlist = _context.Playlists.Find(id);
            _context.Playlists.Remove(playlist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}*/