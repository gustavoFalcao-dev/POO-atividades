using Biblioteca_CLI.Repositories;

namespace Biblioteca_CLI.Services;

public class ServiceRelatorio
{
    private readonly RepoEmprestimo _emprestimo;

    public ServiceRelatorio( RepoEmprestimo empretimo) => _emprestimo = emprestimo;

    public MostrarAtrasados()
    {
        var atrasados = _emprestimo.ObterAtrasados().Select( e => new { e.Livro.Titulo, e.Cliente.Nome }).ToList();
        atrasados.foreach( e => Console.WriteLine( $"{e.Titulo} - {e.Nome}" ));
    }
}