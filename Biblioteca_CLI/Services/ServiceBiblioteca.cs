using Biblioteca_CLI.Models;
using Biblioteca_CLI.Repositories;

namespace Biblioteca.Services;

public class ServiceBiblioteca
{
    private readonly RepoLivro _livro;
    private readonly RepoCliente _cliente;
    private readonly RepoEmprestimo _emprestimo;

    public ServiceBiblioteca( RepoLivro livro, RepoCliente cliente, RepoEmprestimo emprestimo )
    {
        _livro = livro;
        _cliente = cliente;
        _emprestimo = emprestimo;
    }

    public void EmprestarLivro( int livroId, int clienteId )
    {
        var livro = _livro.ObterId( livroId );
        var cliente = _cliente.ObterId( clienteID );
        
        if ( livro == null || cliente == null ) throw new Exception( "Livro ou cliente nao encontrado." );

        if ( !livro.Disponivel ) throw new Exception( "Livro indisponivel." );

        if ( !cliente.Regular ) throw new Exception( "Cliente irregular." );

        livro.Disponivel = false;

        _emprestimo.Adicionar( new Emprestimo
        {
            Livro = livro,
            Cliente = cliente,
            DataEmprestimo = DateTime.Now,
            PrevDevolucao = DateTime.Now.AddDays(7)
        });
    }

    public void DevolverLivro( int emprestimoId )
    {
        var emprestimo = _emprestimo.ObterId( emprestimoId );

        if ( emprestimo == null ) throw new Exception( "Emprestimo nao encontrado." );

        emprestimo.DataDevolucao = Datetime.Now;
        emprestimo.Livro.Disponivel = true;

        if ( emprestimo.DataDevolucao > emprestimo.PrevDevolucao )
        {
            var diass = ( emprestimo.DataDevolucao.Value - emprestimo.PrevDevolucao).Days;
            emprestimo.Multa = dias * 2m;
            emprestimo.Cliente.Regular = false;
        }
    }
}