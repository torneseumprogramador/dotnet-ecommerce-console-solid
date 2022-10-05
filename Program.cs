using ecommerce.enums;
using ecommerce.interfaces;
using ecommerce.models;
using ecommerce.servicos;

namespace ecommerce
{
    class Program
    {
        static void Main(string[] args)
        {
        
            var forne = new Fornecedor(){
                Id = 1,
                Nome = "Sysmattos",
                CNPJ = "12341323432",
                Email = "sys@gmail.com"
            };

            var jsonServico = new JsonServico();
            var lista = jsonServico.Todos<Fornecedor>();

            var fornEncontrado = lista.Find(f => f.Id == forne.Id);
            if(fornEncontrado != null) lista.Remove(fornEncontrado);

            lista.Add(forne);
            jsonServico.Salvar<Fornecedor>(lista);



            var c1 = new Cliente();
            c1.Nome = "sss";
            c1.Salvar(new JsonServico());


            var cliMysql = new Cliente(){
                Id = 1,
                Nome = "Leandro",
                Email = "leandro@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            };
            cliMysql.Salvar(new MySqlServico());


            var cli = new Cliente(){
                Id = 1,
                Nome = "Leandro",
                Email = "leandro@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            };

            ClientesServico.Salvar(cli, new CsvServico());

            new Cliente(){
                Id = 1,
                Nome = "Leandro",
                Email = "leandro@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(new JsonServico());

            new Cliente(){
                Id = 2,
                Nome = "Danilo",
                Email = "danilo@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(new JsonServico());

            new Cliente(){
                Id = 1,
                Nome = "Leandro",
                Email = "leandro@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(new CsvServico());

            new Cliente(){
                Id = 2,
                Nome = "Danilo",
                Email = "danilo@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(new CsvServico());

            Console.WriteLine("O cliente foi salvo com sucesso!");

            foreach(Cliente cliente in ClientesServico.Todos(new JsonServico()))
            {
                Console.WriteLine("===============================");
                Console.WriteLine($"Id: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");
            }

            Console.WriteLine("============[Lendo do CSV]===================");
            foreach(Cliente cliente in ClientesServico.Todos(new CsvServico()))
            {
                Console.WriteLine("===============================");
                Console.WriteLine($"Id: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");
            }

        }
    }
}
