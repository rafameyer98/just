using Just.Models;
namespace Just.Models
{
public class Conteudo
{
    public int ID { get; set; } =5555;
    public string Titulo { get; set; } ="POP";
    public string Tipo { get; set; } ="Musica";
    public string? Descricao { get; set; }
    
    public string? Url { get; set; }
     public int CriadorId { get; set; } =6665;// Música, Vídeo, etc.
    public Criador? Criador { get; set; }
}}