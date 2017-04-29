using System.IO;

namespace Tp1_Azure.Data
{
    public class LeitorCsv
    {
        public string[] Ler(string path)
        {
           
            var contatosCsv = File.ReadAllLines(path);
            return contatosCsv;
           
        }
        
    }
}
