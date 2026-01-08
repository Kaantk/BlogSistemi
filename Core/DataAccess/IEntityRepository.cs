using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, new()
    {
        // CRUD Operasyonları
        Task<List<T>> GetAllAsync(); // Tüm kayıtları getirir
        Task<T?> GetByIdAsync(int id); // ID'ye göre kayıt getirir
        Task AddAsync(T entity); // Yeni kayıt ekler
        Task UpdateAsync(T entity); // Mevcut kaydı günceller
        Task DeleteAsync(T entity); // Kayıt siler
    }
}
