using System;
using System.Data;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository : IDisposable
    {
        Task<T> Obter<T>(object obj) where T : class;
        Task<bool> Alterar<T>(T obj) where T : class;
    }
}
