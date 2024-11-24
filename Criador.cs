using Just.Models;
namespace Just.Models
{
    public class Criador
{
    public int ID { get; set; } =212356;
    public string Nome { get; set; } = "Rafaela Millas";
    public string Bio { get; set; } ="Musicas Criação";
    public List<Conteudo>? Conteudos { get; set; } = new List<Conteudo>();
    public string Email { get; set; }="rafaela@outlook.com";
}}