using System;
using ecommerce.enums;
using ecommerce.interfaces;
using Newtonsoft.Json;

namespace ecommerce.servicos
{
    class JsonServico : IPersistencia
    {
        private string caminhoArquivo<T>()
        {
            return  "db/" + typeof(T).Name.ToLower() + "s.json";
        }

        public void Salvar<T>(List<T> lista)
        {
            var json = JsonConvert.SerializeObject(lista);
            File.WriteAllText(caminhoArquivo<T>(), json);
        }

        public List<T> Todos<T>()
        {
            var arquivo = caminhoArquivo<T>();
            if(!File.Exists(arquivo)) File.WriteAllText(arquivo, "[]");

            var json = File.ReadAllText(arquivo);
            var lista = JsonConvert.DeserializeObject(json, typeof(List<T>));
            return (List<T>)lista;
        }
    }

    
}
