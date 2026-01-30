using Biblioteca_CLI.Models;
using Biblioteca_CLI.Repositories;
using Biblioteca_CLI.Services;

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

biblioteca.EmprestarLivro( 1, 1 );

Console.WriteLine("MZR DA CERTO PELO AMOR DE ZEUS")