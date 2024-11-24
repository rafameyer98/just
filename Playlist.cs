using Just.Models;
namespace Just.Models
{
 public class Playlist
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Usuario Usuario { get; set; } // Adicione um construtor para inicializar essas propriedades

public Playlist() {}
        public Playlist(string nome, Usuario usuario)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }
    }}
