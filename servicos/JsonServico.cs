using System;
using ecommerce.enums;
using ecommerce.interfaces;
using Newtonsoft.Json;

namespace ecommerce.servicos
{
    class JsonServico
    {
        public static void Salvar<T>(string arquivo, object objetos)
        {
            var json = JsonConvert.SerializeObject(objetos);
            File.WriteAllText(arquivo, json);
        }

        public static List<T> Todos<T>(string arquivo, Type tipo)
        {
            if(!File.Exists(arquivo)) File.WriteAllText(arquivo, "[]");

            var json = File.ReadAllText(arquivo);
            var lista = JsonConvert.DeserializeObject(json, tipo);
            return (List<T>)lista;
        }
    }

    
}
