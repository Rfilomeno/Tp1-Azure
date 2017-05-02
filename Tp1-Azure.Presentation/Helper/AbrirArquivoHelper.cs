using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1_Azure.Data;

namespace Tp1_Azure.Presentation.Helper
{
    public static class AbrirArquivoHelper
    {
        public static string[] Executa(out string path)
        {        
            string[] CsvLido;
            
                do
                {
                    Console.Write("Escreva o caminho (path) do arquivo csv: ");
                    path = Console.ReadLine();
                
                    LeitorCsv leitor = new LeitorCsv();

                    CsvLido = leitor.Ler(path);

                } while (CsvLido == null);
            return CsvLido;
        }
    }
}
