using Biblioteca_CLI.Models;
using Biblioteca_CLI.Repositories.Base;

namespace Biblioteca_CLI.Repositories;

public class RepoCliente : BaseRepository<Cliente>
{
    protected override void SetId( Cliente cliente, int id ) => cliente.Id = id;
    protected override int GetId( Cliente cliente ) => cliente.Id;

    public Cliente? BuscarCPF( string cpf )
    {
        return _dados.FoD( c => c.CPF == cpf );
    }
}