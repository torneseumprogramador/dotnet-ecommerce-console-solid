using System;
using ecommerce.enums;
using ecommerce.interfaces;
using Newtonsoft.Json;

namespace ecommerce.servicos
{
    class CsvServico: IPersistencia
    {
        private string caminhoArquivo<T>()
        {
            return  "db/" + typeof(T).Name.ToLower() + "s.csv";
        }
        public void Salvar<T>(List<T> lista)
        {
            var colunas = getColunas<T>();

            var linhas = colunas + "\n";
            foreach(var obj in lista){
                var colunasObj = "";
                foreach(var p in obj.GetType().GetProperties()){
                    colunasObj += p.GetValue(obj) + ";";
                }

                linhas += $"{colunasObj}\n";
            }

            File.WriteAllText(this.caminhoArquivo<T>(), linhas);
        }

        private string getColunas<T>()
        {
            var colunas = string.Empty;
            foreach(var p in typeof(T).GetProperties()){
                colunas += p.Name + ";";
            }

            return colunas;
        }

        public List<T> Todos<T>()
        {
            var colunas = getColunas<T>();
            var arquivo = caminhoArquivo<T>();
            if(!File.Exists(arquivo)) File.WriteAllText(arquivo, colunas);

            var lista = (List<T>)Activator.CreateInstance(typeof(List<T>));

            string text = File.ReadAllText(arquivo);
            string[] lines = text.Split(Environment.NewLine);
    
            foreach (string line in lines)
            {
                var coluns = line.Split(';');
                if(coluns[0].Trim().ToLower() == "id" || coluns[0].Trim().ToLower() == "") continue;

                var obj = Activator.CreateInstance(typeof(T));
                var i = 0;
                foreach(var p in obj.GetType().GetProperties()){
                    if(p.PropertyType == typeof(int)){
                        p.SetValue(obj, int.Parse(coluns[i]));
                    }
                    else{
                        p.SetValue(obj, coluns[i]);
                    }
                    i++;
                }

                lista.Add((T)obj);
            }
            
            return lista;
        }
    }

    
}
