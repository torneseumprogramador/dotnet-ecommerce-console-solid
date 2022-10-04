using System;
using Newtonsoft.Json;

namespace ecommerce
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string EnderecoCompleto { get; set; }

        public void Salvar()
        {
            var clientes = Cliente.Todos();
            var clienteExistente = clientes.Find(c => c.Id == this.Id);
            if(clienteExistente != null)
            {
                clientes.Remove(clienteExistente);
            }

            clientes.Add(this);

            var clientesJson = JsonConvert.SerializeObject(clientes);
            File.WriteAllText(ARQUIVO, clientesJson);
        }

        private const string ARQUIVO = "clientes.json";

        public static List<Cliente> Todos()
        {
            if(!File.Exists(ARQUIVO)) File.WriteAllText(ARQUIVO, "[]");
            List<Cliente> clientes = new List<Cliente>();
            var clientesJson = File.ReadAllText(ARQUIVO);
            clientes = JsonConvert.DeserializeObject<List<Cliente>>(clientesJson);
            return clientes;
        }
    }
}
