using Biblioteca_CLI.Models;
using Biblioteca_CLI.Repositories.Base;

namespace Biblioteca_CLI.Repositories;

public class RepoLivro : BaseRepository<Livro>
{
    protected override void SetId( Livro livro, int id ) => livro.Id = id;
    protected override int GetId( Livro livro ) => livro.Id;

    public List<Livro> BuscarAutor( string autor )
    {
        return _dados.Where( l => l.Autor.Contains( autor, StringComparison.OrdinalIgnoreCase )).ToList();
    }
}