using Company.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BL.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProductoById(int id);
        Task<Producto> PostProducto(Producto dataProducto);
        Task<Producto> UpdateProducto(int id, Producto dataProducto);
        Task<string> DeleteProductoById(int id);
    }
}
