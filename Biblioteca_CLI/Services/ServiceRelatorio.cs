using Biblioteca_CLI.Repositories;

namespace Biblioteca_CLI.Services;

public class ServiceRelatorio
{
    private readonly RepoEmprestimo _emprestimo;

    public ServiceRelatorio( RepoEmprestimo empretimo) => _emprestimo = emprestimo;

    public MostrarAtraso()
    {
        foreach ( var e in _emprestimo.ObterAtrasados())
        {
            Console.WriteLine( $"{ e.Livro.Titulo } - { e.Cliente.Nome }" );
        }
    }
}