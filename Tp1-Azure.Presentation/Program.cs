using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1_Azure.Domain.Entities;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Table; // Namespace for Table storage types
using Microsoft.WindowsAzure.Storage.Blob;

namespace Tp1_Azure.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Escreva o caminho (path) do arquivo csv: ");
            //var pathCsv = Console.ReadLine();
            var pathCsv = @"C:\workspace\Tp1-Azure\Data\Contatos.csv";
            IList<Contato> contatos = new List<Contato>();


            var contatosCsv = File.ReadAllLines(pathCsv);

            foreach (var contatoNaoFormatado in contatosCsv)
            {
                var dados = contatoNaoFormatado.Split(',');
                Contato contato = new Contato(dados[0], dados[1], dados[2], dados[3]);

                contatos.Add(contato);
            }

            //CriandoTabelaNoStorage(contatos);

            //CriandoBlobNoStorage(pathCsv);

            foreach (var contato in contatos)
            {
                Console.WriteLine("{0} {1}", contato.Nome, contato.PartitionKey);
                Console.WriteLine(contato.RowKey);
                Console.WriteLine(contato.Email);
                Console.WriteLine("-----------------------------------------");
            }
            Console.ReadKey();

        }

        private static void CriandoBlobNoStorage(string pathCsv)
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference("rodrigofilomeno");

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("contato.csv");

            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = System.IO.File.OpenRead(pathCsv))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }

        private static void CriandoTabelaNoStorage(IList<Contato> contatos)
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference("RodrigoFilomeno");

            //table.DeleteIfExists();

            //Create the table if it doesn't exist.
            table.CreateIfNotExists();

            foreach (var contato in contatos)
            {
                TableOperation insertOperation = TableOperation.Insert(contato);
                table.Execute(insertOperation);
            }
        }
    }
}
