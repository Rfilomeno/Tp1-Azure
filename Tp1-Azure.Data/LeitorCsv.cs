using System;
using System.IO;

namespace Tp1_Azure.Data
{
    public class LeitorCsv
    {
        public string[] Ler(string path)
        {
            
            if (File.Exists(path))            
            {
                var contatosCsv = File.ReadAllLines(path);
                return contatosCsv;

            }
            else
            {
                System.Console.WriteLine("Arquivo não encontrado! Pressione enter para tentar novamente ou digite sair: ");
                var saida = Console.ReadLine();
                if (saida == "sair")
                {
                    Environment.Exit(00);
                }
                return null;
            }

        }
        
    }
}
