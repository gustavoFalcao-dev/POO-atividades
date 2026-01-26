using System;
using System.Threading;

namespace Atv07
{
    public static class Conversor
    {
        public static double CelsiusToFahrenheit(double c) => (c * 9 / 5 + 32);
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("------ App multi-tarefa ------");

            Thread tarefaFundo = new Thread(ProcessamentoPesado);
            tarefaFundo.Start();

            while(tarefaFundo.IsAlive)
            {
                Console.WriteLine("Digite uma temperatura em ºC (graus celsius) para converter ou 'sair':");
                string input = Console.ReadLine();

                if (input == "sair") break;

                if (double.TryParse(input, out double celsius))
                {
                    double fahrenheit = Conversor.CelsiusToFahrenheit(celsius);
                    Console.WriteLine($">>>{celsius}ºC = {fahrenheit}ºF");
                }

                else
                {
                    Console.WriteLine("Valor invalido.");
                }
            }

            Console.WriteLine("Programa finalizado.");
        }

        static void ProcessamentoPesado()
        {
            Console.WriteLine("[System] Iniciando backup em segundo plano...");
            for (int i = 0; i <= 100; i += 20)
            {
                Thread.Sleep(2000);
                Console.WriteLine($"\n[System] Progresso do backup: {i}% completo.");
                Console.WriteLine("Digite uma temperatura:");
            }

            Console.WriteLine("\n[System] Backup finalizado com sucesso.");
        }
    }
}