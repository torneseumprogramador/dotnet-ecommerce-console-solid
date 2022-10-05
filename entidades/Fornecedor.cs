using System;
using ecommerce.enums;
using ecommerce.interfaces;
using ecommerce.servicos;
using Newtonsoft.Json;

namespace ecommerce.models
{
    partial class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
    }
}
