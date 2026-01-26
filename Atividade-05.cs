using System;
using System.Collections.Generic;

namespace Atv05
{
    public class AcessoNegadoException : Exception
    {
        public AcessoNegadoException( string msg ) : base( msg ) {}
    }

    public class SistemaAuth
    {
        private Dictionary< string, string > bancoDeDados = new Dictionary< string, string >();

        public SistemaAuth()
        {
            bancoDeDados.Add("admin", "admin");
            bancoDeDados.Add("Aluno", "gAluno123");
            bancoDeDados.Add("Professor","gProf456");
        }

        public void FazerLogin( string usuario, string senha )
        {
            if (!bancoDeDados.ContainsKey(usuario))
            {
                throw new AcessoNegadoException("Usuario nao cadastrado.");
            }

            if (bancoDeDados[usuario] != senha)
            {
                throw new AcessoNegadoException("Senha Invalida!");
            }

            Console.WriteLine($"[Sucesso] Bem-vindo, {usuario}!");
        }
    }

    class Program
    {
        static void Main()
        {
            SistemaAuth sistema = new SistemaAuth();

            Console.WriteLine("----- Tentativa 1 (Correta) -----");
            try
            {
                sistema.FazerLogin("admin","admin");
            }
            
            catch (Exception ex) { Console.WriteLine("Erro: " + ex.Message); }

            Console.WriteLine("----- Tentativa 2 (Senha errada) -----");
            try
            {
                sistema.FazerLogin("Aluno","errada");
            }
            
            catch (AcessoNegadoException ex)
            {
                Console.WriteLine($"[Alerta de seguranca] { ex.Message }");
            }

            Console.WriteLine("----- Tentativa 3 (Usuario inexistente) -----");
            try
            {
                sistema.FazerLogin("Edvaldo","Aluno@grautec");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"[Erro] { ex.Message }");
            }

            finally
            {
                Console.WriteLine("\nProcesso de validacao finalizado.");
            }

            Console.ReadKey();
        }
    }
}