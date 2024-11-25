using Just.Data;
using Just.Models;
using System.Collections.Generic;
using System.Linq;

namespace Just.Repository
{
    public class PlaylistRepository
    {
        private readonly ApplicationDbContext _context;

        public PlaylistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public List<Playlist> GetAllPlaylists()
        {
            return _context.Playlists.ToList();
        }

        
        public void AddPlaylist(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            _context.SaveChanges();
        }

        public Playlist GetPlaylistByID(int id)
        {
            return _context.Playlists.Find(id);
        }

       
        public void UpdatePlaylist(Playlist playlist)
        {
            _context.Playlists.Update(playlist);
            _context.SaveChanges();
        }

        
        public void DeletePlaylist(int id)
        {
            var playlist = _context.Playlists.Find(id);
            if (playlist != null)
            {
                _context.Playlists.Remove(playlist);
                _context.SaveChanges();
            }
        }
    }
}