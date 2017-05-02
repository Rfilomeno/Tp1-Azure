using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;

namespace Tp1_Azure.Data
{
    public class ContatoBlobStorageDao
    {
        public void AddBlob(string path)
        {
            Console.WriteLine("Armazenado blob no Storage aguarde...");
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("rodrigofilomeno");

            container.CreateIfNotExists();

            var pathSplit = path.Split('\\');

            var nomeDoArquivo = pathSplit[pathSplit.Length - 1];

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(nomeDoArquivo);

            using (var fileStream = System.IO.File.OpenRead(path))
            {
                blockBlob.UploadFromStream(fileStream);
            }
            Console.WriteLine("Arquivo armazenado no Storage com sucesso!");
        }

        public void DeleteBlob()
        {
            Console.WriteLine("qual o nome do arquivo que deseja apagar? ");
            string nomeDoArquivo = Console.ReadLine();

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("rodrigofilomeno");


            CloudBlockBlob blockBlob = container.GetBlockBlobReference(nomeDoArquivo);
            if(blockBlob != null)
            {
                blockBlob.DeleteIfExists();
                Console.WriteLine("Arquivo apagado no Storage com sucesso!");

            }
            else
            {
                Console.WriteLine("Arquivo não encontrado!");
            }

        }

        public void DeleteContainer()
        {
            Console.WriteLine("Apagando Container no Storage aguarde...");

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("rodrigofilomeno");

            container.DeleteIfExists();
            Console.WriteLine("Container apagado no Storage com sucesso!");


        }


    }
}
