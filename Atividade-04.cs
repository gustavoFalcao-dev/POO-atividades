using System;
using System.Collections.Generic;


namespace Atv04
{
    public interface INotificavel
    {
        void EnviarMsg( string msg );
    }

    public class Email : INotificavel
    {
        public string EmailDestino { get; set; }
        public void EnviarMsg( string msg )
        {
            Console.WriteLine($"[Email] Para: { EmailDestino } | Conteudo: '{ msg }'");
        }
    }

    public class SMS : INotificavel
    {
        public string NumTelefone { get; set; }
        public void EnviarMsg( string msg )
        {
            Console.WriteLine($"[SMS] Enviado para { NumTelefone }: '{ msg }'");
        }
    }

    public class PushNotification : INotificavel
    {
        public void EnviarMsg( string msg )
        {
            Console.WriteLine($"[Push] Notificacao no app: '{ msg }'");
        }
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public List<INotificavel> CanaisDeContato { get; set; } = new List<INotificavel>();

        public void NotificarGeral( string aviso )
        {
            Console.WriteLine($"----- Notificando { Nome } -----");
            foreach ( var canal in CanaisDeContato )
            {
                canal.EnviarMsg( aviso );
            }
            Console.WriteLine("---------------------------------\n");
        }
    }

    class Program
    {
        static void Main()
        {
            Usuario u1 = new Usuario { Nome = "Cefras" };
            u1.CanaisDeContato.Add(new Email { EmailDestino = "cefras@email.com" });
            u1.CanaisDeContato.Add(new SMS { NumTelefone = "83-40028922" });

            Usuario u2 = new Usuario { Nome = "Isaac Newton"};
            u2.CanaisDeContato.Add(new PushNotification());

            u1.NotificarGeral("Seu pedido saiu para entrega!");
            u2.NotificarGeral("Comecou o happy hour!");
            Console.ReadKey();
        }
    }
}