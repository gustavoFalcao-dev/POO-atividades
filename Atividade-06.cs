using System;
using System.IO;

namespace Atv06
{
    public static class Logger
    {
        private static string arquivoLog = "sistema_log.txt";

        public static void RegistrarAcao(string acao)
        {
            using (StreamWriter sw = File.AppendText(arquivoLog))
            {
                sw.WriteLine($"{DateTime.Now} - {acao}");
            }

            Console.WriteLine("Log salvo no disco.");
        }
        public static void LerLogs()
        {
            Console.WriteLine("\n--- Lendo historico de logs ---");
            if (File.Exists(arquivoLog))
            {
                using (StreamReader sr = File.OpenText(arquivoLog))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(linha);
                    }
                }
            }
            
            else
            {
                Console.WriteLine("Nenhum log encontrado.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Logger.RegistrarAcao("Sistema inicializado.");
            Logger.RegistrarAcao("Usuario 'admin' logou.");
            Logger.RegistrarAcao("Erro de conexao simulado.");

            Logger.LerLogs();

            Console.WriteLine("\nVerifique a pasta do executavel para encontrar 'sistema_log.txt'");
            Console.ReadKey();
        }
    }
}