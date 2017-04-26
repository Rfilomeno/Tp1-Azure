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

namespace Tp1_Azure.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Escreva o caminho (path) do arquivo csv: ");
            var pathCsv = Console.ReadLine();

            IList<Contato> contatos = new List<Contato>();

            
            var contatosCsv = File.ReadAllLines(pathCsv);
            
            foreach (var contatoNaoFormatado in contatosCsv)
            {
                var dados = contatoNaoFormatado.Split(',');
                Contato contato = new Contato(dados[0], dados[1], Convert.ToInt32(dados[2]), dados[3]);

                contatos.Add(contato);
            }
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference("contato");

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();

            foreach (var contato in contatos)
            {
                TableOperation insertOperation = TableOperation.Insert(contato);
                table.Execute(insertOperation);
            }

            foreach (var contato in contatos)
            {
                Console.WriteLine("{0} {1}",contato.Nome, contato.Sobrenome);
                Console.WriteLine(contato.Telefone);
                Console.WriteLine(contato.Email);
                Console.WriteLine("-----------------------------------------");
            }
            Console.ReadKey();
            
        }
    }
}
