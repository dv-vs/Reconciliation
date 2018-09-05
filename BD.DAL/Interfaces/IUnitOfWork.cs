using EvoCafe.DAL.Models;
using System.Threading.Tasks;

namespace EvoCafe.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGeneralRepository<T> GeneralRepository<T>() where T : EntityBase;

        Task SaveChangesAsync();
    }
}
