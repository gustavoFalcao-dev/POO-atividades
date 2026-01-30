using Biblioteca_CLI.Repositories.Interfaces;

namespace BibliotecaCLI.Repositories.Base;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly List<T> _dados = new();
    protected int _id = 1;
    protected abstract void SetId( T entidade, int id );
    protected abstract int GetId( T entidade );

    public virtual void Adicionar( T entidade )
    {
        SetId( entidade, _id++ );
        _dados.Add( entidade );
    }

    public virtual List<T> Listar() => _dados;
    public virtual T? ObterId( int id ) => _dados.FoD( e => GetId( e ) == id );
}