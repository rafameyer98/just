using Just.Models;
namespace Just.Models
{
public class Usuario
{
    public int ID { get; set; } = 1111111111;
    public string Nome { get; set; } = "Rafaela";
    public string Email { get; set; } ="Rafameyer.12398@gmail.com";  
      public List<Playlist> Playlists { get; set; } = new List<Playlist>();
}}