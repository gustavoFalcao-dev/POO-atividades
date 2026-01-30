using System;
using Biblioteca_CLI.Models;
using Biblioteca_CLI.Repositories;
using Biblioteca_CLI.Services;

class Program
{
    static void Main()
    {
        var livroRepo = new RepoLivro();
        var clienteRepo = new RepoCliente();
        var emprestimoRepo = new RepoEmprestimo();
        var biblioteca = new ServiceBiblioteca(livroRepo, clienteRepo, emprestimoRepo);

        livroRepo.Adicionar( new Livro
        {
            Titulo = "Uma Breve Historia do Tempo",
            Autor = "Stephen Hawking",
            ISBN = "9788580576467"
        });

        clienteRepo.Adicionar( new Cliente
        {
            Nome = "Cefras Madu",
            CPF = "12345678900"
        });

        bool rodaPf = true;
        while ( rodaPf )
        {
            Console.WriteLine("\n========= Biblioteca CLI =========")
            Console.WriteLine("\n========= 1 - Emprestar Livro =========")
            Console.WriteLine("\n========= 2 - Devolver Livro =========")
            Console.WriteLine("\n========= 3 - Mostrar Atrasados =========")
            Console.WriteLine("\n========= 4 - Listar Livros =========")
            Console.WriteLine("\n========= 5 - Listar Clientes =========")
            Console.WriteLine("\n========= 0 - Sair =========")
            Console.WriteLine("\nEscolha uma opcao")

            string ans = Console.ReadLine();

            switch ( ans )
            {
                case "1":

                Console.Write("ID do livro: ");
                int idLivro = int.Parse( Console.ReadLine());
                Console.Write("ID do cliente: ");
                int idCliente = int.Parse( Console.ReadLine());
                
                try
                {
                    biblioteca.EmprestarLivro( idLivro, idCliente );
                    Console.WriteLine("Livro emprestado com sucesso.");
                }

                catch(Exception ex)
                {
                    Console.WriteLine( $"Erro:{ex.Message}" );
                }
                break;

                case "2":

                Console.Write( "ID do emprestimo: " );
                int idEmprestimo = int.Parse( Console.ReadLine());

                try
                {
                    biblioteca.DevolverLivro( idLivro );
                    Console.WriteLine( "Livro devolvido com sucesso." );
                }

                catch(Exception ex)
                {
                    Console.WriteLine( $"Error:{ex.Message}" );
                }
                break;

                case "3":

                Console.WriteLine( "============ Livros atrasados ============" );
                relatorio.MostrarAtrasados();
                break;

                case "4":

                Console.WriteLine( "============ Livros disponiveis ============" );
                foreach( var l in livroRepo.ObterTodos() )
                {
                    console.WriteLine( $"{l.Id} - {l.Titulo} ({l.Autor}) - Disponivel: {l.Disponivel}" );
                }
                break;

                case "5":

                console.WriteLine( "\n ============ Clientes ============" );
                foreach( var c in clienteRepo.ObterTodos() )
                {
                    console.WriteLine( $"{c.Id} - {c.Nome}" );
                }
                break;

                case "0":

                rodaPf = false;
                console.WriteLine( "Saindo..." );
                break;

                default:

                console.WriteLine( "Opcao invalida!" );
                break;
            }
        }
    }
}