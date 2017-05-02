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
            string path = string.Empty;
            var CsvLido = AbrirArquivoHelper.Executa(out path);


            var contatos = ContatosHelper.CriaContatos(CsvLido);


            ContatoTableStorageDao tableDao = new ContatoTableStorageDao();
            //tableDao.Adiciona(contatos);

            ContatoBlobStorageDao BlobDao = new ContatoBlobStorageDao();
            //BlobDao.AddBlob(path);


            tableDao.ApagaTabela();
            //BlobDao.DeleteBlob();
            BlobDao.DeleteContainer();

            Console.ReadKey();
        }
    }
}
