using System;
using Tp1_Azure.Data;
using Tp1_Azure.Presentation.Helper;

namespace Tp1_Azure.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Inicia();

        }

        private static void Inicia()
        {
            Console.Write("Escreva o caminho (path) do arquivo csv: ");
            Console.ReadLine();
            var path = Console.ReadLine();
            //var path = @"C:\workspace\Tp1-Azure\Data\Contatos.Csv";

            LeitorCsv leitor = new LeitorCsv();

            var CsvLido = leitor.Ler(path);

            var contatos = ContatosHelper.CriaContatos(CsvLido);


            ContatoTableStorageDao tableDao = new ContatoTableStorageDao();
            tableDao.Adiciona(contatos);

            ContatoBlobStorageDao BlobDao = new ContatoBlobStorageDao();
            BlobDao.AddBlob(path);


            //tableDao.ApagaTabela();
            //BlobDao.DeleteBlob();
            //BlobDao.DeleteContainer();

            Console.ReadKey();
        }
    }
}
