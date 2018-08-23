using EvoCafe.DAL.Models;
using System.Threading.Tasks;

namespace EvoCafe.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : EntityBase;

        Task SaveChangesAsync();
    }
}
