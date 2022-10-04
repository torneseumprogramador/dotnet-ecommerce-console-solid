namespace ecommerce
{
    class Program
    {
        static void Main(string[] args)
        {
            new Cliente(){
                Id = 1,
                Nome = "Leandro",
                Email = "leandro@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(Tipo.CSV);

            new Cliente(){
                Id = 2,
                Nome = "Danilo",
                Email = "danilo@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(Tipo.CSV);

            Console.WriteLine("O cliente foi salvo com sucesso!");

            foreach(var cliente in Cliente.Todos())
            {
                Console.WriteLine("===============================");
                Console.WriteLine($"Id: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");
            }

            Console.WriteLine("============[Lendo do CSV]===================");
            foreach(var cliente in Cliente.Todos(Tipo.CSV))
            {
                Console.WriteLine("===============================");
                Console.WriteLine($"Id: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");
            }

        }
    }
}
