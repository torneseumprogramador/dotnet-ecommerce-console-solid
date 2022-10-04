using System;
using ecommerce.enums;
using ecommerce.interfaces;
using Newtonsoft.Json;

namespace ecommerce.servicos
{
    class CsvServico
    {
        public static void Salvar<T>(string colunas, string arquivo, List<T> lista)
        {
            var linhas = colunas + "\n";
            foreach(var obj in lista){
                var iObject = (IObject)obj;
                linhas += $"{iObject.Id}\n";
                // linhas += $"{obj.Id};{obj.Nome};{obj.Email};{obj.Telefone};{obj.EnderecoCompleto}\n";
            }

            File.WriteAllText(arquivo, linhas);
        }

        public static List<T> Todos<T>(string colunas, string arquivo, Type tipoObj)
        {
            if(!File.Exists(arquivo)) File.WriteAllText(arquivo, colunas);

            var lista = (List<T>)Activator.CreateInstance(typeof(List<T>));

            string text = File.ReadAllText(arquivo);
            string[] lines = text.Split(Environment.NewLine);
    
            foreach (string line in lines)
            {
                var coluns = line.Split(';');
                if(coluns[0].Trim().ToLower() == "id" || coluns[0].Trim().ToLower() == "") continue;

                var obj = (IObject)Activator.CreateInstance(typeof(T));
                obj.Id = int.Parse(coluns[0]);
                lista.Add((T)obj);
            }
            
            return lista;
        }
    }

    
}
