using Biblioteca_CLI.Models;
using Biblioteca_CLI.Repositories.Base;

namespace Biblioteca_CLI.Repositories;

public class RepoEmrpestimo : BaseRepository<Emprestimo>
{
    protected override void SetId( Emprestimo e, int id ) => e.Id = id;
    protected override int GetId( Emprestimo e)

    public List<Emprestimo> ObterAtrasados()
    {
        return _dados.Where( e => e.DataDevolucao == null && DateTime.Now > e.PrevDevolucao ).ToList()
    }
}