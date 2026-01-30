namespace Biblioteca_CLI.Repositories.Interfaces;

public interface IRepository<T>
{
    void Adicionar( T entidade );
    List<T> Listar();
    T? ObterId( int id );
}