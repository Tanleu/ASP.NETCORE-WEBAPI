using Assignment_3_Product.Interfaces;
using Assignment_3_Product.Models;
using Assignment_3_Product.DataContexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Assignment_3_Product.Services;

public class ProductService : IProductService
{
        private readonly ProductContext _context;
        private readonly IMapper _mapper;
        public ProductService(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> ListAsync()
        {
            return (await _context.Products.ToListAsync())
                .Select(x=> _mapper.Map<ProductDTO>(x)).ToList();
        }


        public async Task<ProductDTO> CreateAsync(ProductDTO product)
        {
            product.Id = Guid.NewGuid();
            var categoryDB = _mapper.Map<ProductDBModel>(product);
        
            await _context.AddAsync<ProductDBModel>(categoryDB);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> DeleteAsync(Guid Id)
        {
            var toDeletePerson = await _context.Products.FindAsync(Id);
            if(toDeletePerson == null)
                throw new Exception("This product was deleted or not exist");

            _context.Products.Remove(toDeletePerson);
            await _context.SaveChangesAsync();
           
            return _mapper.Map<ProductDTO>(toDeletePerson);
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO product)
        {
            using(var toUpdateProduct = await _context.Products.FindAsync(product.Id))
            {
                if(toUpdateProduct == null)
                    throw new Exception("This product was deleted or not exist");
                 _context.Entry(toUpdateProduct).State = EntityState.Detached;
            }

            _context.Entry(_mapper.Map<ProductDBModel>(product)).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return product;
        }
}