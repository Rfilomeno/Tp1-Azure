using Microsoft.WindowsAzure.Storage.Table;


namespace Tp1_Azure.Domain.Entities
{
    public class Contato : TableEntity
    {
        public Contato(string nome, string sobrenome, string telefone, string email)
        {
            this.PartitionKey = sobrenome;
            this.RowKey = telefone;
            this.Nome = nome;
            this.Email = email;
        }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
