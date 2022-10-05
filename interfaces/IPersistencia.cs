using System;

namespace ecommerce.interfaces
{
    interface IPersistencia
    {
        void Salvar<T>(List<T> lista);

        List<T> Todos<T>();
    }
}