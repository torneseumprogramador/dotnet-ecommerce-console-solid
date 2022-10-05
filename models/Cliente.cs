using System;
using ecommerce.enums;
using ecommerce.interfaces;
using ecommerce.servicos;
using Newtonsoft.Json;

namespace ecommerce.models
{
    partial class Cliente
    {
        public void Salvar(IPersistencia persistencia)
        {
            ClientesServico.Salvar(this, persistencia);
        }

        public static List<Cliente> Todos(IPersistencia persistencia)
        {
            return ClientesServico.Todos(persistencia);
        }
    }

    
}
