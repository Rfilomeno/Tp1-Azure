using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp1_Azure.Domain.Entities;

namespace Tp1_Azure.Data
{
    public class ContatoTableStorageDao
    {
        public void Adiciona(IList<Contato> contatos)
        {
            Console.WriteLine("Armazenando Dados na Tabela do storage aguarde...");

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("RodrigoFilomeno");

            table.CreateIfNotExists();

            foreach (var contato in contatos)
            {
                TableOperation insertOperation = TableOperation.Insert(contato);
                table.Execute(insertOperation);
            }
            Console.WriteLine("Dados Gravados na Tabela com sucesso!");
        }

        public void ApagaTabela()
        {
            Console.WriteLine("Apagando Tabela aguarde ...");

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));


            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();


            CloudTable table = tableClient.GetTableReference("RodrigoFilomeno");

            table.DeleteIfExists();
            Console.WriteLine("Tabela apagada com sucesso!");
        }
    }
}
