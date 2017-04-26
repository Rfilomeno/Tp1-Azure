using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tp1_Azure.Domain.Entities
    {
    public class Contato : TableEntity
    {
        public Contato(string nome, string sobrenome, int telefone, string email)
        {
            this.PartitionKey = nome;
            this.RowKey = sobrenome;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.Email = email;
        }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
    }
}
