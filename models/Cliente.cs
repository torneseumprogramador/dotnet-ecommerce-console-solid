using System;
using ecommerce.enums;
using ecommerce.interfaces;
using ecommerce.servicos;
using Newtonsoft.Json;

namespace ecommerce.models
{
    class Cliente : IObject
    {
        #region Constantes
        private const string ARQUIVO_JSON = "db/clientes.json";
        private const string ARQUIVO_CSV = "db/clientes.csv";
        private const string COLUNAS_CSV = "id;nome;email;telefone;enderecoCompleto";
        #endregion

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string EnderecoCompleto { get; set; }

        public void Salvar(Tipo tipo = Tipo.Json)
        {
            var clientes = Cliente.Todos(tipo);
            var clienteExistente = clientes.Find(c => c.Id == this.Id);
            if(clienteExistente != null)
            {
                clientes.Remove(clienteExistente);
            }

            clientes.Add(this);

            if(tipo == Tipo.Json){
                JsonServico.Salvar<Cliente>(ARQUIVO_JSON, clientes);
            }
            else{
                CsvServico.Salvar<Cliente>(COLUNAS_CSV, ARQUIVO_CSV, clientes);
            }
        }

        public static List<Cliente> Todos(Tipo tipo = Tipo.Json)
        {
            if(tipo == Tipo.Json)
            {
                return JsonServico.Todos<Cliente>(ARQUIVO_JSON, typeof(List<Cliente>));
            }
            else{
                return CsvServico.Todos<Cliente>(COLUNAS_CSV, ARQUIVO_CSV, typeof(List<Cliente>));
            }

        }
    }

    
}
