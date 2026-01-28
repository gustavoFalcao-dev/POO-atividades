//TODO - CadCliente; CadLivro; Busca; Histórico; Registro; CalcMulta; Relatório

namespace System
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        
        public CadCliente( string Rnome, string Rcpf, string Remail, string Rendereco, string Rtelefone )
        {
            this.Nome = Rnome;
            this.CPF = Rcpf;
            this.Email = Remail;
            this.Endereco = Rendereco;
            this.Telefone = Rtelefone;
        }
    }
}