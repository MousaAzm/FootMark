using FootMark.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMark.Repositories.Interfaces.Products
{
    public interface IProductRepository
    {
        Task<bool> Add(Product user);
        Task<bool> Update(Product user);
        Task<List<Product>> GetAll();
        Task<Product> GetById(string id);
        Task<bool> Delete(string id);
    }
}
