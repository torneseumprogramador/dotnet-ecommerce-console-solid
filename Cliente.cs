using System;
using Newtonsoft.Json;

namespace ecommerce
{
    class Cliente
    {
        #region Constantes
        private const string ARQUIVO_JSON = "clientes.json";
        private const string ARQUIVO_CSV = "clientes.csv";
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
                var clientesJson = JsonConvert.SerializeObject(clientes);
                File.WriteAllText(ARQUIVO_JSON, clientesJson);
            }
            else{
                var linhas = COLUNAS_CSV + "\n";
                foreach(var cliente in clientes){
                    linhas += $"{cliente.Id};{cliente.Nome};{cliente.Email};{cliente.Telefone};{cliente.EnderecoCompleto}\n";
                }

                File.WriteAllText(ARQUIVO_CSV, linhas);
            }
        }

        public static List<Cliente> Todos(Tipo tipo = Tipo.Json)
        {
            if(tipo == Tipo.Json)
            {
                if(!File.Exists(ARQUIVO_JSON)) File.WriteAllText(ARQUIVO_JSON, "[]");
                List<Cliente> clientes = new List<Cliente>();
                var clientesJson = File.ReadAllText(ARQUIVO_JSON);
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(clientesJson);
                return clientes;
            }
            else{
                if(!File.Exists(ARQUIVO_CSV)) File.WriteAllText(ARQUIVO_CSV, COLUNAS_CSV);
                List<Cliente> clientes = new List<Cliente>();

                string text = File.ReadAllText(ARQUIVO_CSV);
                string[] lines = text.Split(Environment.NewLine);
        
                foreach (string line in lines)
                {
                    var coluns = line.Split(';');
                    if(coluns[0].Trim().ToLower() == "id" || coluns[0].Trim().ToLower() == "") continue;

                    clientes.Add(new Cliente(){
                        Id = int.Parse(coluns[0]),
                        Nome = coluns[1],
                        Email = coluns[2],
                        Telefone = coluns[3],
                        EnderecoCompleto = coluns[4]
                    });
                }
                
                return clientes;
            }

        }
    }

    enum Tipo
    {
        CSV,
        Json,
        SqlServer,
        MySql,
        Mongodb
    }
}
