namespace Biblioteca_CLI.Models;

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public string Editora { get; set; }
    public int AnoPub { get; set; }
    public bool Disponivel { get; set; } = true;
}
