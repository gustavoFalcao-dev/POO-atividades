namespace Biblioteca_CLI.Models;

public class Emrpestimo
{
    public int Id { get; set; }
    public Livro Livro { get; set;}
    public Cliente Cliente { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime PrevDevolucao { get; set; }
    public DateTime? DataDevolucao { get; set; }
    public decimal Multa { get; set; }
}