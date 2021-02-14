using System.Threading.Tasks;
using API.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public ICategoryRepository CategoryRepository => new CategoryRepository(_context, _mapper);
        public IProductTypeRepository ProductTypeRepository => new ProductTypeRepository(_context, _mapper);
        public IUserRepository UserRepository => new UserRepository(_context, _mapper);
        public ISellerRepository SellerRepository => new SellerRepository(_context, _mapper);
        public IProductRepository ProductRepository => new ProductRepository(_context, _mapper);
        public ICartRepository CartRepository => new CartRepository(_context, _mapper);
        public ICartyRepository CartyRepository => new CartyRepository(_context, _mapper);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

    }
} 