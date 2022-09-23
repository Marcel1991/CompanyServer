using Company.DAL.Models;
using Company.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.BL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Company.BL.Services
{
    public class ProductoService : IProductoRepository
    {
        private readonly ApiDbContext _context;

        // Creamos un constructor e inyectar el contexto
        public ProductoService(ApiDbContext context)
        {
            _context = context;
        }


        // GET Productos
        public async Task<IEnumerable<Producto>> GetProductos()
        {
            var listProductos = await _context.Producto.ToListAsync();
            return listProductos;
        }

        // GET Producto By Id
        public async Task<Producto> GetProductoById(int id)
        {

            var userFound = await _context.Producto.FindAsync(id);
            return userFound;
        }


        // POST Producto
        public async Task<Producto> PostProducto(Producto dataProducto)
        {
            _context.Producto.Add(dataProducto);
            await _context.SaveChangesAsync();
            return dataProducto;
        }


        // UPDATE
        public async Task<Producto> UpdateProducto(int id, Producto dataProducto)
        {
            _context.Producto.Update(dataProducto);
            await _context.SaveChangesAsync();
            return dataProducto;
        }

        // DELETE
        public async Task<string> DeleteProductoById(int id)
        {
            var userFound = await _context.Producto.FindAsync(id);
            if (userFound == null)
            {
                return "NOT_FOUND";
            }
            _context.Producto.Remove(userFound);
            await _context.SaveChangesAsync();
            return "OK";
        }
    }
}
