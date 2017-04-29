using System.Collections.Generic;
using Tp1_Azure.Domain.Entities;

namespace Tp1_Azure.Presentation.Helper
{
    public static class ContatosHelper
    {
        public static IList<Contato> CriaContatos(string[] csvLido)
        {
            IList<Contato> contatos = new List<Contato>();

            foreach (var contatoNaoFormatado in csvLido)
            {
                var dados = contatoNaoFormatado.Split(',');
                Contato contato = new Contato(dados[0], dados[1], dados[2], dados[3]);

                contatos.Add(contato);
            }
            return contatos;
        }
    }
}
